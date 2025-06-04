using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BL.Utils
{
    public class HttpReq
    {
        public class HttpResult
        {
            public string Result { get; set; }
            public string UpdatedCookies { get; set; }
        }       

        public static async Task<HttpResult> GetUrlHttpClientAsync(string url, string cookies, string method, string postData, string linkReferrer, bool allowRedirect)
        {
            var handler = new HttpClientHandler
            {
                AllowAutoRedirect = allowRedirect,
                UseCookies = true,
                CookieContainer = new CookieContainer()
            };

            if (!string.IsNullOrEmpty(cookies))
            {
                // Parse cookies and add them to the container
                var uri = new Uri(url);
                handler.CookieContainer.SetCookies(uri, cookies);
            }

            using (var httpClient = new HttpClient(handler))
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

                if (!string.IsNullOrEmpty(linkReferrer))
                    httpClient.DefaultRequestHeaders.Referrer = new Uri(linkReferrer);

                httpClient.Timeout = TimeSpan.FromSeconds(30);

                HttpResponseMessage response;

                if (method == "GET")
                {
                    response = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                }
                else if (method == "POST")
                {
                    StringContent content = new StringContent(postData ?? "", Encoding.UTF8, "application/x-www-form-urlencoded");
                    response = await httpClient.PostAsync(url, content);
                }
                else
                {
                    throw new ArgumentException("Unsupported HTTP method", nameof(method));
                }

                string result = await response.Content.ReadAsStringAsync();

                // Get updated cookies
                string updatedCookies = handler.CookieContainer.GetCookieHeader(new Uri(url));

                return new HttpResult { Result = result, UpdatedCookies = updatedCookies };
            }
        }
    }
}
