namespace SimplePNGTuber.ModelEditor
{
    partial class AccessoryPopup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.accNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.accFileNameBox = new System.Windows.Forms.TextBox();
            this.imageLayerSelector = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.openImageDialogue = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.imageLayerSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // accNameTextBox
            // 
            this.accNameTextBox.Location = new System.Drawing.Point(105, 6);
            this.accNameTextBox.Name = "accNameTextBox";
            this.accNameTextBox.Size = new System.Drawing.Size(511, 20);
            this.accNameTextBox.TabIndex = 15;
            this.accNameTextBox.TextChanged += new System.EventHandler(this.AccNameTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Accessory Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "File Path";
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(580, 30);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(36, 23);
            this.btnChooseFile.TabIndex = 17;
            this.btnChooseFile.Text = "...";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.BtnChooseFile_Click);
            // 
            // accFileNameBox
            // 
            this.accFileNameBox.Location = new System.Drawing.Point(105, 32);
            this.accFileNameBox.Name = "accFileNameBox";
            this.accFileNameBox.Size = new System.Drawing.Size(469, 20);
            this.accFileNameBox.TabIndex = 16;
            this.accFileNameBox.TextChanged += new System.EventHandler(this.accFileNameBox_TextChanged);
            // 
            // imageLayerSelector
            // 
            this.imageLayerSelector.Location = new System.Drawing.Point(105, 58);
            this.imageLayerSelector.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.imageLayerSelector.Name = "imageLayerSelector";
            this.imageLayerSelector.Size = new System.Drawing.Size(509, 20);
            this.imageLayerSelector.TabIndex = 19;
            this.imageLayerSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.imageLayerSelector.ValueChanged += new System.EventHandler(this.ImageLayerSelector_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Image Layer";
            // 
            // openImageDialogue
            // 
            this.openImageDialogue.DefaultExt = "png";
            this.openImageDialogue.FileName = "Expression.png";
            this.openImageDialogue.Filter = "PNG Files|*.png";
            this.openImageDialogue.Title = "Select an expression file";
            // 
            // AccessoryPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 91);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageLayerSelector);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.accFileNameBox);
            this.Controls.Add(this.accNameTextBox);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AccessoryPopup";
            this.Text = "AccessoryPopup";
            ((System.ComponentModel.ISupportInitialize)(this.imageLayerSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox accNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.TextBox accFileNameBox;
        private System.Windows.Forms.NumericUpDown imageLayerSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openImageDialogue;
    }
}