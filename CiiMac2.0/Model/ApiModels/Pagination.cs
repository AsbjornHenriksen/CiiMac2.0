using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
   public class Pagination
    {
        [JsonProperty("maxPageSizeAllowed", Required = Required.Always)]
        public long MaxPageSizeAllowed { get; set; }

        [JsonProperty("skipPages", Required = Required.Always)]
        public long SkipPages { get; set; }

        [JsonProperty("pageSize", Required = Required.Always)]
        public long PageSize { get; set; }

        [JsonProperty("results", Required = Required.Always)]
        public long Results { get; set; }

        [JsonProperty("resultsWithoutFilter", Required = Required.Always)]
        public long ResultsWithoutFilter { get; set; }

        [JsonProperty("firstPage", Required = Required.Always)]
        public Uri FirstPage { get; set; }

        [JsonProperty("nextPage", Required = Required.Always)]
        public Uri NextPage { get; set; }

        [JsonProperty("lastPage", Required = Required.Always)]
        public Uri LastPage { get; set; }
    }
}
