using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            var webCrawler = new WebCrawler("https://www.google.com");
            var robotstxt = webCrawler.GetRobotsTxt();
            var rules = RobotsTxtReader.RobotsTxtParser.GetRulesApplyingForAll(robotstxt);

        }
    }

    public class WebCrawler
    {
        public Queue<string> UrlsToCrawl = new Queue<string>();
        public HashSet<string> VisitedUrls = new HashSet<string>();

        public WebCrawler(string url)
        {
            UrlsToCrawl.Enqueue(url);
        }

        public void CrawlNextUrl()
        {
            if (UrlsToCrawl.Count > 0)
            {
                var url = UrlsToCrawl.Dequeue();
                var robotstxt = GetRobotsTxt(url + "/robots.txt");
                var disallows = RobotsTxtReader.RobotsTxtParser.GetRulesApplyingForAll(robotstxt);

                if (disallows.Contains("/"))
                {
                    VisitedUrls.Add(url);
                    return;
                }


            }
        }

        public string GetRobotsTxt(string url)
        {
            return GetUrl($"{url}/robots.txt");
        }

        public static string GetUrl(string url)
        {
            var request = WebRequest.CreateHttp(url);
            var response = (HttpWebResponse)request.GetResponse();

            var data = string.Empty;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var recievedStream = response.GetResponseStream();
                StreamReader streamReader;
                if (response.CharacterSet == null)
                {
                    streamReader = new StreamReader(recievedStream);
                }
                else
                {
                    streamReader = new StreamReader(recievedStream, Encoding.GetEncoding(response.CharacterSet));
                }

                data = streamReader.ReadToEnd();
                streamReader.Close();
            }
            response.Close();
            return data;
        }
    }
}
