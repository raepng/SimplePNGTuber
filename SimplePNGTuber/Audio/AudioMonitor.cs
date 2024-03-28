using System;
using System.Collections.Generic;
using NAudio.Wave;
using SimplePNGTuber.Audio.Endpoints;
using SimplePNGTuber.Model;
using SimplePNGTuber.Options;
using SimplePNGTuber.Server;

namespace SimplePNGTuber.Audio
{
    public class AudioMonitor
    {
		private static AudioMonitor instance;

		public static AudioMonitor Instance => instance ?? (instance = new AudioMonitor());

		public event EventHandler<StateChangedEventArgs> VoiceStateChanged;
		public event EventHandler<LevelChangedEventArgs> LevelChanged;

		public bool Muted { get; private set; }

		public int RecordingDevice
		{
			set
            {
				if(Microphone != null)
                {
					Microphone.StopRecording();
					Microphone.Dispose();
                }
				Microphone = new WaveInEvent
				{
					DeviceNumber = value,
					WaveFormat = new WaveFormat(rate: 48000, bits: 16, channels: 1),
					BufferMilliseconds = 50
				};
				Microphone.DataAvailable += ProcessData;
				Microphone.StartRecording();
			}
		}

        public WaveFormat WaveFormat => throw new NotImplementedException();

		private double previousLevel = 0;
        private bool VoiceActive = false;
		private WaveInEvent Microphone;

		private AudioMonitor()
        {
			MuteEndpoint muteEndpoint = new MuteEndpoint();
			HttpServer.Instance.AddEndpoint("/mute/", muteEndpoint);
			muteEndpoint.MutedEvent += MuteChanged;
		}

        private void MuteChanged(object sender, MutedEventArgs e)
        {
            Muted = e.Muted;
        }

        private void ProcessData(object sender, WaveInEventArgs e)
        {
			const float maxValue = 32767;
			int peakValue = 0;
			int bytesPerSample = 2;
			for (int index = 0; index < e.BytesRecorded; index += bytesPerSample)
			{
				int value = BitConverter.ToInt16(e.Buffer, index);
				peakValue = Math.Max(peakValue, value);
			}

			double peakPercent = peakValue / maxValue;
			double peakPercentSmoothed = (peakPercent * (1 - Settings.Instance.VoiceSmoothing)) + (previousLevel * Settings.Instance.VoiceSmoothing);
			LevelChanged?.Invoke(this, new LevelChangedEventArgs() { LevelRaw = peakPercent, LevelSmoothed = peakPercentSmoothed });
			previousLevel = peakPercentSmoothed;
			
			if (Muted)
			{
				if (VoiceActive)
				{
                    VoiceStateChanged?.Invoke(this, new StateChangedEventArgs() { VoiceActive = this.VoiceActive = false });
                }
				return;
			}

			if (peakPercentSmoothed > Settings.Instance.VoiceThreshold && !VoiceActive)
            {
				VoiceStateChanged?.Invoke(this, new StateChangedEventArgs() { VoiceActive = this.VoiceActive = true });
            }
			else if (peakPercentSmoothed < Settings.Instance.VoiceThreshold && VoiceActive)
            {
				VoiceStateChanged?.Invoke(this, new StateChangedEventArgs() { VoiceActive = this.VoiceActive = false });
			}
		}

        public static IEnumerable<DeviceInfo> ListInputDevices()
		{
			var inputDevices = new List<DeviceInfo>();
			for (var n = -1; n < WaveIn.DeviceCount; n++)
			{
				var caps = WaveIn.GetCapabilities(n);
				inputDevices.Add(new DeviceInfo(caps.ProductName, n));
			}

			return inputDevices;
		}
    }

	public readonly struct DeviceInfo
	{
		public string DeviceName { get; }
		public int DeviceNumber { get; }

		public DeviceInfo(string deviceName, int deviceNumber)
		{
			this.DeviceName = deviceName;
			this.DeviceNumber = deviceNumber;
		}

		public override string ToString()
		{
			return this.DeviceName;
		}
	}

	public class StateChangedEventArgs : EventArgs
    {
		public bool VoiceActive { get; set; }
    }

	public class LevelChangedEventArgs : EventArgs
	{
		public double LevelRaw { get; set; }
		public double LevelSmoothed { get; set; }
	}
}
