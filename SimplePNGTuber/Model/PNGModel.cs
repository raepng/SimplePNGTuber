using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace SimplePNGTuber.Model
{
    public class PNGModel
    {
        public readonly string Name;
        public string CurrentExpression { get; set; } = "neutral";

        private Dictionary<string, Image[]> expressions;
        private Dictionary<string, Image> accessories;

        public PNGModel(string name, Dictionary<string, Image[]> expressions, Dictionary<string, Image> accessories)
        {
            this.Name = name;
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

        public static readonly PNGModel Empty = new PNGModel(
            "empty",
            new Dictionary<string, Image[]>()
            {
                { "neutral", new Image[] { Resources.diego0, Resources.diego1, Resources.diego0, Resources.diego1 } }
            },
            new Dictionary<string, Image>()
        );
    }

    public enum PNGState
    {
        SILENT,
        SPEAKING,
        BLINKING,
        SPEAKING_BLINKING
    }
}
