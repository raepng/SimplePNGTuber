namespace SimplePNGTuber.Options
{
    partial class OptionsForm
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
            this.dirText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchDirBtn = new System.Windows.Forms.Button();
            this.modelCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.voiceThreshold = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.blinkFrequency = new System.Windows.Forms.NumericUpDown();
            this.micCombo = new System.Windows.Forms.ComboBox();
            this.modelDirBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.bgColorPictureBox = new System.Windows.Forms.PictureBox();
            this.selectColorBtn = new System.Windows.Forms.Button();
            this.bgColorDialog = new System.Windows.Forms.ColorDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.serverPort = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.voiceSmoothing = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.smoothedLevelProgress = new System.Windows.Forms.ProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.rawLevelProgress = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.voiceThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blinkFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverPort)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.voiceSmoothing)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dirText
            // 
            this.dirText.Location = new System.Drawing.Point(101, 13);
            this.dirText.Name = "dirText";
            this.dirText.Size = new System.Drawing.Size(634, 20);
            this.dirText.TabIndex = 0;
            this.dirText.TextChanged += new System.EventHandler(this.DirText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Model Directory";
            // 
            // searchDirBtn
            // 
            this.searchDirBtn.Location = new System.Drawing.Point(741, 11);
            this.searchDirBtn.Name = "searchDirBtn";
            this.searchDirBtn.Size = new System.Drawing.Size(29, 23);
            this.searchDirBtn.TabIndex = 2;
            this.searchDirBtn.Text = "...";
            this.searchDirBtn.UseVisualStyleBackColor = true;
            this.searchDirBtn.Click += new System.EventHandler(this.SearchDirBtn_Click);
            // 
            // modelCombo
            // 
            this.modelCombo.FormattingEnabled = true;
            this.modelCombo.Location = new System.Drawing.Point(101, 39);
            this.modelCombo.Name = "modelCombo";
            this.modelCombo.Size = new System.Drawing.Size(669, 21);
            this.modelCombo.TabIndex = 3;
            this.modelCombo.SelectedIndexChanged += new System.EventHandler(this.ModelCombo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Model";
            // 
            // voiceThreshold
            // 
            this.voiceThreshold.Location = new System.Drawing.Point(101, 46);
            this.voiceThreshold.Name = "voiceThreshold";
            this.voiceThreshold.Size = new System.Drawing.Size(669, 20);
            this.voiceThreshold.TabIndex = 5;
            this.voiceThreshold.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.voiceThreshold.ValueChanged += new System.EventHandler(this.VoiceThreshold_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Voice Threshold";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Blink Frequency";
            // 
            // blinkFrequency
            // 
            this.blinkFrequency.Location = new System.Drawing.Point(101, 66);
            this.blinkFrequency.Name = "blinkFrequency";
            this.blinkFrequency.Size = new System.Drawing.Size(669, 20);
            this.blinkFrequency.TabIndex = 8;
            this.blinkFrequency.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.blinkFrequency.ValueChanged += new System.EventHandler(this.BlinkFrequency_ValueChanged);
            // 
            // micCombo
            // 
            this.micCombo.FormattingEnabled = true;
            this.micCombo.Location = new System.Drawing.Point(101, 19);
            this.micCombo.Name = "micCombo";
            this.micCombo.Size = new System.Drawing.Size(669, 21);
            this.micCombo.TabIndex = 9;
            this.micCombo.SelectedIndexChanged += new System.EventHandler(this.MicCombo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 356);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Background Color";
            // 
            // bgColorPictureBox
            // 
            this.bgColorPictureBox.BackColor = System.Drawing.Color.Cyan;
            this.bgColorPictureBox.Location = new System.Drawing.Point(113, 352);
            this.bgColorPictureBox.Name = "bgColorPictureBox";
            this.bgColorPictureBox.Size = new System.Drawing.Size(21, 21);
            this.bgColorPictureBox.TabIndex = 12;
            this.bgColorPictureBox.TabStop = false;
            // 
            // selectColorBtn
            // 
            this.selectColorBtn.Location = new System.Drawing.Point(140, 352);
            this.selectColorBtn.Name = "selectColorBtn";
            this.selectColorBtn.Size = new System.Drawing.Size(648, 23);
            this.selectColorBtn.TabIndex = 13;
            this.selectColorBtn.Text = "Select Color";
            this.selectColorBtn.UseVisualStyleBackColor = true;
            this.selectColorBtn.Click += new System.EventHandler(this.SelectColorBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 383);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Server Port";
            // 
            // serverPort
            // 
            this.serverPort.Location = new System.Drawing.Point(113, 381);
            this.serverPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.serverPort.Name = "serverPort";
            this.serverPort.Size = new System.Drawing.Size(675, 20);
            this.serverPort.TabIndex = 15;
            this.serverPort.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.voiceSmoothing);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.smoothedLevelProgress);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.rawLevelProgress);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.micCombo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.voiceThreshold);
            this.groupBox1.Location = new System.Drawing.Point(12, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 165);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Microphone";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Voice Smoothing";
            // 
            // voiceSmoothing
            // 
            this.voiceSmoothing.Location = new System.Drawing.Point(101, 72);
            this.voiceSmoothing.Name = "voiceSmoothing";
            this.voiceSmoothing.Size = new System.Drawing.Size(669, 20);
            this.voiceSmoothing.TabIndex = 15;
            this.voiceSmoothing.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.voiceSmoothing.ValueChanged += new System.EventHandler(this.VoiceSmoothing_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Level Smoothed";
            // 
            // smoothedLevelProgress
            // 
            this.smoothedLevelProgress.Location = new System.Drawing.Point(101, 98);
            this.smoothedLevelProgress.Name = "smoothedLevelProgress";
            this.smoothedLevelProgress.Size = new System.Drawing.Size(669, 23);
            this.smoothedLevelProgress.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Level Raw";
            // 
            // rawLevelProgress
            // 
            this.rawLevelProgress.Location = new System.Drawing.Point(101, 127);
            this.rawLevelProgress.Name = "rawLevelProgress";
            this.rawLevelProgress.Size = new System.Drawing.Size(669, 23);
            this.rawLevelProgress.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Input Device";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dirText);
            this.groupBox2.Controls.Add(this.searchDirBtn);
            this.groupBox2.Controls.Add(this.modelCombo);
            this.groupBox2.Controls.Add(this.blinkFrequency);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 100);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Model";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 552);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.serverPort);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.selectColorBtn);
            this.Controls.Add(this.bgColorPictureBox);
            this.Controls.Add(this.label6);
            this.Name = "OptionsForm";
            this.Text = "OptionsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OptionsForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.voiceThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blinkFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverPort)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.voiceSmoothing)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dirText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button searchDirBtn;
        private System.Windows.Forms.ComboBox modelCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown voiceThreshold;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown blinkFrequency;
        private System.Windows.Forms.ComboBox micCombo;
        private System.Windows.Forms.FolderBrowserDialog modelDirBrowser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox bgColorPictureBox;
        private System.Windows.Forms.Button selectColorBtn;
        private System.Windows.Forms.ColorDialog bgColorDialog;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown serverPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ProgressBar smoothedLevelProgress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ProgressBar rawLevelProgress;
        private System.Windows.Forms.NumericUpDown voiceSmoothing;
        private System.Windows.Forms.Label label10;
    }
}