using chenheyun.QYWeixin.Agents.Contacts.Users.ModelBase;
using Newtonsoft.Json;

namespace chenheyun.QYWeixin.Agents.Contacts.Users
{
    /// <summary>
    /// 创建用户的模型。
    /// </summary>
    public class UserCreateModel : UserCreateOrUpdateModelBase
    {
        /// <summary>
        /// 是否邀请该成员使用企业微信（将通过微信服务通知或短信或邮件下发邀请，每天自动一次，最多持续3个工作日），默认值为true。
        /// </summary>
        [JsonProperty("to_invite")]
        public bool ToInvite { get; set; }
    }
}
