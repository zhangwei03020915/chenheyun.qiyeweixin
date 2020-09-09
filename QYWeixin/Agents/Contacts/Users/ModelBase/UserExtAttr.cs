using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace chenheyun.QYWeixin.Agents.Contacts.Users.ModelBase
{
    public class UserExtAttr
    {
        [JsonProperty("attrs")]
        public List<ExternalAttribute> Attrs { get; set; }
    }
}
