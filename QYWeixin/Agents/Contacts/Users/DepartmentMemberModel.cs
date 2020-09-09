using chenheyun.QYWeixin.Agents.Contacts.Users.ModelBase;
using Newtonsoft.Json;

namespace chenheyun.QYWeixin.Agents.Contacts.Users
{
    /// <summary>
    /// 部门成员模型。
    /// </summary>
    public class DepartmentMemberModel : UserMinimalModelBase
    {
        /// <summary>
        /// 全局唯一。对于同一个服务商，不同应用获取到企业内同一个成员的open_userid是相同的，最多64个字节。仅第三方应用可获取
        /// </summary>
        [JsonProperty("open_userid")]
        public string OpenUserId { get; set; }
    }
}
