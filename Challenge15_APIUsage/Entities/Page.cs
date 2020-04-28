using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge15_APIUsage.Entities
{
    class Page<T>
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("results")]
        public List<T> Results { get; set; }
    }
}
