using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace chenheyun.QYWeixin.Agents.Contacts.Tags
{
    public class TagDetailModel : ResponseModel
    {
        /// <summary>
        /// 标签名称。
        /// </summary>
        [JsonProperty("tagname")]
        public string TagName { get; set; }

        /// <summary>
        /// 用户清单。
        /// </summary>
        [JsonProperty("userlist")]
        public List<TagUserModel> UserList { get; set; }

        /// <summary>
        /// 部门Id清单。
        /// </summary>
        [JsonProperty("partylist")]
        public int[] PartyList { get; set; }

        public class TagUserModel
        {
            [JsonProperty("userid")]
            public string UserId { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }
    }
}
