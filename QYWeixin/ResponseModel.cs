using Newtonsoft.Json;

namespace chenheyun.QYWeixin
{
    public class ResponseModel
    {
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

        /// <summary>
        /// 返回信息是否包含错误。
        /// </summary>
        [JsonIgnore]
        public bool HasError
        {
            get
            {
                return ErrorCode != 0;
            }
        }
    }
}
