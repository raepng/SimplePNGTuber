using SimplePNGTuber.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace SimplePNGTuber.Server
{
    public class WebSocketServer
    {
        private static WebSocketServer instance;
        public static WebSocketServer Instance => instance ?? (instance = new WebSocketServer());

        private bool runServer = false;

        private WebSocketSharp.Server.WebSocketServer server;

        private readonly Dictionary<string, Func<WebSocketBehavior>> services = new Dictionary<string, Func<WebSocketBehavior>>();

        public WebSocketServer()
        {
            server = new WebSocketSharp.Server.WebSocketServer(Settings.Instance.WSServerPort);
            Settings.Instance.SettingChanged += SettingChanged;
        }

        internal void AddWebSocketService(string path, Func<WebSocketBehavior> service)
        {
            server.AddWebSocketService(path, service);
            this.services.Add(path, service);
        }

        private void SettingChanged(object sender, SettingChangeEventArgs e)
        {
            if (e.ChangeType == SettingChangeType.SERVER)
            {
                if (runServer)
                {
                    this.Stop();
                    server = new WebSocketSharp.Server.WebSocketServer(Settings.Instance.WSServerPort);
                    foreach (KeyValuePair<string, Func<WebSocketBehavior>> pair in services)
                    {
                        server.AddWebSocketService(pair.Key, pair.Value);
                    }
                    this.Start();
                }
            }
        }

        public void Start()
        {
            runServer = true;
            server.Start();
        }

        public void Stop()
        {
            runServer = false;
            server.Stop();
        }
    }
}
