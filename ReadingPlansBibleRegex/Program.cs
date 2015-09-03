using HtmlAgilityPack;
using ReadingPlansBibleRegex.Services;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;

namespace ReadingPlansBibleRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            args = new string[]
            {
                "https://www.bible.com/pt/users/rafael_yami/reading-plans/814-pt-plano-de-leitura-da-biblia?day={0}&id=814-pt-plano-de-leitura-da-biblia",
                "365",
                "http://www.bible.com/pt/sign-in",
                "rafael_yami@hotmail.com",
                "Queopps 2015",
                @"D:\Documents\Extensions\Json\"
            };

            string urlToPlan = args[0];
            string limitYear = args[1];
            string loginUrl = args[2];

            string htmlString;
            string planFinalUrl;

            Regex regex;
            Match match;
            GroupCollection groups;

            CookieAwareWebClientService webClient = new CookieAwareWebClientService();

            HtmlDocument htmlDocument = new HtmlDocument()
            {
                OptionDefaultStreamEncoding = Encoding.UTF8
            };

            htmlDocument.Load(webClient.OpenRead(loginUrl), Encoding.UTF8);

            string authenticityTokenString = htmlDocument.DocumentNode.SelectSingleNode("//meta[@name='csrf-token']").Attributes["content"].Value;

            NameValueCollection loginData = new NameValueCollection
            {
                { "utf8", "✓" },
                { "authenticity_token", authenticityTokenString },
                { "username", args[3] },
                { "password", args[4] }
            };

            webClient.DoLogin(loginUrl, loginData);

            int daysYear = int.Parse(limitYear);

            

            for (int i = 1; i <= daysYear; i++)
            {
                planFinalUrl = string.Format(urlToPlan, i);

                htmlDocument.Load(webClient.OpenRead(planFinalUrl), Encoding.UTF8);

                HtmlNodeCollection references = htmlDocument.DocumentNode.SelectNodes("//input[@id='ref']");
            }
        }
    }
}