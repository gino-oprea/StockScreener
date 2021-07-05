using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace BL
{
    public class HttpReq
    {
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
