
using SimplePNGTuber.Audio;
using SimplePNGTuber.Options;
using System;
using System.Text.Json;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace SimplePNGTuber.Model.WSEndpoints
{
    public class ModelWSEndpoint : WebSocketBehavior
    {
        public ModelWSEndpoint()
        {
            AudioMonitor.Instance.VoiceStateChanged += AnnounceVoiceStateChange;
        }

        protected override void OnOpen()
        {
            Send("model: " + Settings.Instance.ModelName);
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            if(e.Data.Equals("ping"))
            {
                Send("pong");
            }
        }

        public void AnnounceModelChange(string modelName)
        {
            Send("model: " + modelName);
        }

        public void AnnounceExpressionChange(string expressionName)
        {
            Send("expression: " + expressionName);
        }

        public void AnnounceAccessory(string accessoryName, bool active)
        {
            Send("accessory: " + accessoryName + " " + active);
        }

        public void AnnounceMuted(bool muted)
        {
            Send("speaking: " + false);
        }

        private void AnnounceVoiceStateChange(object sender, StateChangedEventArgs e)
        {
            Send("speaking: " + (e.VoiceActive && !AudioMonitor.Instance.Muted));
        }
    }
}
