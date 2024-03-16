using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Drawing;

namespace SimplePNGTuber
{
    public class Settings
    {
        private const string SettingsFile = "sptsettings";
        private string modelDir = "";
        private string modelName = "";
        private double voiceThreshold = 0.05;
        private double blinkFrequency = 0.03;
        private int micDevice = 0;
        private int serverPort = 8000;
        private Color bgColor = Color.Cyan;

        public event EventHandler<SettingChangeEventArgs> SettingChanged;
        public string ModelDir
        {
            get => modelDir;
            set
            {
                modelDir = value;
                SettingChanged?.Invoke(this, new SettingChangeEventArgs() { ChangeType = SettingChangeType.MODEL });
            }
        }
        public string ModelName
        {
            get => modelName;
            set
            {
                modelName = value;
                SettingChanged?.Invoke(this, new SettingChangeEventArgs() { ChangeType = SettingChangeType.MODEL });
            }
        }
        public double VoiceThreshold
        {
            get => voiceThreshold;
            set
            {
                voiceThreshold = value;
                SettingChanged?.Invoke(this, new SettingChangeEventArgs() { ChangeType = SettingChangeType.VOICE });
            }
        }
        public double BlinkFrequency
        {
            get => blinkFrequency;
            set
            {
                blinkFrequency = value;
                SettingChanged?.Invoke(this, new SettingChangeEventArgs() { ChangeType = SettingChangeType.BLINK });
            }
        }
        public int MicDevice
        {
            get => micDevice;
            set
            {
                micDevice = value;
                SettingChanged?.Invoke(this, new SettingChangeEventArgs() { ChangeType = SettingChangeType.MIC });
            }
        }

        public int ServerPort
        {
            get => serverPort;
            set
            {
                serverPort = value;
                SettingChanged?.Invoke(this, new SettingChangeEventArgs() { ChangeType = SettingChangeType.SERVER });
            }
        }

        public Color BackgroundColor
        {
            get => bgColor;
            set
            {
                bgColor = value;
                SettingChanged?.Invoke(this, new SettingChangeEventArgs() { ChangeType = SettingChangeType.BACKGROUND });
            }
        }

        public List<string> GetModelNames()
        {
            if (string.IsNullOrEmpty(modelDir))
            {
                return new List<string>();
            }
            List<string> models = new List<string>();
            foreach (string s in Directory.EnumerateFiles(modelDir))
            {
                if (s.EndsWith(".zip"))
                {
                    string name = s.Replace(".zip", "");
                    name = name.Substring(name.LastIndexOf(Path.DirectorySeparatorChar) + 1).ToLower();
                    if(PNGTuberModel.Load(ModelDir, name) != PNGTuberModel.Empty)
                    {
                        models.Add(name);
                    }
                }
            }
            return models;
        }

        internal static Settings Load()
        {
            if (File.Exists(SettingsFile))
            {
                string[] settingsStrings = File.ReadAllLines(SettingsFile);
                return new Settings()
                {
                    modelDir = settingsStrings[0],
                    modelName = settingsStrings[1],
                    voiceThreshold = double.Parse(settingsStrings[2]),
                    blinkFrequency = double.Parse(settingsStrings[3]),
                    micDevice = int.Parse(settingsStrings[4]),
                    serverPort = int.Parse(settingsStrings[5]),
                    bgColor = (Color) new ColorConverter().ConvertFromString(settingsStrings[6]),
                };
            }
            else
            {
                return new Settings();
            }
        }

        private static String ToHex(Color c) => $"#{c.R:X2}{c.G:X2}{c.B:X2}";

        internal void Save()
        {
            string settingsString = modelDir + "\n" + modelName + "\n" + voiceThreshold + "\n" + blinkFrequency + "\n" + micDevice + "\n" + serverPort + "\n" + ToHex(bgColor);
            File.WriteAllText(SettingsFile, settingsString);
        }
    }

    public class SettingChangeEventArgs : EventArgs
    {
        public SettingChangeType ChangeType { get; set; }
    }

    public enum SettingChangeType
    {
        MODEL,
        VOICE,
        MIC,
        BLINK,
        SERVER,
        BACKGROUND
    }
}
