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
        public const int WSServerPort = 8001;

        private static WebSocketServer instance;
        public static WebSocketServer Instance => instance ?? (instance = new WebSocketServer());

        private WebSocketSharp.Server.WebSocketServer server;

        public WebSocketSharp.Server.WebSocketServer Server => server;

        public WebSocketServer()
        {
            server = new WebSocketSharp.Server.WebSocketServer(WSServerPort);
        }

        public void Start()
        {
            server.Start();
        }

        public void Stop()
        {
            server.Stop();
        }
    }
}
