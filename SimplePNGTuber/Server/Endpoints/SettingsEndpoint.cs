using SimplePNGTuber.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimplePNGTuber.Server.Endpoints
{
    internal class SettingsEndpoint : Endpoint
    {
        public async Task HandleRequest(HttpListenerRequest request, HttpListenerResponse response)
        {
            string settings = Resources.Settings;
            settings = settings.Replace("%blinkFrequency%", (Settings.Instance.BlinkFrequency + "").Replace(',', '.'));
            settings = settings.Replace("%serverPort%", Settings.Instance.ServerPort + "");
            settings = settings.Replace("%wsServerPort%", Settings.Instance.WSServerPort + "");
            settings = settings.Replace("%animationHeight%", Settings.Instance.AnimationHeight + "");
            settings = settings.Replace("%animationSpeed%", (Settings.Instance.AnimationSpeed + "").Replace(',', '.'));

            response.ContentType = "text/javascript";
            response.ContentEncoding = Encoding.UTF8;
            response.StatusCode = 200;
            await HttpServerUtil.WriteReponseAsync(settings, response);
        }
    }
}
