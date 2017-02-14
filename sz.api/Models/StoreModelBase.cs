using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sz.api.Models
{
    public abstract class StoreModelBase
    {
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        public StoreModelBase(bool success)
        {
            Success = success;
        }
    }
}
