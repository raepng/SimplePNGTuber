using SimplePNGTuber.Model;
using SimplePNGTuber.Options;
using SimplePNGTuber.Server.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimplePNGTuber.Server
{
    public class HttpServer
    {
        private static HttpServer instance;

        public static HttpServer Instance => instance ?? (instance = new HttpServer());

        private HttpListener listener;

        private bool runServer = false;

        private Dictionary<string, Endpoint> endpoints = new Dictionary<string, Endpoint>();

        public HttpServer()
        {
            Settings.Instance.SettingChanged += SettingChanged;

            WebUIEndpoint webUI = new WebUIEndpoint();
            this.AddEndpoint("/webui/", webUI);
        }

        private void SettingChanged(object sender, SettingChangeEventArgs e)
        {
            if(e.ChangeType == SettingChangeType.SERVER)
            {
                if(runServer)
                {
                    this.Stop();
                    this.Start();
                }
            }
        }

        public void AddEndpoint(string endpointUrl, Endpoint endpoint)
        {
            endpoints.Add(endpointUrl, endpoint);
        }

        public async Task HandleIncomingConnections()
        {
            while (runServer)
            {
                HttpListenerContext ctx = await listener.GetContextAsync();

                HttpListenerRequest req = ctx.Request;
                HttpListenerResponse resp = ctx.Response;

                var urlPath = req.Url.AbsolutePath;

                bool handled = false;
                foreach(var endpoint in endpoints)
                {
                    if(urlPath.StartsWith(endpoint.Key))
                    {
                        try
                        {
                            await endpoint.Value.HandleRequest(req, resp);
                        }
                        catch (Exception ex)
                        {
                            resp.StatusCode = 500;
                            resp.ContentType = "text/plain";
                            await HttpServerUtil.WriteReponseAsync("500 Internal Server Error: " + ex.Message, resp);
                        }
                        handled = true;
                        break;
                    }
                }

                if(!handled)
                {
                    resp.StatusCode = 400;
                    resp.ContentType = "text/plain";
                    await HttpServerUtil.WriteReponseAsync("400 Bad Request", resp);
                }

                resp.Close();
            }
        }


        public void Start()
        {
            listener = new HttpListener();
            listener.Prefixes.Add("http://127.0.0.1:" + Settings.Instance.ServerPort + "/");
            listener.Start();

            runServer = true;

            _ = HandleIncomingConnections();
        }

        public void Stop()
        {
            runServer = false;
            listener.Close();
        }
    }

    public interface Endpoint
    {
        Task HandleRequest(HttpListenerRequest request, HttpListenerResponse response);
    }
}
