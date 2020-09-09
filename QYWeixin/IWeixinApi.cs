using chenheyun.QYWeixin.Agents.Contacts;
using chenheyun.QYWeixin.Agents.Contacts.Departments;
using chenheyun.QYWeixin.Agents.Contacts.Tags;
using chenheyun.QYWeixin.Agents.Contacts.Users;
using chenheyun.QYWeixin.Media;
using chenheyun.QYWeixin.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using WebApiClient;
using WebApiClient.Attributes;
using WebApiClient.Parameterables;

namespace chenheyun.QYWeixin
{
    public partial interface IWeixinApi : IHttpApi
    {
        [HttpGet("gettoken?corpid={corpid}&corpsecret={corpsecret}")]
        ITask<AccessToken> GetAccessToken([Required] string corpid, [Required] string corpsecret);

        #region 部门

        /// <summary>
        /// 创建部门
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="department">部门数据：
        /// {
        ///   "name": "广州研发中心",
        ///   "name_en": "RDGZ",
        ///   "parentid": 1,
        ///   "order": 1,
        ///   "id": 2
        /// }
        /// </param>
        /// <returns>
        /// {
        ///   "errcode": 0,
        ///   "errmsg": "created",
        ///   "id": 2
        /// }
        /// </returns>
        [HttpPost("department/create?access_token={accessToken}")]
        ITask<CreateDepartmentResponseModel> CreateDepartment(
            [Required] string accessToken,
            [JsonContent, Required] DepartmentModel department);

        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="accessToken">调用接口凭证。</param>
        /// <param name="department">部门数据。</param>
        /// <returns>
        /// {
        ///   "errcode": 0,
        ///   "errmsg": "updated"
        /// }
        /// </returns>
        [HttpPost("department/update?access_token={accessToken}")]
        ITask<ResponseModel> UpdateDepartment(
            [Required] string accessToken,
            [JsonContent, Required] DepartmentModel department);

        /// <summary>
        /// 删除部门。
        /// </summary>
        /// <param name="accessToken">调用接口凭证。</param>
        /// <param name="departmentId">部门id。（注：不能删除根部门；不能删除含有子部门、成员的部门）</param>
        /// <returns>
        /// {
        ///   "errcode": 0,
        ///   "errmsg": "deleted"
        /// }
        /// </returns>
        [HttpGet("department/delete?access_token={accessToken}&id={departmentId}")]
        ITask<ResponseModel> DeleteDepartment(
            [Required] string accessToken,
            [Required] int departmentId);

        /// <summary>
        /// 获取指定部门及其下的子部门
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="departmentId">
        /// 部门id。如果不填，默认获取全量组织架构
        /// </param>
        /// <returns></returns>
        [HttpGet("department/list?access_token={accessToken}&id={departmentId}")]
        ITask<DepartmentListModel> ListDepartment([Required] string accessToken, [Optional] int? departmentId);
        #endregion 部门

        #region 用户
        /// <summary>
        /// 创建用户。
        /// </summary>
        /// <param name="accessToken">调用接口凭证。</param>
        /// <param name="user">用户信息。</param>
        /// <returns>响应模型。</returns>
        [HttpPost("user/create?access_token={accessToken}")]
        ITask<ResponseModel> CreateUser(
            [Required] string accessToken,
            [JsonContent] UserCreateModel user);

        /// <summary>
        /// 获取成员详细信息。
        /// </summary>
        /// <param name="accessToken">调用接口凭证。</param>
        /// <param name="userId">用户Id.</param>
        /// <returns>用户详情。</returns>
        [HttpGet("user/get?access_token={accessToken}&userid={userId}")]
        ITask<UserDetailModel> GetUser(
            [Required] string accessToken,
            [Required] string userId);

        /// <summary>
        /// 更新成员。
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="user">用户信息。</param>
        /// <returns>响应模型。</returns>
        [HttpPost("user/update?access_token={accessToken}")]
        ITask<ResponseModel> UpdateUser(
            [Required] string accessToken,
            [JsonContent, Required] UserUpdateModel user);

        /// <summary>
        /// 删除用户。
        /// </summary>
        /// <param name="accessToken">调用接口凭证。</param>
        /// <param name="userId">用户Id.</param>
        /// <returns>响应模型。</returns>
        [HttpGet("user/delete?access_token={accessToken}&userid={userId}")]
        ITask<ResponseModel> DeleteUser(
            [Required] string accessToken,
            [Required] string userId);

        /// <summary>
        /// 批量删除成员。
        /// </summary>
        /// <param name="accessToken">调用接口凭证。</param>
        /// <param name="useridlist">
        /// 成员UserID列表。对应管理端的帐号。
        /// 最多支持200个。若存在无效UserID，直接返回错误。
        /// </param>
        /// <returns>响应模型。</returns>
        [HttpPost("user/batchdelete?access_token={accessToken}")]
        ITask<ResponseModel> BatchDeleteUsers(
            [Required] string accessToken,
            [JsonContent] dynamic useridlist);

        /// <summary>
        /// 获取部门成员。应用须拥有指定部门的查看权限。
        /// </summary>
        /// <param name="accessToken">调用接口凭证。</param>
        /// <param name="departmentId">获取的部门Id.</param>
        /// <param name="fetch">是否递归获取子部门下面的成员：1-递归获取，0-只获取本部门</param>
        /// <returns>部门成员响应模型。</returns>
        [HttpGet("user/simplelist?access_token={accessToken}&department_id={departmentId}&fetch_child={fetch}")]
        ITask<DepartmentMemberListModel> SimpleListUser(
            [Required] string accessToken,
            [Required] int departmentId,
            [Required] int fetch = 1);

        /// <summary>
        /// 获取部门成员详情。应用须拥有指定部门的查看权限。
        /// </summary>
        /// <param name="accessToken">调用接口凭证。</param>
        /// <param name="departmentId">获取的部门Id.</param>
        /// <param name="fetch">是否递归获取子部门下面的成员：1-递归获取，0-只获取本部门</param>
        /// <returns>部门成员详情响应模型。</returns>
        [HttpGet("user/list?access_token={accessToken}&department_id={departmentId}&fetch_child={fetch}")]
        ITask<DepartmentMemberDetailListModel> ListUser(
            [Required] string accessToken,
            [Required] int departmentId,
            [Required] int fetch = 1);

        /// <summary>
        /// 该接口使用场景为企业支付，在使用企业红包和向员工付款时，需要自行将企业微信的userid转成openid。
        /// </summary>
        /// <param name="accessToken">调用接口凭证。</param>
        /// <param name="userId">企业内的成员id.</param>
        /// <returns>OpenId响应模型。</returns>
        [HttpPost("user/convert_to_openid?access_token={accessToken}")]
        ITask<OpenIdModel> ConvertToOpenId(
            [Required] string accessToken,
            [Required, JsonContent] dynamic userId);

        /// <summary>
        /// 该接口主要应用于使用企业支付之后的结果查询。
        /// 开发者需要知道某个结果事件的openid对应企业微信内成员的信息时，可以通过调用该接口进行转换查询。
        /// </summary>
        /// <param name="accessToken">调用接口凭证。</param>
        /// <param name="userId">{userid:'userid'}在使用企业支付之后，返回结果的openid.</param>
        /// <returns>OpenId响应模型，该openid在企业微信对应的成员userid.</returns>
        [HttpPost("user/convert_to_userid?access_token={accessToken}")]
        ITask<UserIdModel> ConvertToUserId(
            [Required] string accessToken,
            [Required, JsonContent] dynamic userId);
        #endregion 用户

        #region 标签
        /// <summary>
        /// 创建标签。
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="tagModel">标签模型。</param>
        /// <returns>创建结果响应模型。</returns>
        [HttpPost("tag/create?access_token={accessToken}")]
        ITask<TagCreateResponseModel> CreateTag(
            [Required] string accessToken,
            [Required, JsonContent] TagModel tagModel);
        /// <summary>
        /// 更新标签名字。
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="tagModel">标签模型。</param>
        /// <returns>响应模型。</returns>
        [HttpPost("tag/update?access_token={accessToken}")]
        ITask<ResponseModel> UpdateTag(
            [Required] string accessToken,
            [Required, JsonContent] TagModel tagModel);

        /// <summary>
        /// 删除标签.
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="tagId">标签Id。</param>
        /// <returns>响应模型。</returns>、
        [HttpGet("tag/delete?access_token={accessToken}&tagid={tagId}")]
        ITask<ResponseModel> DeleteTag(
            [Required] string accessToken,
            [Required] int tagId);

        /// <summary>
        /// 获取标签成员。
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="tagId">标签Id。</param>
        /// <returns>标签成员响应模型。</returns>
        [HttpGet("tag/get?access_token={accessToken}&tagid={tagId}")]
        ITask<TagDetailModel> GetTag(
            [Required] string accessToken,
            [Required] int tagId);

        /// <summary>
        /// 增加标签成员
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="model">创建模型。</param>
        /// <returns>创建结果响应模型。</returns>
        [HttpGet("tag/addtagusers?access_token={accessToken}")]
        ITask<TagMemberManagementResponseModel> AddTagMember(
            [Required] string accessToken,
            [Required, JsonContent] TagMemberManagementModel model);

        /// <summary>
        /// 删除标签成员
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="model">创建模型。</param>
        /// <returns>创建结果响应模型。</returns>
        [HttpGet("tag/addtagusers?access_token={accessToken}")]
        ITask<TagMemberManagementResponseModel> DelTagMember(
            [Required] string accessToken,
            [Required, JsonContent] TagMemberManagementModel model);

        /// <summary>
        /// 获取标签列表。
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <returns>标签清单模型。</returns>
        [HttpGet("tag/list?access_token={accessToken}")]
        ITask<TagListModel> ListTags([Required] string accessToken);
        #endregion

        #region 批量处理
        /// <summary>
        /// 全量覆盖部门
        /// </summary>
        /// <param name="accessToken">调用接口凭证。</param>
        /// <param name="request">请求内容。</param>
        /// <returns></returns>
        [HttpPost("batch/replaceparty?access_token={accessToken}")]
        ITask<BatchResponseModel> BatchReplaceParty(
            [Required] string accessToken,
            [JsonContent, Required] BatchReplacePartyRequestModel request);

        /// <summary>
        /// 增量更新成员
        /// </summary>
        /// <param name="accessToken">调用接口凭证。</param>
        /// <param name="request">请求内容。</param>
        /// <returns></returns>
        [HttpPost("batch/syncuser?access_token={accessToken}")]
        ITask<BatchResponseModel> BatchSyncUser(
            [Required] string accessToken,
            [JsonContent, Required] BatchSyncUserRequestModel request);

        /// <summary>
        /// 全量覆盖成员
        /// </summary>
        /// <param name="accessToken">调用接口凭证。</param>
        /// <param name="request">请求内容。</param>
        /// <returns></returns>
        [HttpPost("batch/replaceuser?access_token={accessToken}")]
        ITask<BatchResponseModel> BatchReplaceUser(
            [Required] string accessToken,
            [JsonContent, Required] BatchReplaceUserRequestModel request);

        /// <summary>
        /// 获取异步任务结果
        /// </summary>
        /// <param name="accessToken">调用接口凭证。</param>
        /// <param name="jobId">异步任务id，最大长度为64字节。</param>
        /// <returns></returns>
        [HttpPost("batch/getresult?access_token={accessToken}&jobid={jobId}")]
        ITask<JobResultModel> GetBatchResult(
            [Required] string accessToken,
            [Required] string jobId);
        #endregion 批量处理

        #region 素材管理
        /// <summary>
        /// 上传临时素材。
        /// POST的请求包中，form-data中媒体文件标识，应包含有 filename、filelength、content-type等信息。
        /// filename标识文件展示的名称。比如，使用该media_id发消息时，展示的文件名由该字段控制。
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="type">媒体文件类型，分别有图片（image）、语音（voice）、视频（video），普通文件（file）</param>
        /// <param name="media">上传的文件信息。</param>
        /// <returns></returns>
        /// <remarks>
        /// 文件限制：所有文件size必须大于5个字节
        ///   图片（image）：2MB，支持JPG,PNG格式
        ///   语音（voice） ：2MB，播放长度不超过60s，仅支持AMR格式
        ///   视频（video） ：10MB，支持MP4格式
        ///   普通文件（file）：20MB
        /// </remarks>
        [HttpPost("media/upload?access_token={accessToken}&type={type}")]
        ITask<UploadMediaResponseModel> UploadMedia([Required] string accessToken,
            [Required] string type,
            MulitpartFile media);

        /// <summary>
        /// 上传图片得到图片URL，该URL永久有效。
        /// 返回的图片URL，仅能用于图文消息正文中的图片展示，或者给客户发送欢迎语等。
        /// 若用于非企业微信环境下的页面，图片将被屏蔽。
        /// 每个企业每天最多可上传100张图片。
        /// 图片文件大小应在 5B ~ 2MB 之间。
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="image">图片。</param>
        /// <returns>上传后得到的图片URL。永久有效。</returns>
        [HttpPost("media/uploadimg?access_token={accessToken}&type={type}")]
        ITask<UploadImageResponseModel> UploadImage([Required] string accessToken,
            MulitpartFile image);
        #endregion
    }
}
