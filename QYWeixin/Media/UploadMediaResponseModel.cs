using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace chenheyun.QYWeixin.Media
{
    public class UploadMediaResponseModel : ResponseModel
    {
        /// <summary>
        /// 媒体文件类型，分别有图片（image）、语音（voice）、视频（video），普通文件（file）
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// 媒体文件上传后获取的唯一标识，3天内有效
        /// </summary>
        [JsonProperty("media_id")]
        public string MediaId { get; set; }

        /// <summary>
        /// 媒体文件上传时间戳
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
    }
}
