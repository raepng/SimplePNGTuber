﻿namespace SimplePNGTuber
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
            this.label5 = new System.Windows.Forms.Label();
            this.modelDirBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.bgColorPictureBox = new System.Windows.Forms.PictureBox();
            this.selectColorBtn = new System.Windows.Forms.Button();
            this.bgColorDialog = new System.Windows.Forms.ColorDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.serverPort = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.voiceThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blinkFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverPort)).BeginInit();
            this.SuspendLayout();
            // 
            // dirText
            // 
            this.dirText.Location = new System.Drawing.Point(113, 9);
            this.dirText.Name = "dirText";
            this.dirText.Size = new System.Drawing.Size(640, 20);
            this.dirText.TabIndex = 0;
            this.dirText.TextChanged += new System.EventHandler(this.DirText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Model Directory";
            // 
            // searchDirBtn
            // 
            this.searchDirBtn.Location = new System.Drawing.Point(759, 7);
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
            this.modelCombo.Location = new System.Drawing.Point(113, 36);
            this.modelCombo.Name = "modelCombo";
            this.modelCombo.Size = new System.Drawing.Size(675, 21);
            this.modelCombo.TabIndex = 3;
            this.modelCombo.SelectedIndexChanged += new System.EventHandler(this.ModelCombo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Model";
            // 
            // voiceThreshold
            // 
            this.voiceThreshold.Location = new System.Drawing.Point(113, 64);
            this.voiceThreshold.Name = "voiceThreshold";
            this.voiceThreshold.Size = new System.Drawing.Size(675, 20);
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
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Voice Threshold";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Blink Frequency";
            // 
            // blinkFrequency
            // 
            this.blinkFrequency.Location = new System.Drawing.Point(113, 90);
            this.blinkFrequency.Name = "blinkFrequency";
            this.blinkFrequency.Size = new System.Drawing.Size(675, 20);
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
            this.micCombo.Location = new System.Drawing.Point(113, 116);
            this.micCombo.Name = "micCombo";
            this.micCombo.Size = new System.Drawing.Size(675, 21);
            this.micCombo.TabIndex = 9;
            this.micCombo.SelectedIndexChanged += new System.EventHandler(this.MicCombo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Microphone";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Background Color";
            // 
            // bgColorPictureBox
            // 
            this.bgColorPictureBox.BackColor = System.Drawing.Color.Cyan;
            this.bgColorPictureBox.Location = new System.Drawing.Point(113, 143);
            this.bgColorPictureBox.Name = "bgColorPictureBox";
            this.bgColorPictureBox.Size = new System.Drawing.Size(21, 21);
            this.bgColorPictureBox.TabIndex = 12;
            this.bgColorPictureBox.TabStop = false;
            // 
            // selectColorBtn
            // 
            this.selectColorBtn.Location = new System.Drawing.Point(140, 143);
            this.selectColorBtn.Name = "selectColorBtn";
            this.selectColorBtn.Size = new System.Drawing.Size(648, 23);
            this.selectColorBtn.TabIndex = 13;
            this.selectColorBtn.Text = "Select Color";
            this.selectColorBtn.UseVisualStyleBackColor = true;
            this.selectColorBtn.Click += new System.EventHandler(this.selectColorBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Server Port";
            // 
            // serverPort
            // 
            this.serverPort.Location = new System.Drawing.Point(113, 172);
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
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.serverPort);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.selectColorBtn);
            this.Controls.Add(this.bgColorPictureBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.micCombo);
            this.Controls.Add(this.blinkFrequency);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.voiceThreshold);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.modelCombo);
            this.Controls.Add(this.searchDirBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dirText);
            this.Name = "OptionsForm";
            this.Text = "OptionsForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OptionsForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.voiceThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blinkFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverPort)).EndInit();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FolderBrowserDialog modelDirBrowser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox bgColorPictureBox;
        private System.Windows.Forms.Button selectColorBtn;
        private System.Windows.Forms.ColorDialog bgColorDialog;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown serverPort;
    }
}