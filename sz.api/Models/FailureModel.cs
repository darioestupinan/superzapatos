using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace sz.api.Models
{
    public class FailureModel : StoreModelBase
    {
        [JsonProperty(PropertyName = "error_code", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int ErrorCode { get; set; }

        [JsonProperty(PropertyName = "error_msg", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ErrorMessage { get; set; }
        
        public FailureModel (bool success, int code, string response) : base (success)
        {
            Success = false;
            ErrorCode = code;
            ErrorMessage = response;            
        }
    }
}
