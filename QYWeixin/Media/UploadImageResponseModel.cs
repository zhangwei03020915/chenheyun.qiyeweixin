using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace chenheyun.QYWeixin.Media
{
    public class UploadImageResponseModel : ResponseModel
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
