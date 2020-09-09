using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace chenheyun.QYWeixin.Agents.Contacts.Users
{
    public class UserIdModel : ResponseModel
    {
        /// <summary>
        /// 该openid在企业微信对应的成员userid
        /// </summary>
        [JsonProperty("userid")]
        public string UserId { get; set; }
    }
}
