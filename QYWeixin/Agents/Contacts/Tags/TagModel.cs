using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace chenheyun.QYWeixin.Agents.Contacts.Tags
{
    public class TagModel
    {
        [JsonProperty("tagname")]
        public string TagName { get; set; }

        [JsonProperty("tagid")]
        public int TagId { get; set; }
    }
}
