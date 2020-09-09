using chenheyun.QYWeixin.Media;
using chenheyun.QYWeixin.Models;
using System;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WebApiClient;
using WebApiClient.Parameterables;

namespace chenheyun.QYWeixin.Agents
{
    /// <summary>
    /// 表示企业里的一个应用。
    /// </summary>
    public partial class Agent
    {
        /// <summary>
        /// 应用Id。有些内置应用无ID，可留空。
        /// </summary>
        [XmlAttribute]
        public virtual string Id { get; set; }

        /// <summary>
        /// 应用名称。
        /// </summary>
        [XmlAttribute]
        public virtual string Name { get; set; }

        /// <summary>
        /// 应用secret，用来交换AccessToken以对应用进行API操作。
        /// </summary>
        [XmlAttribute]
        public string Secret { get; set; }

        /// <summary>
        /// Agent所属的Corporation.
        /// </summary>
        internal Corporation Corporation { get; set; }

        /// <summary>
        /// 获取Agent的AccessToken.
        /// </summary>
        /// <returns>AccessToken</returns>
        public async Task<AccessToken> GetAccessToken()
        {
            var accessToken = await WeixinApi.GetAccessToken(Corporation.CorpId, Secret);
            accessToken.GeneratedTime = DateTime.Now;
            return accessToken;
        }

        /// <summary>
        /// 上传临时素材。
        /// 注意：上传媒体文件不和具体应用有关，任意agent都可以上传。
        /// </summary>
        /// <param name="type">媒体文件类型，分别有图片（image）、语音（voice）、视频（video），普通文件（file）</param>
        /// <param name="file">文件名。</param>
        /// <returns>上传结果。</returns>
        public async Task<UploadMediaResponseModel> UploadMedia(string type, string file)
        {
            var at = await GetAccessToken();
            using (var media = new MulitpartFile(file))
            {
                return await WeixinApi.UploadMedia(at.Value, type, media);
            }
        }

        /// <summary>
        /// 上传图片得到图片URL，该URL永久有效。
        /// 每个企业每天最多可上传100张图片。
        /// </summary>
        /// <param name="imageFile">图片文件名。</param>
        /// <returns>返回的图片URL，仅能用于图文消息正文中的图片展示，或者给客户发送欢迎语等；若用于非企业微信环境下的页面，图片将被屏蔽。</returns>
        public async Task<UploadImageResponseModel> UploadImage(string imageFile)
        {
            var at = await GetAccessToken();
            using (var image = new MulitpartFile(imageFile))
            {
                return await WeixinApi.UploadImage(at.Value, image);
            }
        }

        private static IWeixinApi _weixinApi;
        internal IWeixinApi WeixinApi
        {
            get
            {
                if (_weixinApi == null)
                {

                    var factory = new HttpApiFactory<IWeixinApi>().ConfigureHttpApiConfig(c =>
                    {
                        // 企业微信api基地址基本固定，所以暂未放到配置文件里。
                        c.HttpHost = new Uri("https://qyapi.weixin.qq.com/cgi-bin/");
                        c.FormatOptions.DateTimeFormat = DateTimeFormats.ISO8601_WithMillisecond;
                    });

                    _weixinApi = factory.CreateHttpApi();
                }
                return _weixinApi;
            }
        }
    }
}


