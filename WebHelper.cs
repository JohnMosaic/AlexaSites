using System;
using System.IO.Compression;
using System.Net;
using System.Text;

namespace AlexaSites
{
    public class WebHelper
    {
        public string GetHtmlString(string url)
        {
            StringBuilder sb = new StringBuilder();
            string htmlString = string.Empty;
            int t = 0;

            while (t < 3)
            {
                try
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                    httpWebRequest.Timeout = 30000;
                    httpWebRequest.Method = "GET";
                    httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.108 Safari/537.36";
                    httpWebRequest.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    GZipStream gZipStream = new GZipStream(httpWebResponse.GetResponseStream(), CompressionMode.Decompress);
                    byte[] buffer = new byte[20480];
                    int len = gZipStream.Read(buffer, 0, buffer.Length);

                    while (len > 0)
                    {
                        sb.Append(Encoding.Default.GetString(buffer, 0, len));
                        len = gZipStream.Read(buffer, 0, buffer.Length);
                    }

                    htmlString = sb.ToString();
                    break;
                }
                catch (Exception ex)
                {
                    htmlString = "[ERRO] " + ex.Message;
                    Console.WriteLine(htmlString + " Try again. t=" + (t + 1).ToString());
                    t++;
                }
            }

            return htmlString;
        }
    }
}
