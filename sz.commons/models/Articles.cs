using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace sz.commons.models
{    
    public class Article
    {
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "price", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "total_in_shelf", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int TotalInShelf { get; set; }

        [JsonProperty(PropertyName = "total_in_vault", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int TotalInVault { get; set; }

        [JsonIgnore]
        [JsonProperty(PropertyName = "store_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long StoreId { get; set; }

        [JsonProperty(PropertyName = "store", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Store Store { get; set; }                
    }
}
