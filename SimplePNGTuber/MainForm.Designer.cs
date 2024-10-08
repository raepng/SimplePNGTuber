﻿namespace SimplePNGTuber
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.pngTuberImageBox = new System.Windows.Forms.PictureBox();
            this.blinkTimer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCurrentModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pngTuberImageBox)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pngTuberImageBox
            // 
            this.pngTuberImageBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pngTuberImageBox.BackColor = System.Drawing.Color.Transparent;
            this.pngTuberImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pngTuberImageBox.InitialImage = null;
            this.pngTuberImageBox.Location = new System.Drawing.Point(0, 0);
            this.pngTuberImageBox.Name = "pngTuberImageBox";
            this.pngTuberImageBox.Size = new System.Drawing.Size(800, 450);
            this.pngTuberImageBox.TabIndex = 0;
            this.pngTuberImageBox.TabStop = false;
            this.pngTuberImageBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PngTuberImageBox_MouseDown);
            // 
            // blinkTimer
            // 
            this.blinkTimer.Enabled = true;
            this.blinkTimer.Tick += new System.EventHandler(this.BlinkTimer_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Options For SimplePNGTuber";
            this.notifyIcon.BalloonTipTitle = "SimplePNGTuber";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Text = "SimplePNGTuber";
            this.notifyIcon.Visible = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.createModelToolStripMenuItem,
            this.editCurrentModelToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(175, 92);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // createModelToolStripMenuItem
            // 
            this.createModelToolStripMenuItem.Name = "createModelToolStripMenuItem";
            this.createModelToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.createModelToolStripMenuItem.Text = "Create Model";
            this.createModelToolStripMenuItem.Click += new System.EventHandler(this.CreateModelToolStripMenuItem_Click);
            // 
            // editCurrentModelToolStripMenuItem
            // 
            this.editCurrentModelToolStripMenuItem.Name = "editCurrentModelToolStripMenuItem";
            this.editCurrentModelToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.editCurrentModelToolStripMenuItem.Text = "Edit Current Model";
            this.editCurrentModelToolStripMenuItem.Click += new System.EventHandler(this.EditCurrentModelToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // animationTimer
            // 
            this.animationTimer.Enabled = true;
            this.animationTimer.Interval = 15;
            this.animationTimer.Tick += new System.EventHandler(this.AnimationTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pngTuberImageBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "SimplePNGTuber";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)(this.pngTuberImageBox)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pngTuberImageBox;
        private System.Windows.Forms.Timer blinkTimer;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createModelToolStripMenuItem;
        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.ToolStripMenuItem editCurrentModelToolStripMenuItem;
    }
}

