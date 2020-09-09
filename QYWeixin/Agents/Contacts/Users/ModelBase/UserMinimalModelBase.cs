using Newtonsoft.Json;

namespace chenheyun.QYWeixin.Agents.Contacts.Users.ModelBase
{
    /// <summary>
    /// 用户的极简模型。
    /// </summary>
    public abstract class UserMinimalModelBase
    {
        [JsonProperty("userid")]
        public string UserId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("department")]
        public int[] Departments { get; set; }
    }
}
