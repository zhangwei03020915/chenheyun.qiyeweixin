using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace chenheyun.QYWeixin.Agents.Contacts.Users
{
    /// <summary>
    /// 企业微信成员userid模型。
    /// </summary>
    public class OpenIdModel : ResponseModel
    {
        /// <summary>
        /// 企业微信成员userid对应的openid.
        /// </summary>
        [JsonProperty("openid")]
        public string OpenId { get; set; }
    }
}
