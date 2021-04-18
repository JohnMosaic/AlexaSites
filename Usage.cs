using System;
using System.Collections.Generic;
using System.Text;

namespace AlexaSites
{
    public class Usage
    {
        public void ShowUsage()
        {
            Console.WriteLine("+--------+----------------------------------+--------------------------------------+");
            Console.WriteLine("| [this] | [start-index <positive integer>] |    [end-index <positive integer>]    |");
            Console.WriteLine("+--------+----------------------------------+--------------------------------------+");
            Console.WriteLine("|        | Crawl alexa top 1 million sites. | start-index <= end-index ∈ [1,1000] |");
            Console.WriteLine("+--------+----------------------------------+--------------------------------------+");
        }
    }
}
