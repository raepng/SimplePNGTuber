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

namespace SimplePNGTuber.Model
{
    public class PNGModelRegistry
    {
        private const string ModelFileExtension = ".pngmodel";
        private const string ExpressionPrefix = "exp_";
        private const string AccessoryPrefix = "acc_";
        private static PNGModelRegistry instance;

        public static PNGModelRegistry Instance => instance ?? (instance = new PNGModelRegistry());

        private Dictionary<string, PNGModel> models = new Dictionary<string, PNGModel>();

        public PNGModel ActiveModel { get; private set; } = PNGModel.Empty;

        public bool Muted { get; private set; }

        private PNGModelRegistry()
        {
            Settings.Instance.SettingChanged += HandleSettingChanged;

            SetModelEndpoint setModelEndpoint = new SetModelEndpoint();
            HttpServer.Instance.AddEndpoint("/setmodel/", setModelEndpoint);
            setModelEndpoint.ModelChangeEvent += ModelChanged;

            SetExpressionEndpoint setExpressionEndpoint = new SetExpressionEndpoint();
            HttpServer.Instance.AddEndpoint("/setexpression/", setModelEndpoint);
            setExpressionEndpoint.ExpressionChangeEvent += ExpressionChanged;

            AddRemoveAccessoryEndpoint accessoryEndpoint = new AddRemoveAccessoryEndpoint();
            HttpServer.Instance.AddEndpoint("/accessory/", accessoryEndpoint);
            accessoryEndpoint.AccessoryAddEvent += AddAccessory;
            accessoryEndpoint.AccessoryRemoveEvent += RemoveAccessory;

            MuteEndpoint muteEndpoint = new MuteEndpoint();
            HttpServer.Instance.AddEndpoint("/mute/", muteEndpoint);
            muteEndpoint.MutedEvent += MuteChanged;
        }

        private void MuteChanged(object sender, MutedEventArgs e)
        {
            this.Muted = e.Muted;
        }

        private void AddAccessory(object sender, AccessoryEventArgs e)
        {
            this.ActiveModel.SetAccessoryActive(e.AccessoryName, true);
        }

        private void RemoveAccessory(object sender, AccessoryEventArgs e)
        {
            this.ActiveModel.SetAccessoryActive(e.AccessoryName, false);
        }

        private void ModelChanged(object sender, ModelEventArgs e)
        {
            Settings.Instance.ModelName = e.ModelName;
        }

        private void ExpressionChanged(object sender, ExpressionEventArgs e)
        {
            this.ActiveModel.CurrentExpression = e.ExpressionName;
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
                using (ZipArchive zip = ZipFile.OpenRead(Settings.Instance.ModelDir + "/" + name + ModelFileExtension))
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

            string modelFile = Settings.Instance.ModelDir + "/" + name + ModelFileExtension;
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
    }
}
