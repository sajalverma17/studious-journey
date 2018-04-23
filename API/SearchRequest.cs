using System;

using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace API
{
    public class SearchRequest : IRequest<string,string>
    {
        private const string SEARCH_URL = "http://www.saavn.com/api.php?__call=autocomplete.get&query=asd";
        

        public async Task<string> MakeRequest(string query)
        {
            HttpClient httpClient = new HttpClient();           
            string req = string.Format("http://www.saavn.com/api.php?__call=autocomplete.get&ctx=android&_format=json&_marker=0&network_type=mobile&network_subtype=UMTS&network_operator=Android&cc=us&v=23&readable_version=2.6%3A&manufacturer=unknown&model=google_sdk&build=google_sdk-eng+2.3.4+GINGERBREAD+12&query={0}", query);
            string result = null;
            try
            {
                result = await httpClient.GetStringAsync(req);
            }
            catch (HttpRequestException hre) 
            {
                return null;
            }
            return result;                     
        }


       
    }
}
