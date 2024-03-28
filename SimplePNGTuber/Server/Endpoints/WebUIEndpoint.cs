using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimplePNGTuber.Server.Endpoints
{
    public class WebUIEndpoint : Endpoint
    {
        public const string HTDocsFolder = "htdocs/";

        public async Task HandleRequest(HttpListenerRequest request, HttpListenerResponse response)
        {
            string requestUrl = request.Url.AbsolutePath.Replace("/webui", "");
            if(!Directory.Exists(HTDocsFolder))
            {
                response.StatusCode = 500;
                response.ContentType = "text/plain";
                await HttpServerUtil.WriteReponseAsync("500 Internal Server Error", response);
            }
            if(requestUrl.Contains("/../"))
            {
                response.StatusCode = 403;
                response.ContentType = "text/plain";
                await HttpServerUtil.WriteReponseAsync("403 Forbidden", response);
            }
            else
            {
                if(requestUrl.EndsWith("/"))
                {
                    requestUrl += "index.html";
                }
                byte[] res = File.ReadAllBytes(HTDocsFolder + requestUrl);
                if(requestUrl.EndsWith(".html"))
                {
                    response.ContentType = "text/html";
                    response.ContentEncoding = Encoding.UTF8;
                }
                else if(requestUrl.EndsWith(".js"))
                {
                    response.ContentType = "text/javascript";
                    response.ContentEncoding = Encoding.UTF8;
                }
                else if(requestUrl.EndsWith(".css"))
                {
                    response.ContentType = "text/css";
                    response.ContentEncoding = Encoding.UTF8;
                }
                else if(requestUrl.EndsWith(".gif"))
                {
                    response.ContentType = "image/gif";
                }
                response.StatusCode = 200;
                await HttpServerUtil.WriteReponseAsync(res, response);
            }

            response.Close();
        }
    }
}
