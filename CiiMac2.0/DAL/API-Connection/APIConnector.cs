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
using System.Globalization;
using Newtonsoft.Json.Converters;
using Model.Models;

namespace DAL.API_Connection
{
    public static class APIConnector
    {
        
        public static string GetJsonFromApiAsync(string url)
        {
            HttpClient httpClient = new HttpClient();
            string newString = BaseUrl.GetBaseUrl() + url;
            Uri uri = new Uri(newString);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("X-AppSecretToken", "aMegSjKTWmlZob05bt0xFg9bozLn6XnNGChYvJEInCQ1");
            httpClient.DefaultRequestHeaders.Add("X-AgreementGrantToken", "hFskSHutDdMP2wyct7nwnxh739ykhrHMyZnkbPlk5941");

            return httpClient.GetStringAsync(uri).Result;
        }


    }
}

