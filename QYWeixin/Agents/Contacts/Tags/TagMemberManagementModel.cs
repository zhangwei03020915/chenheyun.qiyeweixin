using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiClient.Attributes;

namespace chenheyun.QYWeixin.Agents.Contacts.Tags
{
    public class TagMemberManagementModel
    {
        [JsonProperty("tagid")]
        public int TagId { get; set; }

        /// <summary>
        /// 企业成员ID列表，注意：userlist、partylist不能同时为空，单次请求个数不超过1000。
        /// </summary>
        [JsonProperty("userlist")]
        public string[] UserList { get; set; }

        /// <summary>
        /// 企业部门ID列表，注意：userlist、partylist不能同时为空，单次请求个数不超过100。
        /// </summary>
        [JsonProperty("partylist")]
        public int[] PartyList { get; set; }

    }

    /// <summary>
    /// a)正确
    ///{
    ///   "errcode": 0,
    ///   "errmsg": "deleted"
    ///}
    ///b)若部分userid、partylist非法
    ///{
    ///   "errcode": 0,
    ///   "errmsg": "deleted",
    ///   "invalidlist"："usr1|usr2|usr",
    ///   "invalidparty": [2,4]
    ///}
    ///c)当包含的userid、partylist全部非法
    ///{
    ///   "errcode": 40031,
    ///   "errmsg": "all list invalid"
    ///}
    /// </summary>
    public class TagMemberManagementResponseModel : ResponseModel
    {
        /// <summary>
        /// 用“|”分割的用户Id清单。
        /// </summary>
        [JsonProperty("invalidlist")]
        public string InvalidList { get; set; }

        /// <summary>
        /// 非法的party清单。
        /// </summary>
        [JsonProperty("invalidparty")]
        public int[] InvalidPartyId { get; set; }

        [JsonIgnore]
        public string[] InvalidUserId
        {
            get => InvalidList.Split('|');
        }
    }
}
