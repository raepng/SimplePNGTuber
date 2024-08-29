using SimplePNGTuber.Model;
using SimplePNGTuber.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SimplePNGTuber.ModelEditor
{
    public partial class EditModelForm : Form
    {
        public EditModelForm()
        {
            InitializeComponent();
            expressionListBox.Items.Add(new EditExpression("neutral", new Image[4] { Resources.diego0, Resources.diego1, Resources.diego0, Resources.diego1 }, new string[4] { "", "", "", "" }));
        }

        public EditModelForm(PNGModel model)
        {
            InitializeComponent();
            PopulateForm(model);
        }

        private void PopulateForm(PNGModel model)
        {
            string editTmpFolder = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()) + Path.DirectorySeparatorChar;

            modelNameTextBox.Text = model.Name;
            Directory.CreateDirectory(editTmpFolder);
            foreach (var exp in model.expressions)
            {
                string[] imageLocations = new string[4];
                for(int i = 0; i < imageLocations.Length; i++)
                {
                    string imgLoc = editTmpFolder + "exp_" + exp.Key + "_" + i + ".png";
                    exp.Value[i].Save(imgLoc);
                    imageLocations[i] = imgLoc;
                }
                expressionListBox.Items.Add(new EditExpression(exp.Key, exp.Value, imageLocations));
            }
            foreach(var acc in model.accessories)
            {
                string imgLoc = editTmpFolder + acc.Key + ".png";
                acc.Value.Image.Image.Save(imgLoc);
                accessoryListBox.Items.Add(new EditAccessory(acc.Value.Name, acc.Value.Image.Image, acc.Value.Image.Layer, imgLoc));
            }
        }

        private void ExpressionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(expressionListBox.SelectedIndex >= 0)
            {
                if(((EditExpression)expressionListBox.SelectedItem).Name.Equals("neutral"))
                {
                    removeExpButton.Enabled = false;
                }
                else
                {
                    removeExpButton.Enabled = true;
                }
                previewPictureBox.Image = ((EditExpression)expressionListBox.SelectedItem).Images[0];
                previewPictureBox.Size = previewPictureBox.Image.Size;
            }
            else
            {
                removeExpButton.Enabled = false;
            }
        }

        private void AddExpButton_Click(object sender, EventArgs e)
        {
            ExpressionPopup expressionPopup = new ExpressionPopup(EditExpression.Empty);
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
                ExpressionPopup expressionPopup = new ExpressionPopup((EditExpression) expressionListBox.SelectedItem);
                expressionPopup.ShowDialog();
                expressionListBox.Items.RemoveAt(expressionListBox.SelectedIndex);
                AddExpression(expressionPopup);
            }
        }

        private void AddExpression(ExpressionPopup expressionPopup)
        {
            foreach (EditExpression expression in expressionListBox.Items)
            {
                if (expression.Name.Equals(expressionPopup.ExpressionName))
                {
                    MessageBox.Show("Expression name already in use!");
                    return;
                }
            }
            expressionListBox.Items.Add(new EditExpression(expressionPopup.ExpressionName, expressionPopup.Images, expressionPopup.ImageLocations));
        }

        private void AddAccButton_Click(object sender, EventArgs e)
        {
            AccessoryPopup popup = new AccessoryPopup();
            popup.ShowDialog();
            AddAccessory(popup);
        }

        private void AddAccessory(AccessoryPopup accPopup)
        {
            foreach (EditAccessory accessory in accessoryListBox.Items)
            {
                if (accessory.Name.Equals(accPopup.AccessoryName))
                {
                    MessageBox.Show("Expression name already in use!");
                    return;
                }
            }
            accessoryListBox.Items.Add(new EditAccessory(accPopup.AccessoryName, accPopup.Image, accPopup.Layer, accPopup.ImageLocation));
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
                previewPictureBox.Image = ((EditAccessory) accessoryListBox.SelectedItem).Image;
                previewPictureBox.Size = previewPictureBox.Image.Size;
                removeAccButton.Enabled = true;
            }
            else
            {
                removeAccButton.Enabled = false;
            }
        }

        private void accessoryListBox_DoubleClick(object sender, EventArgs e)
        {
            if (accessoryListBox.SelectedIndex < 0)
            {
                return;
            }
            else
            {
                AccessoryPopup accessoryPopup = new AccessoryPopup((EditAccessory) accessoryListBox.SelectedItem);
                accessoryPopup.ShowDialog();
                accessoryListBox.Items.RemoveAt(accessoryListBox.SelectedIndex);
                AddAccessory(accessoryPopup);
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
                modelNameTextBox.Text.Contains("*"))
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
            var expressions = new Dictionary<string, Image[]>();
            foreach(EditExpression exp in expressionListBox.Items)
            {
                expressions.Add(exp.Name, exp.Images);
            }
            var accessories = new Dictionary<string, Image>();
            var settings = new PNGModelSettings();
            foreach(EditAccessory acc in accessoryListBox.Items)
            {
                accessories.Add(acc.Name, acc.Image);
                settings.AccessoryLayers.Add(acc.Name, acc.Layer);
            }
            if (PNGModelRegistry.Instance.SaveModel(modelNameTextBox.Text, settings, expressions, accessories))
            {
                this.Close();
            }
        }
    }

    public struct EditExpression
    {
        internal static EditExpression Empty => new EditExpression("",
            new Image[4] { Resources.diego0, Resources.diego1, Resources.diego0, Resources.diego1 },
            new string[4] { "", "", "", "" });

        public string Name;
        public Image[] Images;
        public string[] ImageLocations;

        public EditExpression(string name, Image[] images, string[] imageLocations)
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

    public struct EditAccessory
    {
        public string Name;
        public Image Image;
        public int Layer;
        public string ImageLocation;

        public EditAccessory(string name, Image image, int layer, string imageLocation)
        {
            this.Name = name;
            this.Image = image;
            this.Layer = layer;
            this.ImageLocation = imageLocation;
        }

        public override string ToString()
        {
            return Name + " | Layer " + this.Layer + " | " + this.ImageLocation;
        }
    }
}
