using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sz.api.Models
{
    public class StoreResponseModel : FailureModel
    {
        [JsonProperty(PropertyName = "store")]
        public Store Store { get; private set; }

        public StoreResponseModel CreateOkModel(Store store)
        {
            Success = true;
            Store = store;
            return this;
        }
    }

    public class StoresResponseModel : FailureModel
    {
        [JsonProperty(PropertyName = "stores")]
        public IEnumerable<Store> Stores { get; set; }

        [JsonProperty(PropertyName = "total_elements", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int TotalElements { get; set; }

        public StoresResponseModel CreateOkModel(IEnumerable<Store> stores)
        {
            Success = true;
            Stores = stores;
            TotalElements = stores.Count();
            return this;
        }

        public bool ShouldSerializeManager()
        {
            // don't serialize the Manager property if an employee is their own manager
            return (Stores.Count() > 0);
        }
    }
}
