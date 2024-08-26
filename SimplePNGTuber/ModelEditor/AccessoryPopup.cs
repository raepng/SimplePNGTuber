using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SimplePNGTuber.ModelEditor
{
    public partial class AccessoryPopup : Form
    {
        public string AccessoryName { get; private set; }
        public Image Image { get; private set; }
        public string ImageLocation { get; private set; }

        public int Layer { get; private set; } = 1;

        public AccessoryPopup()
        {
            InitializeComponent();
        }

        public AccessoryPopup(EditAccessory accessory)
        {
            InitializeComponent();

            this.accNameTextBox.Text = accessory.Name;
            this.Image = accessory.Image;
            this.accFileNameBox.Text = accessory.ImageLocation;
            this.imageLayerSelector.Value = accessory.Layer;
        }

        private void AccNameTextBox_TextChanged(object sender, EventArgs e)
        {
            accNameTextBox.Text = accNameTextBox.Text.ToLower();
            if (accNameTextBox.Text.Length <= 0 ||
                accNameTextBox.Text.Contains(" ") ||
                accNameTextBox.Text.Contains("<") ||
                accNameTextBox.Text.Contains(">") ||
                accNameTextBox.Text.Contains(":") ||
                accNameTextBox.Text.Contains("\"") ||
                accNameTextBox.Text.Contains("/") ||
                accNameTextBox.Text.Contains("\\") ||
                accNameTextBox.Text.Contains("|") ||
                accNameTextBox.Text.Contains("?") ||
                accNameTextBox.Text.Contains("*") ||
                accNameTextBox.Text.Contains("_"))
            {
                accNameTextBox.BackColor = Color.Red;
                AccessoryName = null;
            }
            else
            {
                accNameTextBox.BackColor = Color.White;
                AccessoryName = accNameTextBox.Text;
            }
        }

        private void BtnChooseFile_Click(object sender, EventArgs e)
        {
            var res = openImageDialogue.ShowDialog();
            if (res == DialogResult.OK)
            {
                accFileNameBox.Text = openImageDialogue.FileName;
            }
        }

        private void accFileNameBox_TextChanged(object sender, EventArgs e)
        {
            if (!File.Exists(accFileNameBox.Text) || !accFileNameBox.Text.EndsWith(".png"))
            {
                accFileNameBox.BackColor = Color.Red;
            }
            else
            {
                accFileNameBox.BackColor = Color.White;
                Image = Image.FromFile(accFileNameBox.Text);
                ImageLocation = accFileNameBox.Text;
            }
        }

        private void ImageLayerSelector_ValueChanged(object sender, EventArgs e)
        {
            Layer = (int) imageLayerSelector.Value;
        }
    }
}
