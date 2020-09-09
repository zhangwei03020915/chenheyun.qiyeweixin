using Newtonsoft.Json;

namespace chenheyun.QYWeixin.Agents.Contacts
{
    /// <summary>
    /// 全量请求模型。
    /// </summary>
    public abstract class BatchRequestModel
    {
        /// <summary>
        /// 上传的csv文件的media_id
        /// </summary>
        [JsonProperty("media_id")]
        public string MediaId { get; set; }

        /// <summary>
        /// 批量处理结果回调配置信息。
        /// </summary>
        [JsonProperty("callback")]
        public CallbackModel Callback { get; set; }
    }
}
