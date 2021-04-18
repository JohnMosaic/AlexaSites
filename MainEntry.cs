using System;
using System.Collections.Generic;

namespace AlexaSites
{
    class MainEntry
    {
        static void Main(string[] args)
        {
            Usage usage = new Usage();
            int start;
            int end;

            try
            {
                start = Convert.ToInt32(args[0]);
                end = Convert.ToInt32(args[1]);

                if (start <= 0 || end <= 0 || start > end) usage.ShowUsage();
                else
                {
                    //string url = "http://stuffgate.com/stuff/website/top-1000-sites";
                    string urlLeftPart = "http://stuffgate.com/stuff/website/top-";
                    string urlRightPart = "-sites";
                    int batchSize = 100;
                    int interval = 1000;
                    List<string> domainList = new List<string>();
                    ResultManager resultManager = new ResultManager();
                    StringExtractor stringExtractor = new StringExtractor();
                    WebHelper webHelper = new WebHelper();
                    Console.WriteLine("[INFO] Start crawling alexa sites.");

                    for (int i = start; i <= end; i++)
                    {
                        string url = urlLeftPart + (i * interval).ToString() + urlRightPart;
                        string htmlString = webHelper.GetHtmlString(url);

                        if (htmlString.IndexOf("[ERRO]") == 0) Console.WriteLine(htmlString + " index=" + i.ToString());
                        else
                        {
                            stringExtractor.ExtractDomains(htmlString, domainList);
                            Console.WriteLine("[INFO] Alexa top-" + (i * interval).ToString() + " sites crawled.");

                            if (i % batchSize == 0)
                            {
                                string filename = "alexa-top-" + (i * interval).ToString() + "-sites.csv";
                                resultManager.WriteResults(domainList, filename);
                                domainList.Clear();
                                domainList.TrimExcess();
                                domainList = new List<string>();
                                Console.WriteLine("[INFO] Alexa top-" + (i * interval).ToString() + " sites saved.");
                            }
                        }
                    }

                    if (domainList.Count > 0)
                    {
                        string filename = "alexa-top-N-sites.csv";
                        resultManager.WriteResults(domainList, filename);
                        domainList.Clear();
                        domainList.TrimExcess();
                    }

                    Console.WriteLine("[INFO] Crawling alexa sites completed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERRO] " + ex.Message);
                usage.ShowUsage();
            }
        }
    }
}
