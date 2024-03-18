using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePNGTuber
{
    public partial class ExpressionPopup : Form
    {
        public string ExpressionName { get; private set; }
        public Image[] Images { get; private set; } = new Image[4] { Resources.diego0, Resources.diego1, Resources.diego0, Resources.diego1 };
        public string[] ImageLocations { get; private set; } = new string[4] { "", "", "", "" };

        public ExpressionPopup(Expression expression)
        {
            InitializeComponent();

            this.ExpressionName = expression.Name;
            this.Images = expression.Images;
            this.ImageLocations = expression.ImageLocations;

            this.expNameTextBox.Text = expression.Name;
            this.exp0FileNameBox.Text = expression.ImageLocations[0];
            this.exp1FileNameBox.Text = expression.ImageLocations[1];
            this.exp2FileNameBox.Text = expression.ImageLocations[2];
            this.exp3FileNameBox.Text = expression.ImageLocations[3];
        }

        private void BtnExp0_Click(object sender, EventArgs e)
        {
            var res = openImageDialogue.ShowDialog();
            if(res == DialogResult.OK)
            {
                exp0FileNameBox.Text = openImageDialogue.FileName;
            }
        }

        private void BtnExp1_Click(object sender, EventArgs e)
        {
            var res = openImageDialogue.ShowDialog();
            if (res == DialogResult.OK)
            {
                exp1FileNameBox.Text = openImageDialogue.FileName;
            }
        }

        private void BtnExp2_Click(object sender, EventArgs e)
        {
            var res = openImageDialogue.ShowDialog();
            if (res == DialogResult.OK)
            {
                exp2FileNameBox.Text = openImageDialogue.FileName;
            }
        }

        private void BtnExp3_Click(object sender, EventArgs e)
        {
            var res = openImageDialogue.ShowDialog();
            if (res == DialogResult.OK)
            {
                exp3FileNameBox.Text = openImageDialogue.FileName;
            }
        }

        private void Exp0FileNameBox_TextChanged(object sender, EventArgs e)
        {
            if (!File.Exists(exp0FileNameBox.Text) || !exp0FileNameBox.Text.EndsWith(".png"))
            {
                exp0FileNameBox.BackColor = Color.Red;
            }
            else
            {
                exp0FileNameBox.BackColor = Color.White;
                Images[0] = Image.FromFile(exp0FileNameBox.Text);
                ImageLocations[0] = exp0FileNameBox.Text;
            }
        }

        private void Exp1FileNameBox_TextChanged(object sender, EventArgs e)
        {
            if (!File.Exists(exp1FileNameBox.Text) || !exp1FileNameBox.Text.EndsWith(".png"))
            {
                exp1FileNameBox.BackColor = Color.Red;
            }
            else
            {
                exp1FileNameBox.BackColor = Color.White;
                Images[1] = Image.FromFile(exp1FileNameBox.Text);
                ImageLocations[1] = exp1FileNameBox.Text;
            }
        }

        private void Exp2FileNameBox_TextChanged(object sender, EventArgs e)
        {
            if (!File.Exists(exp2FileNameBox.Text) || !exp2FileNameBox.Text.EndsWith(".png"))
            {
                exp2FileNameBox.BackColor = Color.Red;
            }
            else
            {
                exp2FileNameBox.BackColor = Color.White;
                Images[2] = Image.FromFile(exp2FileNameBox.Text);
                ImageLocations[2] = exp2FileNameBox.Text;
            }
        }

        private void Exp3FileNameBox_TextChanged(object sender, EventArgs e)
        {
            if (!File.Exists(exp3FileNameBox.Text) || !exp3FileNameBox.Text.EndsWith(".png"))
            {
                exp3FileNameBox.BackColor = Color.Red;
            }
            else
            {
                exp3FileNameBox.BackColor = Color.White;
                Images[3] = Image.FromFile(exp3FileNameBox.Text);
                ImageLocations[3] = exp3FileNameBox.Text;
            }
        }

        private void ExpNameTextBox_TextChanged(object sender, EventArgs e)
        {
            expNameTextBox.Text = expNameTextBox.Text.ToLower();
            if(expNameTextBox.Text.Length <= 0 ||
                expNameTextBox.Text.Contains(" ") ||
                expNameTextBox.Text.Contains("<") ||
                expNameTextBox.Text.Contains(">") ||
                expNameTextBox.Text.Contains(":") ||
                expNameTextBox.Text.Contains("\"") ||
                expNameTextBox.Text.Contains("/") ||
                expNameTextBox.Text.Contains("\\") ||
                expNameTextBox.Text.Contains("|") ||
                expNameTextBox.Text.Contains("?") ||
                expNameTextBox.Text.Contains("*") ||
                expNameTextBox.Text.Contains("_"))
            {
                expNameTextBox.BackColor = Color.Red;
                ExpressionName = null;
            }
            else
            {
                expNameTextBox.BackColor = Color.White;
                ExpressionName = expNameTextBox.Text;
            }
        }
    }
}
