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
    public partial class OptionsForm : Form
    {
        private readonly Settings settings;

        public OptionsForm(Settings settings)
        {
            InitializeComponent();
            this.settings = settings;
            this.dirText.Text = settings.ModelDir;
            this.voiceThreshold.Value = (int)(settings.VoiceThreshold * 100);
            this.blinkFrequency.Value = (int)(settings.BlinkFrequency * 100);
            this.micCombo.Items.Clear();
            foreach(DeviceInfo info in AudioMonitor.ListInputDevices())
            {
                micCombo.Items.Add(info);
            }
            micCombo.SelectedIndex = settings.MicDevice + 1;
            bgColorPictureBox.BackColor = settings.BackgroundColor;
            serverPort.Value = settings.ServerPort;

            LoadModels();
        }

        private void LoadModels()
        {
            var models = settings.GetModelNames();
            modelCombo.Items.Clear();
            modelCombo.Items.AddRange(models.ToArray());
        }

        private void DirText_TextChanged(object sender, EventArgs e)
        {
            if(!Directory.Exists(dirText.Text))
            {
                dirText.BackColor = Color.OrangeRed;
            } else
            {
                dirText.BackColor = Color.White;
                settings.ModelDir = dirText.Text;
                LoadModels();
            }
        }

        private void OptionsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            settings.ServerPort = (int) serverPort.Value;
            settings.Save();
        }

        private void ModelCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.ModelName = modelCombo.SelectedItem as string;
        }

        private void VoiceThreshold_ValueChanged(object sender, EventArgs e)
        {
            settings.VoiceThreshold = (double) voiceThreshold.Value / 100.0;
        }

        private void BlinkFrequency_ValueChanged(object sender, EventArgs e)
        {
            settings.BlinkFrequency = (double) blinkFrequency.Value / 100.0;
        }

        private void MicCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.MicDevice = micCombo.SelectedIndex - 1;
        }

        private void SearchDirBtn_Click(object sender, EventArgs e)
        {
            var res = modelDirBrowser.ShowDialog();
            if(res == DialogResult.OK)
            {
                dirText.Text = modelDirBrowser.SelectedPath;
            }
        }

        private void selectColorBtn_Click(object sender, EventArgs e)
        {
            var res = bgColorDialog.ShowDialog();
            if(res == DialogResult.OK)
            {
                settings.BackgroundColor = bgColorDialog.Color;
                bgColorPictureBox.BackColor = bgColorDialog.Color;
            }
        }
    }
}
