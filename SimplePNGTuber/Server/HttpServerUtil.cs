using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimplePNGTuber.Server
{
    public class HttpServerUtil
    {
        public static async Task WriteReponseAsync(string responseString, HttpListenerResponse response)
        {
            byte[] data = Encoding.UTF8.GetBytes(responseString);
            response.ContentEncoding = Encoding.UTF8;
            response.ContentLength64 = data.LongLength;

            await response.OutputStream.WriteAsync(data, 0, data.Length);
        }

        public static async Task WriteReponseAsync(byte[] data, HttpListenerResponse response)
        {
            response.ContentLength64 = data.LongLength;

            await response.OutputStream.WriteAsync(data, 0, data.Length);
        }
    }
}
