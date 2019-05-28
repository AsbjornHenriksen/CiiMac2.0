using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Templates
    {
        [JsonProperty("invoice", Required = Required.Always)]
        public Uri Invoice { get; set; }

        [JsonProperty("invoiceLine", Required = Required.Always)]
        public Uri InvoiceLine { get; set; }

        [JsonProperty("self", Required = Required.Always)]
        public Uri Self { get; set; }
    }
}
