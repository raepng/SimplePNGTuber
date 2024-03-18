using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Text.Json;

namespace SimplePNGTuber
{
    public class Settings
    {
        private const string SettingsFile = "sptsettings.json";
        private SettingsInternal settings;

        public event EventHandler<SettingChangeEventArgs> SettingChanged;
        public string ModelDir
        {
            get => settings.modelDir;
            set
            {
                settings.modelDir = value;
                SettingChanged?.Invoke(this, new SettingChangeEventArgs() { ChangeType = SettingChangeType.MODEL });
            }
        }
        public string ModelName
        {
            get => settings.modelName;
            set
            {
                settings.modelName = value;
                SettingChanged?.Invoke(this, new SettingChangeEventArgs() { ChangeType = SettingChangeType.MODEL });
            }
        }
        public double VoiceThreshold
        {
            get => settings.voiceThreshold;
            set
            {
                settings.voiceThreshold = value;
                SettingChanged?.Invoke(this, new SettingChangeEventArgs() { ChangeType = SettingChangeType.VOICE });
            }
        }
        public double VoiceSmoothing
        {
            get => settings.voiceSmoothing;
            set
            {
                settings.voiceSmoothing = value;
                SettingChanged?.Invoke(this, new SettingChangeEventArgs() { ChangeType = SettingChangeType.VOICE });
            }
        }
        public double BlinkFrequency
        {
            get => settings.blinkFrequency;
            set
            {
                settings.blinkFrequency = value;
                SettingChanged?.Invoke(this, new SettingChangeEventArgs() { ChangeType = SettingChangeType.BLINK });
            }
        }
        public int MicDevice
        {
            get => settings.micDevice;
            set
            {
                settings.micDevice = value;
                SettingChanged?.Invoke(this, new SettingChangeEventArgs() { ChangeType = SettingChangeType.MIC });
            }
        }

        public int ServerPort
        {
            get => settings.serverPort;
            set
            {
                settings.serverPort = value;
                SettingChanged?.Invoke(this, new SettingChangeEventArgs() { ChangeType = SettingChangeType.SERVER });
            }
        }

        public Color BackgroundColor
        {
            get => (Color) new ColorConverter().ConvertFromString(settings.bgColor);
            set
            {
                settings.bgColor = new ColorConverter().ConvertToString(value);
                SettingChanged?.Invoke(this, new SettingChangeEventArgs() { ChangeType = SettingChangeType.BACKGROUND });
            }
        }

        public int AnimationHeight
        {
            get => settings.animationHeight;
            set
            {
                settings.animationHeight = value;
                SettingChanged?.Invoke(this, new SettingChangeEventArgs() { ChangeType = SettingChangeType.ANIMATION });
            }
        }

        public double AnimationSpeed
        {
            get => settings.animationSpeed;
            set
            {
                settings.animationSpeed = value;
                SettingChanged?.Invoke(this, new SettingChangeEventArgs() { ChangeType = SettingChangeType.ANIMATION });
            }
        }

        public List<string> GetModelNames()
        {
            if (string.IsNullOrEmpty(settings.modelDir))
            {
                return new List<string>();
            }
            List<string> models = new List<string>();
            foreach (string s in Directory.EnumerateFiles(settings.modelDir))
            {
                if (s.EndsWith(".zip"))
                {
                    string name = s.Replace(".zip", "");
                    name = name.Substring(name.LastIndexOf(Path.DirectorySeparatorChar) + 1).ToLower();
                    if (PNGTuberModel.Load(ModelDir, name) != PNGTuberModel.Empty)
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
                SettingsInternal res = JsonSerializer.Deserialize<SettingsInternal>(File.ReadAllText(SettingsFile));
                return new Settings() { settings = res };
            }
            else
            {
                return new Settings()
                {
                    settings = new SettingsInternal("", "", 0.05, 0.90, 0.03, 0, 8000, "#00ff00", 10, 0.1)
                };
            }
        }

        private static String ToHex(Color c) => $"#{c.R:X2}{c.G:X2}{c.B:X2}";

        internal void Save()
        {
            string json = JsonSerializer.Serialize(settings);
            File.WriteAllText(SettingsFile, json);
        }

        internal struct SettingsInternal
        {
            public string modelDir { get; set; }
            public string modelName { get; set; }
            public double voiceThreshold { get; set; }
            public double voiceSmoothing { get; set; }
            public double blinkFrequency { get; set; }
            public int micDevice { get; set; }
            public int serverPort { get; set; }
            public string bgColor { get; set; }
            public int animationHeight { get; set; }
            public double animationSpeed { get; set; }

            public SettingsInternal(string modelDir, string modelName,
                double voiceThreshold, double voiceSmoothing,
                double blinkFrequency, int micDevice,
                int serverPort, string bgColor,
                int animationHeight, double animationSpeed)
            {
                this.modelDir = modelDir;
                this.modelName = modelName;
                this.voiceThreshold = voiceThreshold;
                this.voiceSmoothing = voiceSmoothing;
                this.blinkFrequency = blinkFrequency;
                this.micDevice = micDevice;
                this.serverPort = serverPort;
                this.bgColor = bgColor;
                this.animationHeight = animationHeight;
                this.animationSpeed = animationSpeed;
            }
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
        BACKGROUND,
        ANIMATION
    }
}
