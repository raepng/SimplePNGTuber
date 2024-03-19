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
        string editTmpFolder = Settings.Instance.ModelDir + Path.DirectorySeparatorChar + "modelEditorTmp" + Path.DirectorySeparatorChar;

        public EditModelForm()
        {
            InitializeComponent();
            expressionListBox.Items.Add(new Expression("neutral", new Image[4] { Resources.diego0, Resources.diego1, Resources.diego0, Resources.diego1 }, new string[4] { "", "", "", "" }));
        }

        public EditModelForm(PNGModel model)
        {
            InitializeComponent();
            PopulateForm(model);
        }

        private void PopulateForm(PNGModel model)
        {
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
                expressionListBox.Items.Add(new Expression(exp.Key, exp.Value, imageLocations));
            }
            foreach(var acc in model.accessories)
            {
                string imgLoc = editTmpFolder + "acc_" + acc.Key + ".png";
                acc.Value.Save(imgLoc);
                accessoryListBox.Items.Add(imgLoc);
            }
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
            Dictionary<string, Image[]> expressions = new Dictionary<string, Image[]>();
            foreach(Expression exp in expressionListBox.Items)
            {
                expressions.Add(exp.Name, exp.Images);
            }
            Dictionary<string, Image> accessories = new Dictionary<string, Image>();
            foreach(string acc in accessoryListBox.Items)
            {
                string accName = acc.Substring(acc.LastIndexOf(Path.DirectorySeparatorChar) + 1);
                accName = accName.Substring(0, accName.LastIndexOf('.'));
                accessories.Add(accName, Image.FromFile(acc));
            }
            if (PNGModelRegistry.Instance.SaveModel(modelNameTextBox.Text, expressions, accessories))
            {
                this.Close();
            }
        }

        private void EditModelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Thread thread = new Thread(DeleteEditTmpFolder);
            thread.Start();
        }

        private void DeleteEditTmpFolder()
        {
            bool deleted = false;
            while(!deleted)
            {
                try
                {
                    Directory.Delete(editTmpFolder, true);
                    deleted = true;
                }
                catch (Exception)
                {
                    deleted = false;
                    Thread.Sleep(1000);
                }
            }
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
