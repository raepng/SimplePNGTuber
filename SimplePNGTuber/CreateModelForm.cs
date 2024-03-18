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
    public partial class CreateModelForm : Form
    {
        private readonly Settings settings;

        public CreateModelForm(Settings settings)
        {
            this.settings = settings;
            InitializeComponent();
            expressionListBox.Items.Add(new Expression("neutral", new Image[4] { Resources.diego0, Resources.diego1, Resources.diego0, Resources.diego1 }, new string[4] { "", "", "", "" }));
        }

        private void ExpressionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(expressionListBox.SelectedIndex >= 0)
            {
                if(((Expression)expressionListBox.SelectedItem).Name.Equals("neutral"))
                {
                    removeExpButton.Enabled = false;
                }
                else
                {
                    removeExpButton.Enabled = true;
                }
                previewPictureBox.Image = ((Expression)expressionListBox.SelectedItem).Images[0];
                previewPictureBox.Size = previewPictureBox.Image.Size;
            }
            else
            {
                removeExpButton.Enabled = false;
            }
        }

        private void AddExpButton_Click(object sender, EventArgs e)
        {
            ExpressionPopup expressionPopup = new ExpressionPopup(Expression.Empty);
            expressionPopup.ShowDialog();
            AddExpression(expressionPopup);
        }

        private void RemoveExpButton_Click(object sender, EventArgs e)
        {
            expressionListBox.Items.RemoveAt(expressionListBox.SelectedIndex);
        }

        private void ExpressionListBox_DoubleClick(object sender, EventArgs e)
        {
            if (expressionListBox.SelectedIndex < 0)
            {
                return;
            }
            else
            {
                ExpressionPopup expressionPopup = new ExpressionPopup((Expression) expressionListBox.SelectedItem);
                expressionPopup.ShowDialog();
                expressionListBox.Items.RemoveAt(expressionListBox.SelectedIndex);
                AddExpression(expressionPopup);
            }
        }

        private void AddExpression(ExpressionPopup expressionPopup)
        {
            foreach (Expression expression in expressionListBox.Items)
            {
                if (expression.Name.Equals(expressionPopup.ExpressionName))
                {
                    MessageBox.Show("Expression name already in use!");
                    return;
                }
            }
            expressionListBox.Items.Add(new Expression(expressionPopup.ExpressionName, expressionPopup.Images, expressionPopup.ImageLocations));
        }

        private void AddAccButton_Click(object sender, EventArgs e)
        {
            var res = accessoryFileDialog.ShowDialog();
            if(res == DialogResult.OK)
            {
                accessoryListBox.Items.Add(accessoryFileDialog.FileName);
            }
        }

        private void RemoveAccButton_Click(object sender, EventArgs e)
        {
            if (accessoryListBox.SelectedIndex >= 0)
            {
                accessoryListBox.Items.RemoveAt(accessoryListBox.SelectedIndex);
            }
        }

        private void AccessoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(accessoryListBox.SelectedIndex >= 0)
            {
                previewPictureBox.Image = Image.FromFile((string) accessoryListBox.SelectedItem);
                previewPictureBox.Size = previewPictureBox.Image.Size;
                removeAccButton.Enabled = true;
            }
            else
            {
                removeAccButton.Enabled = false;
            }
        }

        private void ModelNameTextBox_TextChanged(object sender, EventArgs e)
        {
            modelNameTextBox.Text = modelNameTextBox.Text.ToLower();
            if (modelNameTextBox.Text.Length <= 0 ||
                modelNameTextBox.Text.Contains(" ") ||
                modelNameTextBox.Text.Contains("<") ||
                modelNameTextBox.Text.Contains(">") ||
                modelNameTextBox.Text.Contains(":") ||
                modelNameTextBox.Text.Contains("\"") ||
                modelNameTextBox.Text.Contains("/") ||
                modelNameTextBox.Text.Contains("\\") ||
                modelNameTextBox.Text.Contains("|") ||
                modelNameTextBox.Text.Contains("?") ||
                modelNameTextBox.Text.Contains("*") ||
                modelNameTextBox.Text.Contains("_"))
            {
                modelNameTextBox.BackColor = Color.Red;
                saveBtn.Enabled = false;
            }
            else
            {
                modelNameTextBox.BackColor = Color.White;
                saveBtn.Enabled = true;
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Dictionary<string, Image[]> expressions = new Dictionary<string, Image[]>();
            foreach(Expression exp in expressionListBox.Items)
            {
                expressions.Add(exp.Name, exp.Images);
            }
            Dictionary<string, Image> accessories = new Dictionary<string, Image>();
            foreach(string acc in accessoryListBox.Items)
            {
                accessories.Add(acc.Substring(acc.LastIndexOf(Path.DirectorySeparatorChar) + 1, acc.LastIndexOf('.')), Image.FromFile(acc));
            }
            PNGTuberModel.Save(settings.ModelDir, modelNameTextBox.Text, expressions, accessories);
            this.Close();
        }
    }

    public struct Expression
    {
        internal static readonly Expression Empty = new Expression("",
            new Image[4] { Resources.diego0, Resources.diego1, Resources.diego0, Resources.diego1 },
            new string[4] { "", "", "", "" });

        public string Name;
        public Image[] Images;
        public string[] ImageLocations;

        public Expression(string name, Image[] images, string[] imageLocations)
        {
            this.Name = name;
            this.Images = images;
            this.ImageLocations = imageLocations;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
