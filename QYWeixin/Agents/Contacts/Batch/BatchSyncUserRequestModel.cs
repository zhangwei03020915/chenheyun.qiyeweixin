using Newtonsoft.Json;

namespace chenheyun.QYWeixin.Agents.Contacts
{
    /// <summary>
    /// 以userid（帐号）为主键，增量更新企业微信通讯录成员。
    /// </summary>
    public class BatchSyncUserRequestModel : BatchRequestModel
    {
        /// <summary>
        /// 是否邀请新建的成员使用企业微信（将通过微信服务通知或短信或邮件下发邀请，每天自动下发一次，最多持续3个工作日），默认值为true。
        /// </summary>
        [JsonProperty("to_invite")]
        public bool ToInvite { get; set; }
    }
}
