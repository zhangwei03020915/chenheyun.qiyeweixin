using Newtonsoft.Json;

namespace chenheyun.QYWeixin.Agents.Contacts
{
    public class CallbackModel
    {
        /// <summary>
        /// 企业应用接收企业微信推送请求的访问协议和地址，支持http或https协议
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// 用于生成签名
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }

        /// <summary>
        /// 用于消息体的加密，是AES密钥的Base64编码
        /// </summary>
        [JsonProperty("encodingaeskey")]
        public string EncodingEASKey { get; set; }
    }
}
