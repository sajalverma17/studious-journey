using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace API
{
    //Get enc_media_url from source code of Song's page
    public class SaavnPageRequest : IRequest<string, string>
    {
        public async Task<string> MakeRequest(string web_url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("GET", "/s/song/english/Work/Work/IyQtQEJqQ3Y HTTP/1.1");
            client.DefaultRequestHeaders.Add("Host", "www.saavn.com");
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            client.DefaultRequestHeaders.Add("Cache-Control", " max-age=0");
            client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36");
            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
            //client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            client.DefaultRequestHeaders.Add("Accept-Language", "nb,no;q=0.8,nn;q=0.6,en-US;q=0.4,en;q=0.2,en-IN;q=0.2");
            client.DefaultRequestHeaders.Add("Cookie", "B=6305d6f09b402157dfa811134087f6e7; __gads=ID=1f1bbc3a2a2d0b0c:T=1502704178:S=ALNI_MYho67wlKJR8VODa3qUgGfeNShpfA; geo=193.212.51.164%2CNO%2COslo+County%2COslo%2C0001; CT=OTc0OTk0NjY=; CH=G03%2CA07%2CO00%2CL03; __utmt=1; L=hindi; __utma=257722889.929876398.1502704179.1509632744.1509636659.3; __utmb=257722889.4.10.1509636659; __utmc=257722889; __utmz=257722889.1502704179.1.1.utmcsr=google|utmccn=(organic)|utmcmd=organic|utmctr=(not%20provided); _fp=97bfa4cc424063bf9bf2cdb63fb42fe5; ATC=%2F2JKpno%2B5TMdji9QUaklDXzho9JPZBqdh4FyLv3OdpVCj%2BqH9jV8Ze9vWjC1D7ME; jwplayer.volume=75");            
            
            byte[] bArray = await client.GetByteArrayAsync(web_url);
            string result = Encoding.UTF8.GetString(bArray, 0, bArray.Length);
            return result;
            
        }
    }
}
