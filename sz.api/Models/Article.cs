using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sz.api.Models
{
    public class Article: sz.commons.models.Article
    {
        [JsonIgnore]
        [JsonProperty(PropertyName = "store", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Store Store { get; set; }

        [JsonProperty(PropertyName = "store_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string StoreName { get; set; }

        
        [JsonProperty(PropertyName = "store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long StoreId { get; set; }
    }
}
