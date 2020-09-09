using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace chenheyun.QYWeixin.Agents.Contacts.Users.ModelBase
{
    /// <summary>
    /// 创建或更新用户的基础模型。
    /// </summary>
    public abstract class UserCreateOrUpdateModelBase : UserModelBase
    {
        /// <summary>
        /// 头像媒体文件Id
        /// </summary>
        [JsonProperty("avatar_mediaid")]
        public string AvatarMediaId { get; set; }
    }
}
