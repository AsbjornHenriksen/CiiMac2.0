﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Layout
    {
        [JsonProperty("layoutNumber", Required = Required.Always)]
        public long LayoutNumber { get; set; }

        [JsonProperty("self", Required = Required.Always)]
        public Uri Self { get; set; }
    }
}
