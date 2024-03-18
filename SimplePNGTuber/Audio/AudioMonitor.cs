﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Utils;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace SimplePNGTuber
{
    public class AudioMonitor
    {
		public event EventHandler<StateChangedEventArgs> VoiceStateChanged;
		public event EventHandler<LevelChangedEventArgs> LevelChanged;

		public double AcivationThreshold { get; set; } = 0.05;
		public double SmoothingAmount { get; set; } = 0;
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

		public AudioMonitor()
        {
			
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
			double peakPercentSmoothed = (peakPercent * (1 - SmoothingAmount)) + (previousLevel * SmoothingAmount);
			LevelChanged?.Invoke(this, new LevelChangedEventArgs() { LevelRaw = peakPercent, LevelSmoothed = peakPercentSmoothed });
			previousLevel = peakPercentSmoothed;
			if(peakPercentSmoothed > AcivationThreshold && !VoiceActive)
            {
				VoiceStateChanged?.Invoke(this, new StateChangedEventArgs() { VoiceActive = this.VoiceActive = true });
            }
			else if(peakPercentSmoothed < AcivationThreshold && VoiceActive)
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
