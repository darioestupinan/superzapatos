using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace sz.api.Models
{
    [DataContract]
    public abstract class FailureModel 
    {
        [DataMember]
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "error_code")]
        public int ErrorCode { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "error_msg")]
        public string ErrorMessage { get; set; }


        public FailureModel CreateFailureModel(int code, string response)
        {
            Success = false;
            ErrorCode = code;
            ErrorMessage = response;
            return this;
        }
    }
}
