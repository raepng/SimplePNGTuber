using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SimplePNGTuber.Model
{
    public class PNGModel
    {
        public readonly string Name;
        public string CurrentExpression { get; set; } = "neutral";

        internal PNGModelSettings Settings;
        internal Dictionary<string, Image[]> expressions;
        internal Dictionary<string, Accessory> accessories;
        internal HashSet<string> activeAccessories = new HashSet<string>();

        public PNGModel(string name, PNGModelSettings settings, Dictionary<string, Image[]> expressions, Dictionary<string, Accessory> accessories)
        {
            this.Name = name;
            this.Settings = settings;
            this.expressions = expressions;
            this.accessories = accessories;
        }

        public List<string> GetExpressions()
        {
            return expressions.Keys.ToList();
        }

        public List<string> GetAccessories()
        {
            return accessories.Keys.ToList();
        }

        public void SetAccessoryActive(string accessory, bool active)
        {
            if (active)
            {
                activeAccessories.Add(accessory);
            }
            else
            {
                activeAccessories.Remove(accessory);
            }
        }

        public Image GetState(PNGState state)
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
                var images = new HashSet<LayeredImage>();
                images.Add(new LayeredImage() { Layer = 0, Image = res });
                foreach (string key in activeAccessories)
                {
                    if (accessories.ContainsKey(key))
                    {
                        images.Add(accessories[key].Image);
                    }
                }

                var enumerator = images.OrderBy(image => image.Layer).GetEnumerator();
                enumerator.MoveNext();

                Image copy = (Image) enumerator.Current.Image.Clone();
                using (Graphics canvas = Graphics.FromImage(copy))
                {
                    while(enumerator.MoveNext())
                    {
                        canvas.DrawImage(enumerator.Current.Image, 0, 0, copy.Width, copy.Height);
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

        public static readonly PNGModel Empty = new PNGModel(
            "empty",
            new PNGModelSettings(),
            new Dictionary<string, Image[]>()
            {
                { "neutral", new Image[] { Resources.diego0, Resources.diego1, Resources.diego0, Resources.diego1 } }
            },
            new Dictionary<string, Accessory>()
        );
    }

    public struct LayeredImage
    {
        public int Layer;
        public Image Image;
    }

    public struct Accessory
    {
        public string Name;
        public LayeredImage Image;

        public override string ToString()
        {
            return Name;
        }
    }

    public enum PNGState
    {
        SILENT,
        SPEAKING,
        BLINKING,
        SPEAKING_BLINKING
    }
}
