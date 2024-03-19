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
        private readonly Settings settings;
        private readonly MainForm mainForm;

        private HttpListener listener;

        private bool runServer = false;

        #region Events
        public event EventHandler<MutedEventArgs> MutedEvent;
        #endregion

        public HttpServer(Settings settings, MainForm mainForm)
        {
            this.settings = settings;
            this.mainForm = mainForm;
            settings.SettingChanged += SettingChanged;
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

        public async Task HandleIncomingConnections()
        {
            while (runServer)
            {
                HttpListenerContext ctx = await listener.GetContextAsync();

                HttpListenerRequest req = ctx.Request;
                HttpListenerResponse resp = ctx.Response;

                var urlPath = req.Url.AbsolutePath;

                string response;

                if (req.Url.AbsolutePath.StartsWith("/setmodel/"))
                {
                    string modelName = urlPath.Substring(urlPath.LastIndexOf('/') + 1).ToLower();
                    if(settings.GetModelNames().Contains(modelName))
                    {
                        settings.ModelName = modelName;
                        response = "";
                        resp.StatusCode = 200;
                        resp.ContentType = "text/plain";
                    }
                    else
                    {
                        response = "404 Not Found";
                        resp.StatusCode = 404;
                        resp.ContentType = "text/plain";
                    }
                }
                else if (req.Url.AbsolutePath.StartsWith("/setexpression/"))
                {
                    string expressionName = urlPath.Substring(urlPath.LastIndexOf('/') + 1).ToLower();
                    if(mainForm.Model.GetExpressions().Contains(expressionName))
                    {
                        mainForm.Expression = expressionName;
                        response = "";
                        resp.StatusCode = 200;
                    }
                    else
                    {
                        response = "404 Not Found";
                        resp.StatusCode = 404;
                        resp.ContentType = "text/plain";
                    }
                }
                else if (req.Url.AbsolutePath.StartsWith("/addaccessory/") || req.Url.AbsolutePath.StartsWith("/removeaccessory/"))
                {
                    bool add = req.Url.AbsolutePath.StartsWith("/addaccessory/");
                    string accessoryName = urlPath.Substring(urlPath.LastIndexOf('/') + 1).ToLower();
                    if(mainForm.Model.GetAccessories().Contains(accessoryName))
                    {
                        if(add)
                        {
                            mainForm.Accessories.Add(accessoryName);
                        }
                        else
                        {
                            mainForm.Accessories.Remove(accessoryName);
                        }
                        response = "";
                        resp.StatusCode = 200;
                    }
                    else
                    {
                        response = "404 Not Found";
                        resp.StatusCode = 404;
                        resp.ContentType = "text/plain";
                    }
                }
                else if (req.Url.AbsolutePath.StartsWith("/mute") || req.Url.AbsolutePath.StartsWith("/unmute"))
                {
                    bool mute = req.Url.AbsolutePath.StartsWith("/mute");
                    MutedEvent?.Invoke(this, new MutedEventArgs() { Muted = mute });
                    response = "";
                    resp.StatusCode = 200;
                }
                else
                {
                    response = "400 Bad Request";
                    resp.StatusCode = 400;
                    resp.ContentType = "text/plain";
                }

                byte[] data = Encoding.UTF8.GetBytes(response);
                resp.ContentEncoding = Encoding.UTF8;
                resp.ContentLength64 = data.LongLength;

                await resp.OutputStream.WriteAsync(data, 0, data.Length);

                resp.Close();
            }
        }


        public void Start()
        {
            listener = new HttpListener();
            listener.Prefixes.Add("http://127.0.0.1:" + settings.ServerPort + "/");
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

    public class MutedEventArgs : EventArgs
    {
        public bool Muted { get; set; }
    }
}
