using SimplePNGTuber.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePNGTuber
{
    public partial class MainForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private readonly Random random = new Random();
        private readonly AudioMonitor monitor = new AudioMonitor();
        private readonly Settings settings = Settings.Load();
        private readonly HttpServer server;


        private PNGState state = PNGState.SILENT;
        private double blink = 0;

        public PNGTuberModel Model { get; private set; } = PNGTuberModel.Empty;
        public string Expression { get => Model.CurrentExpression; set => Model.CurrentExpression = value; }

        public HashSet<string> Accessories { get; } = new HashSet<string>();

        public MainForm()
        {
            InitializeComponent();

            monitor.VoiceStateChanged += VoiceStateChanged;
            settings.SettingChanged += SettingChanged;

            LoadFromSettings();
            UpdateImage();

            server = new HttpServer(settings, this);
            server.Start();
        }

        private void SettingChanged(object sender, SettingChangeEventArgs e)
        {
            switch (e.ChangeType)
            {
                case SettingChangeType.MODEL:
                    LoadModel();
                    UpdateImage();
                    break;
                case SettingChangeType.VOICE:
                    monitor.AcivationThreshold = settings.VoiceThreshold;
                    monitor.SmoothingAmount = settings.VoiceSmoothing;
                    break;
                case SettingChangeType.MIC:
                    monitor.RecordingDevice = settings.MicDevice;
                    break;
                case SettingChangeType.BACKGROUND:
                    this.BackColor = settings.BackgroundColor;
                    break;
            }
        }

        private void LoadFromSettings()
        {
            LoadModel();
            monitor.AcivationThreshold = settings.VoiceThreshold;
            monitor.RecordingDevice = settings.MicDevice;
            this.BackColor = settings.BackgroundColor;
        }

        private void LoadModel()
        {
            Model = PNGTuberModel.Load(settings.ModelDir, settings.ModelName);
            var modelSilent = Model.GetState(PNGState.SILENT, new List<string>());
            notifyIcon.Icon = ConvertToIco(modelSilent, modelSilent.Width);
            this.Size = new Size(modelSilent.Width, modelSilent.Height);
        }

        private void VoiceStateChanged(object sender, StateChangedEventArgs e)
        {
            if(e.VoiceActive)
            {
                if(state == PNGState.BLINKING)
                {
                    state = PNGState.SPEAKING_BLINKING;
                }
                else
                {
                    state = PNGState.SPEAKING;
                }
            } else
            {
                if (state == PNGState.SPEAKING_BLINKING)
                {
                    state = PNGState.BLINKING;
                }
                else
                {
                    state = PNGState.SILENT;
                }
            }
            UpdateImage();
        }

        private void BlinkTimer_Tick(object sender, EventArgs e)
        {
            if(random.Next(2) == 1)
            {
                blink += settings.BlinkFrequency;
            }
            if(blink > 1)
            {
                blink = 0;
                if(state == PNGState.SILENT)
                {
                    state = PNGState.BLINKING;
                }
                else if(state == PNGState.SPEAKING)
                {
                    state = PNGState.SPEAKING_BLINKING;
                }
                UpdateImage();
            }
            else if(state == PNGState.BLINKING)
            {
                state = PNGState.SILENT;
                UpdateImage();
            }
            else if(state == PNGState.SPEAKING_BLINKING)
            {
                state = PNGState.SPEAKING;
                UpdateImage();
            }
        }

        private void UpdateImage()
        {
            pngTuberImageBox.BackgroundImage = Model.GetState(state, Accessories);
        }

        private void PngTuberImageBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
            else if(e.Button == MouseButtons.Right)
            {
                contextMenuStrip.Show(this, e.Location);
            }
        }

        private Icon ConvertToIco(Image img, int size)
        {
            Icon icon;
            using (var msImg = new MemoryStream())
            using (var msIco = new MemoryStream())
            {
                img.Save(msImg, ImageFormat.Png);
                using (var bw = new BinaryWriter(msIco))
                {
                    bw.Write((short)0);           //0-1 reserved
                    bw.Write((short)1);           //2-3 image type, 1 = icon, 2 = cursor
                    bw.Write((short)1);           //4-5 number of images
                    bw.Write((byte)size);         //6 image width
                    bw.Write((byte)size);         //7 image height
                    bw.Write((byte)0);            //8 number of colors
                    bw.Write((byte)0);            //9 reserved
                    bw.Write((short)0);           //10-11 color planes
                    bw.Write((short)32);          //12-13 bits per pixel
                    bw.Write((int)msImg.Length);  //14-17 size of image data
                    bw.Write(22);                 //18-21 offset of image data
                    bw.Write(msImg.ToArray());    // write image data
                    bw.Flush();
                    bw.Seek(0, SeekOrigin.Begin);
                    icon = new Icon(msIco);
                }
            }
            return icon;
        }

        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new OptionsForm(settings, monitor).ShowDialog();
        }

        private void CreateModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CreateModelForm(settings).ShowDialog();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            server.Stop();
            Application.Exit();
        }
    }
}
