using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class ListOfCollections
    {
        [JsonProperty("collection", Required = Required.Always)]
        public List<Collection> Collection { get; set; }
    }
}
