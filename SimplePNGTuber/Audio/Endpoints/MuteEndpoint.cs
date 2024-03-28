using SimplePNGTuber.Server;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SimplePNGTuber.Audio.Endpoints
{
    public class MuteEndpoint : Endpoint
    {
        public event EventHandler<MutedEventArgs> MutedEvent;

        public async Task HandleRequest(HttpListenerRequest request, HttpListenerResponse response)
        {
            bool mute = request.Url.AbsolutePath.EndsWith("/true");
            bool unmute = request.Url.AbsolutePath.EndsWith("/false");
            if(mute || unmute)
            {

                MutedEvent?.Invoke(this, new MutedEventArgs() { Muted = mute });
                response.StatusCode = 200;
                response.ContentType = "text/plain";
                await HttpServerUtil.WriteReponseAsync("", response);
            }
            else
            {
                response.StatusCode = 400;
                response.ContentType = "text/plain";
                await HttpServerUtil.WriteReponseAsync("400 Bad Request", response);
            }
        }
    }

    public class MutedEventArgs : EventArgs
    {
        public bool Muted { get; set; }
    }
}
