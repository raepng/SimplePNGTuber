﻿using System;
using System.IO;
using System.Drawing;
using System.Text.Json;

namespace SimplePNGTuber.Options
{
    public class Settings
    {
        private const string SettingsFile = "sptsettings.json";

        private static Settings instance;

        public static Settings Instance => instance ?? (instance = Settings.Load());

        private SettingsInternal settings;

        public event EventHandler<SettingChangeEventArgs> SettingChanged;
        public string ModelDir
        {
            get => settings.modelDir;
            set
            {
                settings.modelDir = value;
                SettingChanged?.Invoke(this, new SettingChangeEventArgs() { ChangeType = SettingChangeType.MODELDIR });
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

        public double ModelScale
        {
            get => settings.modelScale;
            set
            {
                settings.modelScale = value;
                SettingChanged?.Invoke(this, new SettingChangeEventArgs() { ChangeType = SettingChangeType.MODEL });
            }
        }

        public bool AnimateModel
        {
            get => settings.animateModel;
            set
            {
                settings.animateModel = value;
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

        public int WSServerPort
        {
            get => settings.wsServerPort;
            set
            {
                settings.wsServerPort = value;
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

        private Settings()
        {

        }

        private static Settings Load()
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
                    settings = new SettingsInternal("", "", 1, true, 0.05, 0.75, 0.03, 0, 8000, 8001, "#00ff00", 10, 0.1)
                };
            }
        }

        internal void Save()
        {
            string json = JsonSerializer.Serialize(settings);
            File.WriteAllText(SettingsFile, json);
        }

        internal struct SettingsInternal
        {
            public string modelDir { get; set; }
            public string modelName { get; set; }
            public double modelScale { get; set; }
            public bool animateModel { get; set; }
            public double voiceThreshold { get; set; }
            public double voiceSmoothing { get; set; }
            public double blinkFrequency { get; set; }
            public int micDevice { get; set; }
            public int serverPort { get; set; }

            public int wsServerPort { get; set; }
            public string bgColor { get; set; }
            public int animationHeight { get; set; }
            public double animationSpeed { get; set; }

            public SettingsInternal(string modelDir, string modelName, double modelScale, bool animateModel,
                double voiceThreshold, double voiceSmoothing,
                double blinkFrequency, int micDevice,
                int serverPort, int wsServerPort, string bgColor,
                int animationHeight, double animationSpeed)
            {
                this.modelDir = modelDir;
                this.modelName = modelName;
                this.modelScale = modelScale;
                this.animateModel = animateModel;
                this.voiceThreshold = voiceThreshold;
                this.voiceSmoothing = voiceSmoothing;
                this.blinkFrequency = blinkFrequency;
                this.micDevice = micDevice;
                this.serverPort = serverPort;
                this.wsServerPort = wsServerPort;
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
        MODELDIR,
        VOICE,
        MIC,
        BLINK,
        SERVER,
        BACKGROUND,
        ANIMATION
    }
}
