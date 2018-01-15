using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class HTMLParser
    {

        //Find all string between --- \"url\":\ 
        //and --- ,\"pid\":\"{0}\" where {0} = PID
        public static string Deserialize(string txtHTML, string pid)
        {
            string start = "\"url\":\"";
            string end = string.Format(",\"songid\":\"{0}\"", pid);
            string duration = ",\"duration\":\"";
            int startIndex = txtHTML.IndexOf(start);
            int endIndex = txtHTML.IndexOf(end);
            int durationIndex = txtHTML.IndexOf(duration);
            
            if(durationIndex != -1)
            {
                duration = txtHTML.Substring(endIndex + (end.Length), durationIndex - (endIndex + end.Length + 1));
            }

            if (startIndex == -1 || endIndex == -1)
            {
                return null;
            }
            else
            {
                string enc_media_url = txtHTML.Substring(startIndex+(start.Length),endIndex - (startIndex+start.Length+1));                            
                return enc_media_url;               
            }
        }
        
    }
}
