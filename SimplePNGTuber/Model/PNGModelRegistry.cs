using SimplePNGTuber.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private PNGModelRegistry()
        {

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
                    }
                }
                PNGModel model = new PNGModel(name, expressions, accessories);
                return model;
            }
            catch (Exception)
            {
                return PNGModel.Empty;
            }
        }

        public bool SaveModel(string name, Dictionary<string, Image[]> expressions, Dictionary<string, Image> accessories)
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
