using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class MetaData
    {
        [JsonProperty("create", Required = Required.Always)]
        public Create Create { get; set; }
    }
}
