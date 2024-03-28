using SimplePNGTuber.Audio;
using SimplePNGTuber.Model;
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

namespace SimplePNGTuber.Options
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();

            this.dirText.Text = Settings.Instance.ModelDir;
            this.voiceThreshold.Value = (int)(Settings.Instance.VoiceThreshold * 100);
            this.voiceSmoothing.Value = (int)(Settings.Instance.VoiceSmoothing * 100);
            this.blinkFrequency.Value = (int)(Settings.Instance.BlinkFrequency * 100);
            this.micCombo.Items.Clear();
            foreach(DeviceInfo info in AudioMonitor.ListInputDevices())
            {
                micCombo.Items.Add(info);
            }
            micCombo.SelectedIndex = Settings.Instance.MicDevice + 1;
            bgColorPictureBox.BackColor = Settings.Instance.BackgroundColor;
            serverPort.Value = Settings.Instance.ServerPort;

            LoadModels();
            AudioMonitor.Instance.LevelChanged += HandleLevelChanged;
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
            var models = PNGModelRegistry.Instance.GetModelNames();
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
                Settings.Instance.ModelDir = dirText.Text;
                LoadModels();
            }
        }

        private void OptionsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Instance.ServerPort = (int) serverPort.Value;
            Settings.Instance.Save();
        }

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AudioMonitor.Instance.LevelChanged -= HandleLevelChanged;
        }

        private void ModelCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Instance.ModelName = modelCombo.SelectedItem as string;
        }

        private void VoiceThreshold_ValueChanged(object sender, EventArgs e)
        {
            Settings.Instance.VoiceThreshold = (double) voiceThreshold.Value / 100.0;
        }

        private void VoiceSmoothing_ValueChanged(object sender, EventArgs e)
        {
            Settings.Instance.VoiceSmoothing = (double) voiceSmoothing.Value / 100;
        }

        private void BlinkFrequency_ValueChanged(object sender, EventArgs e)
        {
            Settings.Instance.BlinkFrequency = (double) blinkFrequency.Value / 100.0;
        }

        private void MicCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Instance.MicDevice = micCombo.SelectedIndex - 1;
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
                Settings.Instance.BackgroundColor = bgColorDialog.Color;
                bgColorPictureBox.BackColor = bgColorDialog.Color;
            }
        }
    }
}
