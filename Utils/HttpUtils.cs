using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Http;

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

        // 模拟curl -u 
        public static Task<HttpResponseMessage> HttpCurl_U(string url, string acc, string pwd)
        {
            HttpClient client = new HttpClient();
            string str = $"{acc}:{pwd}";
            byte[] bytes = Encoding.ASCII.GetBytes(str);
            string base64Str = Convert.ToBase64String(bytes);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Str);
            return client.GetAsync(url);
        }

    }
}
