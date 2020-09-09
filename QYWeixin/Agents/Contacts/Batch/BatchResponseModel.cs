using Newtonsoft.Json;

namespace chenheyun.QYWeixin.Agents.Contacts
{
    /// <summary>
    /// 异步批量通讯录更新响应。
    /// </summary>
    public class BatchResponseModel : ResponseModel
    {
        /// <summary>
        /// 异步任务id，最大长度为64字节
        /// </summary>
        [JsonProperty("jobid")]
        public string JobId { get; set; }
    }
}
