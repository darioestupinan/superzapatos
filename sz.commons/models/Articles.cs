using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace sz.commons.models
{
    [DataContract]
    public class Article
    {
        [DataMember]
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "totalInShelf")]
        public int TotalInShelf { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "totalInVault")]
        public int TotalInVault { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "storeId")]
        public long StoreId { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "store")]
        public Store Store { get; set; }                
    }
}
