using chenheyun.QYWeixin.Agents.Contacts.Users.ModelBase;
using chenheyun.QYWeixin.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace chenheyun.QYWeixin.Agents.Contacts.Users.ModelBase
{
    /// <summary>
    /// 用户的基础模型
    /// </summary>
    public abstract class UserModelBase : UserMinimalModelBase
    {
        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        [JsonProperty("department")]
        public int[] Department { get; set; }

        [JsonProperty("order")]
        public int[] Order { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        /// <summary>
        /// 性别。1表示男性，2表示女性
        /// </summary>
        [JsonProperty("gender")]
        public int Gender { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("is_leader_in_dept")]
        public int[] IsLeaderInDepartment { get; set; }

        /// <summary>
        /// 启用/禁用成员: 1=启用，2=表示禁用
        /// </summary>
        [JsonProperty("enable")]
        public int? Enable { get; set; }

        /// <summary>
        /// 电话。
        /// </summary>
        [JsonProperty("telephone")]
        public string Telephone { get; set; }


        /// <summary>
        /// 地址。长度最大128个字符
        /// </summary>
        [JsonProperty("address")]
        [MaxLength(128)]
        public string Address { get; set; }

        /// <summary>
        /// 主要部门Id。
        /// </summary>
        [JsonProperty("main_department")]
        public int MainDepartmentId { get; set; }

        /// <summary>
        /// 激活状态: 1=已激活，2=已禁用，4=未激活。
        /// 已激活代表已激活企业微信或已关注微工作台（原企业号）。未激活代表既未激活企业微信又未关注微工作台（原企业号）。
        /// </summary>
        [JsonProperty("status")]
        public int? Status { get; set; }

        /// <summary>
        /// 扩展属性，第三方仅通讯录应用可获取
        /// </summary>
        [JsonProperty("extattr")]
        public UserExtAttr ExtAttr { get; set; }

        /// <summary>
        /// 成员对外属性，字段详情见对外属性；
        /// 第三方仅通讯录应用可获取
        /// </summary>
        [JsonProperty("external_profile")]
        public UserExternalProfile ExternalProfile { get; set; }

        /// <summary>
        /// 对外职务，如果设置了该值，则以此作为对外展示的职务，否则以position来展示。不超过12个汉字
        /// </summary>
        [JsonProperty("external_position")]
        public string ExternalPosition { get; set; }
    }
}
