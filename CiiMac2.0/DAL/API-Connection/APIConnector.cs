using Model;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL.API_Connection
{
    public class APIConnector
    {
        
        HttpClient httpClient; 
        public APIConnector() {
            httpClient = new HttpClient();
        }
        public async Task <IEnumerable<Company>> GetJsonFromApiAsync(string url)
        {
            
            string newString = BaseUrl.GetBaseUrl() + url;
            Uri uri = new Uri(newString);

            httpClient.DefaultRequestHeaders.Add("X-AppSecretToken", "demo");
            httpClient.DefaultRequestHeaders.Add("X-AgreementGrantToken", "demo");

            var apirequest = await httpClient.GetStringAsync(uri);

           

            return JsonConvert.DeserializeObject<IEnumerable<Company>>(apirequest.ToString());

            
        }

    }
}

