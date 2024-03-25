using SimplePNGTuber.Model;
using SimplePNGTuber.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimplePNGTuber.Model.Endpoints
{
    public class SetModelEndpoint : Endpoint
    {
        public event EventHandler<ModelEventArgs> ModelChangeEvent;

        public async Task HandleRequest(HttpListenerRequest request, HttpListenerResponse response)
        {
            string urlPath = request.Url.AbsolutePath;

            string modelName = urlPath.Substring(urlPath.LastIndexOf('/') + 1).ToLower();
            if (PNGModelRegistry.Instance.GetModelNames().Contains(modelName))
            {
                ModelChangeEvent?.Invoke(this, new ModelEventArgs() { ModelName = modelName });
                response.StatusCode = 200;
                response.ContentType = "text/plain";
                await HttpServerUtil.WriteReponseAsync("", response);
            }
            else
            {
                response.StatusCode = 404;
                response.ContentType = "text/plain";
                await HttpServerUtil.WriteReponseAsync("404 Not Found", response);
            }

            response.Close();
        }
    }

    public class ModelEventArgs : EventArgs
    {
        public string ModelName { get; set; }
    }
}
