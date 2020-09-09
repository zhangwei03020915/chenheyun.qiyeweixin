using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace chenheyun.QYWeixin.Agents.Contacts.Tags
{
    public class TagCreateResponseModel : ResponseModel
    {
        [JsonProperty("tagid")]
        public int TagId { get; set; }
    }
}
