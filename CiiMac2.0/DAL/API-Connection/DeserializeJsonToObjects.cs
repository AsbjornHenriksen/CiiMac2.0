using Model.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.API_Connection
{
    public class DeserializeJsonToObjects
    {
        public ListOfCollections GetListOfCollections(string url)
        {
            string response = APIConnector.GetJsonFromApiAsync(url);


            return JsonConvert.DeserializeObject<ListOfCollections>(response, SerializerSettings.Settings);

        }
    }
}
