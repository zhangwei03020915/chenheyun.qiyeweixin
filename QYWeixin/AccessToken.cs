using System;
using Newtonsoft.Json;

namespace chenheyun.QYWeixin.Models
{
    public class AccessToken : ResponseModel
    {
        [JsonProperty("access_token")]
        public string Value { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonIgnore]
        public DateTime GeneratedTime
        {
            private get;
            set;
        }

        [JsonIgnore]
        public bool IsExpired
        {
            get
            {
                return DateTime.Now > GeneratedTime.AddSeconds(ExpiresIn);
            }
        }
    }
}
