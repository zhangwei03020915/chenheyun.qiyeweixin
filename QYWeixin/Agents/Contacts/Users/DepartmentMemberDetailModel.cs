using Newtonsoft.Json;

namespace chenheyun.QYWeixin.Agents.Contacts.Users
{
    /// <summary>
    /// 部门成员详情模型。
    /// </summary>
    public class DepartmentMemberDetailModel : UserDetailModel
    {
        /// <summary>
        /// 英文名
        /// </summary>
        [JsonProperty("english_name")]
        public string EnglishName { get; set; }

        /// <summary>
        /// 是否隐藏手机号。
        /// </summary>
        [JsonProperty("hide_mobile")]
        public string HideMobile { get; set; }
    }
}
