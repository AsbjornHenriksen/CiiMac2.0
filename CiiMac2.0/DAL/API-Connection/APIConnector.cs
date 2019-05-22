using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAL.API_Connection
{
    public class APIConnector
    {
        List<Company> objList;
        HttpClient httpClient; 
        public APIConnector() {
            httpClient = new HttpClient();
        }
        public async Task <List<Company>> GetJsonFromApiAsync(string url)
        {
            string newString;
            newString = BaseUrl.GetBaseUrl() + url;
            objList = new List<Company>();

            Uri uri = new Uri(newString);
            var apirequest = httpClient.GetAsync(uri).Result;
            apirequest.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("X-AppSecretToken", "demo");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("X-AgreementGrantToken", "demo");
            HttpResponseMessage response = apirequest;
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<Company>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                foreach (var d in dataObjects)
                {
                    Console.WriteLine("{0}", d.Name);
                    objList.Add(d);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            //string news = Regex.Unescape( response);
            ////var jsonString = response.Replace(@"\", "");
            ////string final = jsonString.Trim().Substring(1, (jsonString.Length) - 2);
            ////return JsonConvert.DeserializeObject(final, obj);
            return objList; 

        }

    }
}

