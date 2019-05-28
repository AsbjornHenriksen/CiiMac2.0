using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
   public class CustomerGroup
    {
        [JsonProperty("customerGroupNumber", Required = Required.Always)]
        public long CustomerGroupNumber { get; set; }

        [JsonProperty("self", Required = Required.Always)]
        public Uri Self { get; set; }
    }
}
