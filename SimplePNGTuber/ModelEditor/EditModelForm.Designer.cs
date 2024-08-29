namespace SimplePNGTuber.ModelEditor
{
    partial class EditModelForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addExpButton = new System.Windows.Forms.Button();
            this.removeExpButton = new System.Windows.Forms.Button();
            this.expressionListBox = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.addAccButton = new System.Windows.Forms.Button();
            this.removeAccButton = new System.Windows.Forms.Button();
            this.accessoryListBox = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.previewPictureBox = new System.Windows.Forms.PictureBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.modelNameTextBox = new System.Windows.Forms.TextBox();
            this.accessoryFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 35);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 412);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(391, 406);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addExpButton);
            this.groupBox1.Controls.Add(this.removeExpButton);
            this.groupBox1.Controls.Add(this.expressionListBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 197);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Expressions";
            // 
            // addExpButton
            // 
            this.addExpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addExpButton.Location = new System.Drawing.Point(141, 168);
            this.addExpButton.Name = "addExpButton";
            this.addExpButton.Size = new System.Drawing.Size(104, 23);
            this.addExpButton.TabIndex = 2;
            this.addExpButton.Text = "Add Expression";
            this.addExpButton.UseVisualStyleBackColor = true;
            this.addExpButton.Click += new System.EventHandler(this.AddExpButton_Click);
            // 
            // removeExpButton
            // 
            this.removeExpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeExpButton.Enabled = false;
            this.removeExpButton.Location = new System.Drawing.Point(251, 168);
            this.removeExpButton.Name = "removeExpButton";
            this.removeExpButton.Size = new System.Drawing.Size(128, 23);
            this.removeExpButton.TabIndex = 1;
            this.removeExpButton.Text = "Remove Expression";
            this.removeExpButton.UseVisualStyleBackColor = true;
            this.removeExpButton.Click += new System.EventHandler(this.RemoveExpButton_Click);
            // 
            // expressionListBox
            // 
            this.expressionListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expressionListBox.FormattingEnabled = true;
            this.expressionListBox.Location = new System.Drawing.Point(3, 16);
            this.expressionListBox.Name = "expressionListBox";
            this.expressionListBox.Size = new System.Drawing.Size(379, 147);
            this.expressionListBox.TabIndex = 0;
            this.expressionListBox.SelectedIndexChanged += new System.EventHandler(this.ExpressionListBox_SelectedIndexChanged);
            this.expressionListBox.DoubleClick += new System.EventHandler(this.ExpressionListBox_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.addAccButton);
            this.groupBox2.Controls.Add(this.removeAccButton);
            this.groupBox2.Controls.Add(this.accessoryListBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 206);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(385, 197);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Accessories";
            // 
            // addAccButton
            // 
            this.addAccButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addAccButton.Location = new System.Drawing.Point(147, 168);
            this.addAccButton.Name = "addAccButton";
            this.addAccButton.Size = new System.Drawing.Size(98, 23);
            this.addAccButton.TabIndex = 2;
            this.addAccButton.Text = "Add Accessory";
            this.addAccButton.UseVisualStyleBackColor = true;
            this.addAccButton.Click += new System.EventHandler(this.AddAccButton_Click);
            // 
            // removeAccButton
            // 
            this.removeAccButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeAccButton.Enabled = false;
            this.removeAccButton.Location = new System.Drawing.Point(251, 168);
            this.removeAccButton.Name = "removeAccButton";
            this.removeAccButton.Size = new System.Drawing.Size(128, 23);
            this.removeAccButton.TabIndex = 1;
            this.removeAccButton.Text = "Remove Accessory";
            this.removeAccButton.UseVisualStyleBackColor = true;
            this.removeAccButton.Click += new System.EventHandler(this.RemoveAccButton_Click);
            // 
            // accessoryListBox
            // 
            this.accessoryListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.accessoryListBox.FormattingEnabled = true;
            this.accessoryListBox.Location = new System.Drawing.Point(3, 16);
            this.accessoryListBox.Name = "accessoryListBox";
            this.accessoryListBox.Size = new System.Drawing.Size(379, 147);
            this.accessoryListBox.TabIndex = 0;
            this.accessoryListBox.SelectedIndexChanged += new System.EventHandler(this.AccessoryListBox_SelectedIndexChanged);
            this.accessoryListBox.DoubleClick += new System.EventHandler(this.accessoryListBox_DoubleClick);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.previewPictureBox, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.saveBtn, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(400, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(391, 406);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // previewPictureBox
            // 
            this.previewPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.previewPictureBox.Location = new System.Drawing.Point(3, 3);
            this.previewPictureBox.Name = "previewPictureBox";
            this.previewPictureBox.Size = new System.Drawing.Size(100, 50);
            this.previewPictureBox.TabIndex = 0;
            this.previewPictureBox.TabStop = false;
            // 
            // saveBtn
            // 
            this.saveBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.saveBtn.Enabled = false;
            this.saveBtn.Location = new System.Drawing.Point(3, 380);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(385, 23);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.modelNameTextBox, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(794, 26);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(77, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Model Name";
            // 
            // modelNameTextBox
            // 
            this.modelNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modelNameTextBox.Location = new System.Drawing.Point(86, 3);
            this.modelNameTextBox.Name = "modelNameTextBox";
            this.modelNameTextBox.Size = new System.Drawing.Size(705, 20);
            this.modelNameTextBox.TabIndex = 1;
            this.modelNameTextBox.TextChanged += new System.EventHandler(this.ModelNameTextBox_TextChanged);
            // 
            // accessoryFileDialog
            // 
            this.accessoryFileDialog.DefaultExt = "png";
            this.accessoryFileDialog.FileName = "accessory.png";
            this.accessoryFileDialog.Filter = "PNG Files|*.png";
            // 
            // EditModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EditModelForm";
            this.Text = "Edit Model";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox modelNameTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox expressionListBox;
        private System.Windows.Forms.Button addExpButton;
        private System.Windows.Forms.Button removeExpButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.PictureBox previewPictureBox;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button addAccButton;
        private System.Windows.Forms.Button removeAccButton;
        private System.Windows.Forms.ListBox accessoryListBox;
        private System.Windows.Forms.OpenFileDialog accessoryFileDialog;
    }
}