using System.Collections.Generic;

namespace AlexaSites
{
    public class StringExtractor
    {
        private readonly string flag1 = "_blank'>";
        private readonly string flag2 = "</a></td>";

        public void ExtractDomains(string htmlString, List<string> domainList)
        {
            while (htmlString.Contains(flag1) && htmlString.Contains(flag2))
            {
                htmlString = htmlString.Remove(0, htmlString.IndexOf(flag1) + flag1.Length);
                string domain = htmlString.Substring(0, htmlString.IndexOf(flag2));
                domainList.Add(domain);
            }
        }
    }
}
