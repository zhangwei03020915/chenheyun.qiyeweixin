using chenheyun.QYWeixin.Agents.Contacts.Users.ModelBase;
using Newtonsoft.Json;

namespace chenheyun.QYWeixin.Agents.Contacts.Users
{
    /// <summary>
    /// 用户详情的模型。
    /// </summary>
    public class UserDetailModel : UserModelBase
    {
        /// <summary>
        /// 头像url。 第三方仅通讯录应用可获取。
        /// </summary>
        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        /// <summary>
        /// 头像缩略图url。第三方仅通讯录应用可获取。
        /// </summary>
        [JsonProperty("thumb_avatar")]
        public string ThumbAvatar { get; set; }

        /// <summary>
        /// 员工个人二维码，扫描可添加为外部联系人(注意返回的是一个url，可在浏览器上打开该url以展示二维码)；第三方仅通讯录应用可获取。
        /// </summary>
        [JsonProperty("qr_code")]
        public string QRCode { get; set; }

        /// <summary>
        /// 全局唯一。对于同一个服务商，不同应用获取到企业内同一个成员的open_userid是相同的，最多64个字节。仅第三方应用可获取。
        /// </summary>
        [JsonProperty("open_userid")]
        public string UserOpenId { get; set; }

        /// <summary>
        /// 错误代码。
        /// </summary>
        [JsonProperty("errcode")]
        public int ErrorCode { get; set; }

        /// <summary>
        /// 错误信息。
        /// </summary>
        [JsonProperty("errmsg")]
        public string ErrorMessage { get; set; }
    }
}
