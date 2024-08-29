using SimplePNGTuber.Options;
using SimplePNGTuber.Server;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Text.Json;
using System.Windows.Forms;
using SimplePNGTuber.Model.Endpoints;
using SimplePNGTuber.Model.WSEndpoints;

namespace SimplePNGTuber.Model
{
    public class PNGModelRegistry
    {
        private const string ModelFileExtension = ".pngmodel";
        private const string ExpressionPrefix = "exp_";
        private const string AccessoryPrefix = "acc_";
        private static PNGModelRegistry instance;

        public static PNGModelRegistry Instance => instance ?? new PNGModelRegistry();

        private Dictionary<string, PNGModel> models = new Dictionary<string, PNGModel>();

        private readonly List<ModelWSEndpoint> wsEndpoints = new List<ModelWSEndpoint>();

        public PNGModel ActiveModel { get; private set; } = PNGModel.Empty;

        private PNGModelRegistry()
        {
            instance = this;

            Settings.Instance.SettingChanged += HandleSettingChanged;

            LoadModels();
            ActiveModel = GetModel(Settings.Instance.ModelName);

            SetModelEndpoint setModelEndpoint = new SetModelEndpoint();
            HttpServer.Instance.AddEndpoint("/setmodel/", setModelEndpoint);
            setModelEndpoint.ModelChangeEvent += ModelChanged;

            GetModelEndpoint getModelEndpoint = new GetModelEndpoint();
            HttpServer.Instance.AddEndpoint("/getmodel/", getModelEndpoint);

            SetExpressionEndpoint setExpressionEndpoint = new SetExpressionEndpoint();
            HttpServer.Instance.AddEndpoint("/setexpression/", setExpressionEndpoint);
            setExpressionEndpoint.ExpressionChangeEvent += ExpressionChanged;

            AddRemoveAccessoryEndpoint accessoryEndpoint = new AddRemoveAccessoryEndpoint();
            HttpServer.Instance.AddEndpoint("/accessory/", accessoryEndpoint);
            accessoryEndpoint.AccessoryAddEvent += AddAccessory;
            accessoryEndpoint.AccessoryRemoveEvent += RemoveAccessory;

            WebSocketServer.Instance.AddWebSocketService("/model", () => {
                ModelWSEndpoint endpoint = new ModelWSEndpoint();
                instance.wsEndpoints.Add(endpoint);
                return endpoint;
            });
        }

        private void AddAccessory(object sender, AccessoryEventArgs e)
        {
            this.ActiveModel.SetAccessoryActive(e.AccessoryName, true);
            this.wsEndpoints.ForEach(ep => ep.AnnounceAccessory(e.AccessoryName, true));
        }

        private void RemoveAccessory(object sender, AccessoryEventArgs e)
        {
            this.ActiveModel.SetAccessoryActive(e.AccessoryName, false);
            this.wsEndpoints.ForEach(ep => ep.AnnounceAccessory(e.AccessoryName, false));
        }

        private void ModelChanged(object sender, ModelEventArgs e)
        {
            Settings.Instance.ModelName = e.ModelName;
        }

        private void ExpressionChanged(object sender, ExpressionEventArgs e)
        {
            this.ActiveModel.CurrentExpression = e.ExpressionName;
            this.wsEndpoints.ForEach(ep => ep.AnnounceExpressionChange(e.ExpressionName));
        }

        private void HandleSettingChanged(object sender, SettingChangeEventArgs e)
        {
            if(e.ChangeType == SettingChangeType.MODELDIR)
            {
                LoadModels();
            }
            else if(e.ChangeType == SettingChangeType.MODEL)
            {
                this.ActiveModel = GetModel(Settings.Instance.ModelName);
                this.wsEndpoints.ForEach(ep => ep.AnnounceModelChange(Settings.Instance.ModelName));
            }
        }

        public void LoadModels()
        {
            models.Clear();
            if (string.IsNullOrEmpty(Settings.Instance.ModelDir))
            {
                return;
            }
            foreach (string s in Directory.EnumerateFiles(Settings.Instance.ModelDir))
            {
                if (s.EndsWith(ModelFileExtension))
                {
                    string name = s.Replace(ModelFileExtension, "");
                    name = name.Substring(name.LastIndexOf(Path.DirectorySeparatorChar) + 1).ToLower();
                    models.Add(name, null);
                }
            }
        }

        public IEnumerable<string> GetModelNames()
        {
            return models.Keys;
        }

        public PNGModel GetModel(string name)
        {
            if(string.IsNullOrEmpty(name) || !models.ContainsKey(name))
            {
                return PNGModel.Empty;
            }
            return models[name] ?? (models[name] = LoadModel(name));
        }

        public PNGModel LoadModel(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return PNGModel.Empty;
            }
            try
            {
                var expressions = new Dictionary<string, Image[]>();
                var accessories = new Dictionary<string, Image>();
                var modelSettings = new PNGModelSettings();
                using (ZipArchive zip = ZipFile.OpenRead(GetModelFileName(name)))
                {
                    foreach (ZipArchiveEntry entry in zip.Entries)
                    {
                        if (entry.Name.EndsWith(".png"))
                        {
                            if (entry.Name.StartsWith(ExpressionPrefix))
                            {
                                string expName = entry.Name.Substring(4);
                                expName = expName.Substring(0, expName.LastIndexOf('_'));
                                int expIndex = int.Parse(entry.Name.Substring(entry.Name.LastIndexOf('_') + 1).Replace(".png", ""));
                                if (!expressions.ContainsKey(expName))
                                {
                                    expressions.Add(expName, new Image[4]);
                                }
                                using (var stream = entry.Open())
                                {
                                    expressions[expName][expIndex] = Image.FromStream(stream);
                                }
                            }
                            else if (entry.Name.StartsWith(AccessoryPrefix))
                            {
                                string accName = entry.Name.Substring(4).Replace(".png", "");
                                using (var stream = entry.Open())
                                {
                                    accessories.Add(accName, Image.FromStream(stream));
                                }
                            }
                        }
                        else if(entry.Name.Equals("settings.json"))
                        {
                            using (var stream = entry.Open())
                            {
                                modelSettings = JsonSerializer.Deserialize<PNGModelSettings>(stream);
                            }
                        }
                    }
                }
                var accessoriesByLayer = new Dictionary<string, Accessory>();
                foreach (var accessory in accessories)
                {
                    if(modelSettings.AccessoryLayers.ContainsKey(accessory.Key))
                    {
                        accessoriesByLayer.Add(accessory.Key, new Accessory() { Name = accessory.Key, Image = new LayeredImage() { Image = accessory.Value, Layer = modelSettings.AccessoryLayers[accessory.Key] } });
                    }
                }
                PNGModel model = new PNGModel(name, modelSettings, expressions, accessoriesByLayer);
                return model;
            }
            catch (Exception)
            {
                return PNGModel.Empty;
            }
        }

        public bool SaveModel(string name, PNGModelSettings settings, Dictionary<string, Image[]> expressions, Dictionary<string, Image> accessories)
        {
            string tmpDir = Settings.Instance.ModelDir + "/modelTmp";
            Directory.CreateDirectory(tmpDir);
            foreach (var expName in expressions.Keys)
            {
                var imgs = expressions[expName];
                for (int i = 0; i < imgs.Length; i++)
                {
                    imgs[i].Save(tmpDir + "/" + ExpressionPrefix + expName + "_" + i + ".png");
                }
            }
            foreach (var accName in accessories.Keys)
            {
                accessories[accName].Save(tmpDir + "/" + AccessoryPrefix + accName + ".png");
            }

            var settingsString = JsonSerializer.Serialize(settings);
            File.WriteAllText(tmpDir + "/settings.json", settingsString);

            string modelFile = GetModelFileName(name);
            bool saved = false;
            if(!File.Exists(modelFile) || MessageBox.Show("Model already exists. Overwrite?", "Save Model", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                File.Delete(modelFile);
                ZipFile.CreateFromDirectory(tmpDir, modelFile);
                saved = true;
            }
            Directory.Delete(tmpDir, true);
            return saved;
        }

        public string GetModelFileName(string modelName)
        {
            return Settings.Instance.ModelDir + "/" + modelName + ModelFileExtension;
        }
    }
}
