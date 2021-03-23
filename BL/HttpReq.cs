using System;
using System.IO;
using System.Net;
using System.Text;

namespace BL
{
    public class HttpReq
    {
        public static string GetUrlHttpWebRequest(string Url, string method, string postData, bool allowRedirect)
        {
            HttpWebRequest webclient = (HttpWebRequest)WebRequest.Create(Url);


            webclient.KeepAlive = true;
            System.Net.ServicePointManager.Expect100Continue = false;


            webclient.Method = method;
            webclient.ContentType = "application/x-www-form-urlencoded";

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
