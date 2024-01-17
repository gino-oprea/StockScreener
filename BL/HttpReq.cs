using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class HttpReq
    {
        public class HttpResult
        {
            public string Result { get; set; }
            public string UpdatedCookies { get; set; }
        }
        public static async Task<HttpResult> GetUrlHttpClientAsync(string url, string? cookies, string method, string postData, string linkReferrer, bool allowRedirect)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

                if (linkReferrer != null)
                    httpClient.DefaultRequestHeaders.Referrer = new Uri(linkReferrer);

                if (!string.IsNullOrEmpty(cookies))
                {
                    httpClient.DefaultRequestHeaders.Add("Cookie", cookies);
                }

                httpClient.Timeout = TimeSpan.FromSeconds(30); // Set the timeout as needed

                HttpResponseMessage response;

                if (method == "GET")
                {
                    response = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                }
                else if (method == "POST")
                {
                    StringContent content = new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded");
                    response = await httpClient.PostAsync(url, content);
                }
                else
                {
                    throw new ArgumentException("Unsupported HTTP method", nameof(method));
                }

                if (!response.IsSuccessStatusCode && allowRedirect)
                {
                    response = await httpClient.GetAsync(response.Headers.Location, HttpCompletionOption.ResponseHeadersRead);
                }

                string result = await response.Content.ReadAsStringAsync();

                string updatedCookies = null;
                if (response.Headers.TryGetValues("Set-Cookie", out var setCookieValues))
                {
                    updatedCookies = string.Join("; ", setCookieValues);
                }

                return new HttpResult { Result = result, UpdatedCookies = updatedCookies };
            }
        }
        public static string GetUrlHttpWebRequest(string Url, string method, string postData, bool allowRedirect, Hashtable headers = null)
        {
            HttpWebRequest webclient = (HttpWebRequest)WebRequest.Create(Url);

            webclient.KeepAlive = true;
            System.Net.ServicePointManager.Expect100Continue = false;

            webclient.Method = method;
            
            webclient.ContentType = "application/x-www-form-urlencoded";
            //webclient.Accept = "*/*";
            //webclient.Headers["Accept-Encoding"] = "gszip, deflate, br";
            //webclient.Headers["Accept-Language"] = "en-US,en;q=0.9,ro;q=0.8";

            if(headers!=null)
            {
                foreach (DictionaryEntry de in headers)
                {
                    string key = de.Key as string;
                    webclient.Headers[key] = de.Value.ToString();
                }
            }

            webclient.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36";

            webclient.AllowAutoRedirect = allowRedirect;

            if (method == "POST")
            {
                byte[] bytes = Encoding.UTF8.GetBytes(postData);
                webclient.ContentLength = bytes.Length;
                Stream requestStream = webclient.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
            }

            WebResponse response;
            try
            {
                response = webclient.GetResponse();
            }
            catch (Exception ex)
            {
                return null;
            }


            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string result = reader.ReadToEnd();

            return result;
        }
        
    }
}
