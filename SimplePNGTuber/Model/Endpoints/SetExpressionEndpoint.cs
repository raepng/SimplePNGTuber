using SimplePNGTuber.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimplePNGTuber.Model.Endpoints
{
    public class SetExpressionEndpoint : Endpoint
    {
        public event EventHandler<ExpressionEventArgs> ExpressionChangeEvent;

        public async Task HandleRequest(HttpListenerRequest request, HttpListenerResponse response)
        {
            string urlPath = request.Url.AbsolutePath;
            string expressionName = urlPath.Substring(urlPath.LastIndexOf('/') + 1).ToLower();
            if (PNGModelRegistry.Instance.ActiveModel.GetExpressions().Contains(expressionName))
            {
                ExpressionChangeEvent?.Invoke(this, new ExpressionEventArgs() { ExpressionName = expressionName });
                response.StatusCode = 200;
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

    public class ExpressionEventArgs : EventArgs
    {
        public string ExpressionName { get; set; }
    }
}
