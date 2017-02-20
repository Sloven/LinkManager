using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Backend.IntegrationTests
{
    public static class ExtensionsHelpers
    {
        /// <summary>
        /// Send credentials receive token
        /// </summary>
        /// <returns>Bearer access_token</returns>
        public static string Login(this InMemoryClient client, string username, string password)
        {
            var data = $"userName={Uri.EscapeDataString(username)}&password={Uri.EscapeDataString(password)}&grant_type=password";

            var tokenResponse = SendRequest(client, client.TokenUrl, HttpMethod.Post, data);
            var tokenMess = tokenResponse.Content.ReadAsStringAsync().Result;

            var token = JsonConvert.DeserializeAnonymousType(tokenMess, new { access_token = "" });
            return token?.access_token;
        }

        public static HttpResponseMessage PostRequest(this HttpClient client, string url, Dictionary<string, string> headers, string data = "")
        {
            return SendRequest(client, url, HttpMethod.Post,headers, data);
        }

        public static HttpResponseMessage PostRequest(this HttpClient client, string url,string data = "")
        {
            return SendRequest(client, url, HttpMethod.Post, data);
        }

        public static HttpResponseMessage SendRequest(this HttpClient client, string url, HttpMethod method, string data = "")
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendRequest(client, url, method, headers, data);
        }

        public static HttpResponseMessage SendRequest(this HttpClient client, string url, HttpMethod method, Dictionary<string,string> headers, string data = "")
        {
            HttpResponseMessage response;
            using (var request = CreateRequest(client, url, "application/json", method))
            {
                request.Content = new StringContent(data, Encoding.UTF8, "application/json"); ;

                foreach (var head in headers)
                    request.Headers.Add(head.Key, head.Value);

                response = client.SendAsync(request).Result;
            }
            return response;
        }

        private static HttpRequestMessage CreateRequest(HttpClient client, string url, string mthv, HttpMethod method)
        {
            var request = new HttpRequestMessage {RequestUri = new Uri(client.BaseAddress.AbsoluteUri + url)};
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mthv));
            request.Method = method;
            return request;
        }
    }
}
