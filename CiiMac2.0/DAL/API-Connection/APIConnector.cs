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
        HttpClient httpClient; 
        public APIConnector() {
            httpClient = new HttpClient();
        }
        public async Task<object> GetJsonFromApiAsync(string url, object obj)
        {
            string newString;
            Type ob = obj.GetType();
            //if (ob.Equals(typeof(User)))
            //{
            //    newString = BaseUrl.GetBaseUrl() + url.Replace("{username}", id);
            //}
            //else { newString = BaseUrl.GetBaseUrl() + url.Replace("{id}", id); }
            newString = BaseUrl.GetBaseUrl() + url;

            Uri uri = new Uri(newString);
            var apirequest = httpClient.GetAsync(uri).Result;
            apirequest.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("X-AppSecretToken", "demo");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("X-AgreementGrantToken", "demo");
            string response = await apirequest.Content.ReadAsStringAsync();
            //string news = Regex.Unescape( response);
            var jsonString = response.Replace(@"\", "");
            string final = jsonString.Trim().Substring(1, (jsonString.Length) - 2);
            return JsonConvert.DeserializeObject(final, ob);

        }
    }
}

