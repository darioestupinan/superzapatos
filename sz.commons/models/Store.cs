using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace sz.commons.models
{
    [DataContract]
    public class Store
    {
        [DataMember]
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
    }
}
