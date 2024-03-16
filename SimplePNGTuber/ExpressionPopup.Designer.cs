namespace SimplePNGTuber
{
    partial class ExpressionPopup
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
            this.label1 = new System.Windows.Forms.Label();
            this.exp0FileNameBox = new System.Windows.Forms.TextBox();
            this.btnExp0 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.exp1FileNameBox = new System.Windows.Forms.TextBox();
            this.exp2FileNameBox = new System.Windows.Forms.TextBox();
            this.exp3FileNameBox = new System.Windows.Forms.TextBox();
            this.btnExp1 = new System.Windows.Forms.Button();
            this.btnExp2 = new System.Windows.Forms.Button();
            this.btnExp3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.expNameTextBox = new System.Windows.Forms.TextBox();
            this.openImageDialogue = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Not Blinking, Not Speaking";
            // 
            // exp0FileNameBox
            // 
            this.exp0FileNameBox.Location = new System.Drawing.Point(153, 55);
            this.exp0FileNameBox.Name = "exp0FileNameBox";
            this.exp0FileNameBox.Size = new System.Drawing.Size(422, 20);
            this.exp0FileNameBox.TabIndex = 1;
            this.exp0FileNameBox.TextChanged += new System.EventHandler(this.Exp0FileNameBox_TextChanged);
            // 
            // btnExp0
            // 
            this.btnExp0.Location = new System.Drawing.Point(581, 53);
            this.btnExp0.Name = "btnExp0";
            this.btnExp0.Size = new System.Drawing.Size(36, 23);
            this.btnExp0.TabIndex = 2;
            this.btnExp0.Text = "...";
            this.btnExp0.UseVisualStyleBackColor = true;
            this.btnExp0.Click += new System.EventHandler(this.BtnExp0_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Not Blinking, Speaking";
            // 
            // exp1FileNameBox
            // 
            this.exp1FileNameBox.Location = new System.Drawing.Point(153, 81);
            this.exp1FileNameBox.Name = "exp1FileNameBox";
            this.exp1FileNameBox.Size = new System.Drawing.Size(422, 20);
            this.exp1FileNameBox.TabIndex = 4;
            this.exp1FileNameBox.TextChanged += new System.EventHandler(this.Exp1FileNameBox_TextChanged);
            // 
            // exp2FileNameBox
            // 
            this.exp2FileNameBox.Location = new System.Drawing.Point(153, 107);
            this.exp2FileNameBox.Name = "exp2FileNameBox";
            this.exp2FileNameBox.Size = new System.Drawing.Size(422, 20);
            this.exp2FileNameBox.TabIndex = 5;
            this.exp2FileNameBox.TextChanged += new System.EventHandler(this.Exp2FileNameBox_TextChanged);
            // 
            // exp3FileNameBox
            // 
            this.exp3FileNameBox.Location = new System.Drawing.Point(153, 133);
            this.exp3FileNameBox.Name = "exp3FileNameBox";
            this.exp3FileNameBox.Size = new System.Drawing.Size(422, 20);
            this.exp3FileNameBox.TabIndex = 6;
            this.exp3FileNameBox.TextChanged += new System.EventHandler(this.Exp3FileNameBox_TextChanged);
            // 
            // btnExp1
            // 
            this.btnExp1.Location = new System.Drawing.Point(581, 79);
            this.btnExp1.Name = "btnExp1";
            this.btnExp1.Size = new System.Drawing.Size(36, 23);
            this.btnExp1.TabIndex = 7;
            this.btnExp1.Text = "...";
            this.btnExp1.UseVisualStyleBackColor = true;
            this.btnExp1.Click += new System.EventHandler(this.BtnExp1_Click);
            // 
            // btnExp2
            // 
            this.btnExp2.Location = new System.Drawing.Point(581, 105);
            this.btnExp2.Name = "btnExp2";
            this.btnExp2.Size = new System.Drawing.Size(36, 23);
            this.btnExp2.TabIndex = 8;
            this.btnExp2.Text = "...";
            this.btnExp2.UseVisualStyleBackColor = true;
            this.btnExp2.Click += new System.EventHandler(this.BtnExp2_Click);
            // 
            // btnExp3
            // 
            this.btnExp3.Location = new System.Drawing.Point(581, 131);
            this.btnExp3.Name = "btnExp3";
            this.btnExp3.Size = new System.Drawing.Size(36, 23);
            this.btnExp3.TabIndex = 9;
            this.btnExp3.Text = "...";
            this.btnExp3.UseVisualStyleBackColor = true;
            this.btnExp3.Click += new System.EventHandler(this.BtnExp3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Blinking, Speaking";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Blinking, Not Speaking";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Expression Name";
            // 
            // expNameTextBox
            // 
            this.expNameTextBox.Location = new System.Drawing.Point(153, 10);
            this.expNameTextBox.Name = "expNameTextBox";
            this.expNameTextBox.Size = new System.Drawing.Size(464, 20);
            this.expNameTextBox.TabIndex = 13;
            this.expNameTextBox.TextChanged += new System.EventHandler(this.ExpNameTextBox_TextChanged);
            // 
            // openImageDialogue
            // 
            this.openImageDialogue.DefaultExt = "png";
            this.openImageDialogue.FileName = "Expression.png";
            this.openImageDialogue.Filter = "PNG Files|*.png";
            this.openImageDialogue.Title = "Select an expression file";
            // 
            // ExpressionPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 166);
            this.Controls.Add(this.expNameTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExp3);
            this.Controls.Add(this.btnExp2);
            this.Controls.Add(this.btnExp1);
            this.Controls.Add(this.exp3FileNameBox);
            this.Controls.Add(this.exp2FileNameBox);
            this.Controls.Add(this.exp1FileNameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExp0);
            this.Controls.Add(this.exp0FileNameBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ExpressionPopup";
            this.Text = "Customize Expression";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox exp0FileNameBox;
        private System.Windows.Forms.Button btnExp0;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox exp1FileNameBox;
        private System.Windows.Forms.TextBox exp2FileNameBox;
        private System.Windows.Forms.TextBox exp3FileNameBox;
        private System.Windows.Forms.Button btnExp1;
        private System.Windows.Forms.Button btnExp2;
        private System.Windows.Forms.Button btnExp3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox expNameTextBox;
        private System.Windows.Forms.OpenFileDialog openImageDialogue;
    }
}