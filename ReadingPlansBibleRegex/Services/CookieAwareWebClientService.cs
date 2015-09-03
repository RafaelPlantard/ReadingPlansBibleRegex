using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace ReadingPlansBibleRegex.Services
{
    public class CookieAwareWebClientService : WebClient
    {
        public CookieContainer CookieContainer { get; set; }

        public CookieAwareWebClientService()
            : this(new CookieContainer())
        { }

        public CookieAwareWebClientService(CookieContainer cookieContainer)
        {
            CookieContainer = cookieContainer;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);

            request.CookieContainer = CookieContainer;

            return request;
        }

        public void DoLogin(string loginUrl, NameValueCollection loginData)
        {
            CookieContainer container;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(loginUrl);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            byte[] buffer = Encoding.UTF8.GetBytes(loginData.ToString());
            request.ContentLength = buffer.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(buffer, 0, buffer.Length);
            requestStream.Close();

            container = request.CookieContainer = new CookieContainer();

            WebResponse response = request.GetResponse();
            response.Close();

            CookieContainer = container;
        }
    }
}
