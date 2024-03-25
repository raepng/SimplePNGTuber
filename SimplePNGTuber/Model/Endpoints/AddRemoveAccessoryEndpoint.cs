using SimplePNGTuber.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimplePNGTuber.Model.Endpoints
{
    public class AddRemoveAccessoryEndpoint : Endpoint
    {
        public event EventHandler<AccessoryEventArgs> AccessoryAddEvent;
        public event EventHandler<AccessoryEventArgs> AccessoryRemoveEvent;

        public async Task HandleRequest(HttpListenerRequest request, HttpListenerResponse response)
        {
            string urlPath = request.Url.AbsolutePath;
            bool add = urlPath.Replace("/accessory", "").StartsWith("/add/");
            bool remove = urlPath.Replace("/accessory", "").StartsWith("/remove/");
            string accessoryName = urlPath.Substring(urlPath.LastIndexOf('/') + 1).ToLower();
            if (add || remove)
            {
                if (PNGModelRegistry.Instance.ActiveModel.GetAccessories().Contains(accessoryName))
                {
                    if(add)
                    {
                        AccessoryAddEvent?.Invoke(this, new AccessoryEventArgs() { AccessoryName = accessoryName });
                    }
                    else
                    {
                        AccessoryRemoveEvent?.Invoke(this, new AccessoryEventArgs() { AccessoryName = accessoryName });
                    }
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
            }
            else
            {
                response.StatusCode = 400;
                response.ContentType = "text/plain";
                await HttpServerUtil.WriteReponseAsync("400 Bad Request", response);
            }
            response.Close();
        }
    }

    public class AccessoryEventArgs : EventArgs
    {
        public string AccessoryName { get; set; }
    }
}
