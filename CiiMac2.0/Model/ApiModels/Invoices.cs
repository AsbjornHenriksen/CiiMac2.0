using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Invoices
    {
        [JsonProperty("drafts", Required = Required.Always)]
        public Uri Drafts { get; set; }

        [JsonProperty("booked", Required = Required.Always)]
        public Uri Booked { get; set; }

        [JsonProperty("self", Required = Required.Always)]
        public Uri Self { get; set; }
    }
}
