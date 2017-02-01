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
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long Id { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "address", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Address { get; set; }
    }
}
