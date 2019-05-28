using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Create
    {
        [JsonProperty("description", Required = Required.Always)]
        public string Description { get; set; }

        [JsonProperty("href", Required = Required.Always)]
        public Uri Href { get; set; }

        [JsonProperty("httpMethod", Required = Required.Always)]
        public string HttpMethod { get; set; }
    }
}
