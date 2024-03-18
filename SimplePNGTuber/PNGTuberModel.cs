using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePNGTuber
{
    public class PNGTuberModel
    {
        public readonly string Name;
        public string CurrentExpression { get; set; } = "neutral";

        private Dictionary<string, Image[]> expressions;
        private Dictionary<string, Image> accessories;
        private PNGTuberModel(string name)
        {
            this.Name = name;
        }

        public List<string> GetExpressions()
        {
            return expressions.Keys.ToList();
        }

        public List<string> GetAccessories()
        {
            return accessories.Keys.ToList();
        }

        public Image GetState(PNGState state, IEnumerable<string> activeAccessories)
        {
            Image res = null;
            switch (state)
            {
                case PNGState.SILENT :
                    res = expressions[CurrentExpression][0];
                    break;
                case PNGState.SPEAKING :
                    res = expressions[CurrentExpression][1];
                    break;
                case PNGState.BLINKING : 
                    res = expressions[CurrentExpression][2];
                    break;
                case PNGState.SPEAKING_BLINKING : 
                    res = expressions[CurrentExpression][3];
                    break;
                default :
                    res = expressions[CurrentExpression][0];
                    break;
            }
            try
            {
                Image copy = (Image)res.Clone();
                using (Graphics canvas = Graphics.FromImage(copy))
                {
                    foreach (string key in activeAccessories)
                    {
                        if (accessories.ContainsKey(key))
                        {
                            canvas.DrawImage(accessories[key], 0, 0);
                        }
                    }
                    canvas.Save();
                }
                return copy;
            }
            catch (Exception)
            {
                return res;
            }
        }

        public static PNGTuberModel Load(string dir, string name)
        {
            if(string.IsNullOrEmpty(dir) || string.IsNullOrEmpty(name))
            {
                return Empty;
            }
            try
            {
                var expressions = new Dictionary<string, Image[]>();
                var accessories = new Dictionary<string, Image>();
                using (ZipArchive zip = ZipFile.OpenRead(dir + "/" + name + ".zip")) {
                    foreach (ZipArchiveEntry entry in zip.Entries)
                    {
                        if(entry.Name.EndsWith(".png"))
                        {
                            if(entry.Name.StartsWith("exp_"))
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
                            else if(entry.Name.StartsWith("acc_"))
                            {
                                string accName = entry.Name.Substring(4).Replace(".png", "");
                                using (var stream = entry.Open())
                                {
                                    accessories.Add(accName, Image.FromStream(stream));
                                }
                            }
                        }
                        else if(entry.Name.EndsWith(".settings"))
                        {

                        }
                    }
                }
                PNGTuberModel model = new PNGTuberModel(name)
                {
                    expressions = expressions,
                    accessories = accessories,
                };
                return model;
            }
            catch(Exception)
            {
                return Empty;
            }
        }

        public static void Save(string dir, string name, Dictionary<string, Image[]> expressions, Dictionary<string, Image> accessories)
        {
            string tmpDir = dir + "/modelTmp";
            Directory.CreateDirectory(tmpDir);
            foreach(var expName in expressions.Keys)
            {
                var imgs = expressions[expName];
                for(int i = 0; i < imgs.Length; i++)
                {
                    imgs[i].Save(tmpDir + "/exp_" + expName + "_" + i + ".png");
                }
            }
            foreach(var accName in accessories.Keys)
            {
                accessories[accName].Save(tmpDir + "/acc_" + accName + ".png");
            }
            ZipFile.CreateFromDirectory(tmpDir, dir + "/" + name + ".zip");
            Directory.Delete(tmpDir, true);
        }

        public static readonly PNGTuberModel Empty = new PNGTuberModel("empty")
        {
            expressions = new Dictionary<string, Image[]>()
            {
                { "neutral", new Image[] { Resources.diego0, Resources.diego1, Resources.diego0, Resources.diego1 } }
            }
        };
    }

    public enum PNGState
    {
        SILENT,
        SPEAKING,
        BLINKING,
        SPEAKING_BLINKING
    }
}
