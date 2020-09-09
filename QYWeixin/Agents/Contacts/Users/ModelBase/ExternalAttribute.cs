using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace chenheyun.QYWeixin.Agents.Contacts.Users.ModelBase
{
    public abstract class ExternalAttribute
    {
        /// <summary>
        /// 属性类型: 0-文本 1-网页 2-小程序。
        /// </summary>
        [JsonProperty("type")]
        public int Type { get; set; }

        /// <summary>
        /// 属性名称： 需要先确保在管理端有创建该属性，否则会忽略。
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 文本类型的属性。
        /// </summary>
        [JsonProperty("text")]
        public Text TextField { get; set; }

        /// <summary>
        /// 网页类型的属性，url和title字段要么同时为空表示清除该属性，要么同时不为空。
        /// </summary>
        [JsonProperty("web")]
        public Web WebField { get; set; }

        /// <summary>
        /// 小程序类型的属性，appid和title字段要么同时为空表示清除改属性，要么同时不为空。
        /// </summary>
        [JsonProperty("miniprogram")]
        public MiniProgram MiniProgramField { get; set; }

        public class Text
        {
            /// <summary>
            /// 文本属性内容,长度限制12个UTF8字符。
            /// </summary>
            [JsonProperty("value")]
            public string Value { get; set; }
        }

        public class Web
        {
            /// <summary>
            /// 网页的url,必须包含http或者https头。
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// 网页的展示标题,长度限制12个UTF8字符。
            /// </summary>
            [JsonProperty("title")]
            public string Title { get; set; }
        }

        /// <summary>
        /// 小程序类型的属性，appid和title字段要么同时为空表示清除改属性，要么同时不为空。
        /// </summary>
        public class MiniProgram
        {
            /// <summary>
            /// 小程序appid，必须是有在本企业安装授权的小程序，否则会被忽略。
            /// </summary>
            [JsonProperty("appid")]
            public string AppId { get; set; }

            /// <summary>
            /// 小程序的展示标题,长度限制12个UTF8字符。
            /// </summary>
            [JsonProperty("pagepath")]
            public string PagePath { get; set; }

            /// <summary>
            /// 小程序的页面路径。
            /// </summary>
            [JsonProperty("title")]
            public string Title { get; set; }
        }
    }
}
