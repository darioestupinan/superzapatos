using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sz.api.Models
{
    public class StoreResponseModel : StoreModelBase
    {
        [JsonProperty(PropertyName = "store")]
        public Store Store { get; private set; }

        public StoreResponseModel(Store store) : base(true)
        {
            Store = store;
        }
    }

    public class StoresResponseModel : StoreModelBase
    {
        [JsonProperty(PropertyName = "stores")]
        public IEnumerable<Store> Stores { get; set; }

        [JsonProperty(PropertyName = "total_elements", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int TotalElements { get; set; }

        public StoresResponseModel(IEnumerable<Store> stores) : base(true)
        {
            Stores = stores;
            TotalElements = stores.Count();
        }
    }
}
