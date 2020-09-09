using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace chenheyun.QYWeixin.Agents.Contacts.Users.ModelBase
{
    /// <summary>
    /// 用户对外展实信息。
    /// </summary>
    public class UserExternalProfile
    {
        /// <summary>
        /// 企业简称。
        /// </summary>
        [JsonProperty("external_corp_name")]
        public string ExternalCorpName { get; set; }

        /// <summary>
        /// 扩展属性。
        /// </summary>
        [JsonProperty("external_attr")]
        public List<ExternalAttribute> Attrs { get; set; }
    }
}
