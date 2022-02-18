using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace CsharpUtils
{
    public static class HttpUtils
    {
        public static HttpWebResponse CreateHttpWebResponse(string url, string postData)
        {
            var sendBytes = Encoding.UTF8.GetBytes(postData);
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            webRequest.ContentLength = sendBytes.Length;
            using (Stream requestStream = webRequest.GetRequestStream())
            {
                requestStream.Write(sendBytes, 0, sendBytes.Length);
            }
            return (HttpWebResponse)webRequest.GetResponse();
        }

    }
}
