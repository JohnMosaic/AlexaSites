using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AlexaSites
{
    public class ResultManager
    {
        public void WriteResults(List<string> domainList, string filename)
        {
            string fileFullName = Environment.CurrentDirectory + "\\" + filename;
            FileStream fs = new FileStream(fileFullName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            StringBuilder sb = new StringBuilder();
            int line = 0;

            try
            {
                foreach (string s in domainList)
                {
                    sb.Append(s).Append("\r\n");
                    line++;

                    if (line == 5000)
                    {
                        sw.Write(sb.ToString());
                        line = 0;
                        sb = new StringBuilder();
                    }
                }

                if (line > 0) sw.Write(sb.ToString());
            }
            finally
            {
                if (sw != null) sw.Close();
                if (fs != null) fs.Close();
            }
        }
    }
}
