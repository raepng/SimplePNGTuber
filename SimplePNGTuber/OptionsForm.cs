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
        private readonly AudioMonitor monitor;

        public OptionsForm(Settings settings, AudioMonitor monitor)
        {
            InitializeComponent();

            this.settings = settings;
            this.monitor = monitor;

            this.dirText.Text = settings.ModelDir;
            this.voiceThreshold.Value = (int)(settings.VoiceThreshold * 100);
            this.voiceSmoothing.Value = (int)(settings.VoiceSmoothing * 100);
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
            monitor.LevelChanged += HandleLevelChanged;
        }

        private void HandleLevelChanged(object sender, LevelChangedEventArgs e)
        {
            Action updateLevels = () =>
            {
                rawLevelProgress.Value = (int)(e.LevelRaw * 100);
                smoothedLevelProgress.Value = (int)(e.LevelSmoothed * 100);
            };
            try
            {
                this.Invoke(updateLevels);
            }
            catch (Exception)
            {
                // discard
            }
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

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            monitor.LevelChanged -= HandleLevelChanged;
        }

        private void ModelCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.ModelName = modelCombo.SelectedItem as string;
        }

        private void VoiceThreshold_ValueChanged(object sender, EventArgs e)
        {
            settings.VoiceThreshold = (double) voiceThreshold.Value / 100.0;
        }

        private void VoiceSmoothing_ValueChanged(object sender, EventArgs e)
        {
            settings.VoiceSmoothing = (double) voiceSmoothing.Value / 100;
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

        private void SelectColorBtn_Click(object sender, EventArgs e)
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
