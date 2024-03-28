using SimplePNGTuber.Server;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimplePNGTuber.Model.Endpoints
{
    public class GetModelEndpoint : Endpoint
    {
        public async Task HandleRequest(HttpListenerRequest request, HttpListenerResponse response)
        {
            string urlPath = request.Url.AbsolutePath;
            string modelName = urlPath.Substring(urlPath.LastIndexOf('/') + 1).ToLower();
            if (PNGModelRegistry.Instance.GetModelNames().Contains(modelName))
            {
                PNGModelTransport transport = PNGModelTransport.FromPNGModel(PNGModelRegistry.Instance.GetModel(modelName));
                string json = JsonSerializer.Serialize(transport);
                response.StatusCode = 200;
                response.ContentType = "application/json";
                await HttpServerUtil.WriteReponseAsync(json, response);
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

    public class PNGModelTransport
    {
        public PNGModelSettings settings { get; set; }
        public Dictionary<string, string[]> expressions { get; set; }
        public Dictionary<string, string> accessories { get; set; }

        private PNGModelTransport()
        {

        }

        public static PNGModelTransport FromPNGModel(PNGModel model)
        {
            Dictionary<string, string[]> expressions = new Dictionary<string, string[]>();
            foreach(var expression in model.expressions)
            {
                string[] value = new string[4];
                for(int i = 0; i < value.Length; i++)
                {
                    value[i] = ImageToBase64(expression.Value[i]);
                }
                expressions.Add(expression.Key, value);
            }
            Dictionary<string, string> accessories = new Dictionary<string, string>();
            foreach(var accessory in model.accessories)
            {
                string value = ImageToBase64(accessory.Value.Image.Image);
                accessories.Add(accessory.Key, value);
            }

            PNGModelTransport transport = new PNGModelTransport();
            transport.settings = model.Settings;
            transport.expressions = expressions;
            transport.accessories = accessories;
            return transport;
        }

        public static string ImageToBase64(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                return Convert.ToBase64String(imageBytes);
            }
        }
    }

}
