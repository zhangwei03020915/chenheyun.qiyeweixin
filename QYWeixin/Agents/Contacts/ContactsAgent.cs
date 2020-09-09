using chenheyun.QYWeixin.Agents.Contacts.Departments;
using chenheyun.QYWeixin.Agents.Contacts.Tags;
using chenheyun.QYWeixin.Agents.Contacts.Users;
using System;
using System.Threading.Tasks;

namespace chenheyun.QYWeixin.Agents.Contacts
{
    /// <summary>
    /// 联系人应用。
    /// </summary>
    public partial class ContactsAgent : Agent
    {
        #region 成员管理
        /// <summary>
        /// 创建成员。
        /// </summary>
        /// <param name="createModel">成员创建模型。</param>
        /// <returns>响应模型。</returns>
        public async Task<ResponseModel> CreateUser(UserCreateModel createModel)
        {
            var accessToken = await GetAccessToken();
            return await WeixinApi.CreateUser(accessToken.Value, createModel);
        }

        /// <summary>
        /// 获取成员信息。
        /// </summary>
        /// <param name="userId">成员Id。</param>
        /// <returns>响应模型。</returns>
        public async Task<UserDetailModel> GetUser(string userId)
        {
            var accessToken = await GetAccessToken();
            return await WeixinApi.GetUser(accessToken.Value, userId);
        }

        /// <summary>
        /// 更新成员。
        /// </summary>
        /// <param name="updateModel">成员更新模型。</param>
        /// <returns>响应模型。</returns>
        public async Task<ResponseModel> UpdateUser(UserUpdateModel updateModel)
        {
            var accessToken = await GetAccessToken();
            return await WeixinApi.UpdateUser(accessToken.Value, updateModel);
        }

        /// <summary>
        /// 删除成员。
        /// </summary>
        /// <param name="userId">成员UserID。对应管理端的帐号</param>
        /// <returns>响应模型。</returns>
        public async Task<ResponseModel> DeleteUser(string userId)
        {
            var accessToken = await GetAccessToken();
            return await WeixinApi.DeleteUser(accessToken.Value, userId);
        }

        /// <summary>
        /// 批量删除成员。
        /// </summary>
        /// <param name="useridlist"></param>
        /// <returns>响应模型。</returns>
        public async Task<ResponseModel> DeleteUsers(params string[] useridlist)
        {
            var accessToken = await GetAccessToken();
            return await WeixinApi.BatchDeleteUsers(accessToken.Value, new { useridlist = useridlist });
        }

        /// <summary>
        /// 获取部门成员。
        /// </summary>
        /// <param name="departmentId">获取的部门id</param>
        /// <param name="fetchChild">是否递归获取子部门下面的成员：1-递归获取，0-只获取本部门</param>
        /// <returns>部门成员清单。</returns>
        public async Task<DepartmentMemberListModel> ListDepartmentMembers(int departmentId, int fetchChild = 1)
        {
            var accessToken = await GetAccessToken();
            return await WeixinApi.SimpleListUser(accessToken.Value, departmentId, fetchChild);
        }

        /// <summary>
        /// 获取部门成员详情。
        /// </summary>
        /// <param name="departmentId">获取的部门id</param>
        /// <param name="fetchChild">是否递归获取子部门下面的成员：1-递归获取，0-只获取本部门</param>
        /// <returns>部门成员清单。</returns>
        public async Task<DepartmentMemberDetailListModel> ListDepartmentMembersDetail(int departmentId, int fetchChild = 1)
        {
            var accessToken = await GetAccessToken();
            return await WeixinApi.ListUser(accessToken.Value, departmentId, fetchChild);
        }

        /// <summary>
        /// userid转openid
        /// </summary>
        /// <param name="userid">企业内的成员id</param>
        /// <returns>企业微信成员userid对应的openid</returns>
        /// <remarks>
        /// 该接口使用场景为企业支付，在使用企业红包和向员工付款时，需要自行将企业微信的userid转成openid。
        /// 注：需要成员使用微信登录企业微信或者关注微工作台（原企业号）才能转成openid;
        /// 如果是外部联系人，请使用外部联系人openid转换转换openid
        /// </remarks>
        public async Task<OpenIdModel> ConvertToOpenid(string userid)
        {
            var accessToken = await GetAccessToken();
            var openid = await WeixinApi.ConvertToOpenId(accessToken.Value, new { userid = userid });
            return openid;
        }

        /// <summary>
        /// 该接口主要应用于使用企业支付之后的结果查询。
        //开发者需要知道某个结果事件的openid对应企业微信内成员的信息时，可以通过调用该接口进行转换查询。
        /// </summary>
        /// <param name="openid">在使用企业支付之后，返回结果的openid</param>
        /// <returns>该openid在企业微信对应的成员userid</returns>
        public async Task<UserIdModel> ConvertToUserId(string openid)
        {
            var accessToken = await GetAccessToken();
            var userid = await WeixinApi.ConvertToUserId(accessToken.Value, new { openid = openid });
            return userid;
        }
        #endregion

        #region 部门管理
        /// <summary>
        /// 创建部门。
        /// </summary>
        /// <param name="department">部门信息。</param>
        /// <returns>创建结果，包含部门Id。</returns>
        public async Task<CreateDepartmentResponseModel> CreateDepartment(DepartmentModel department)
        {
            var accessToken = await GetAccessToken();
            return await WeixinApi.CreateDepartment(accessToken.Value, department);
        }

        /// <summary>
        /// 创建部门。
        /// </summary>
        /// <param name="department">部门信息。</param>
        /// <returns>创建结果，包含部门Id。</returns>
        public async Task<ResponseModel> UpdateDepartment(DepartmentModel department)
        {
            var accessToken = await GetAccessToken();
            return await WeixinApi.UpdateDepartment(accessToken.Value, department);
        }

        /// <summary>
        /// 删除部门。
        /// </summary>
        /// <param name="departmentId">部门Id。</param>
        /// <returns>响应模型。</returns>
        public async Task<ResponseModel> DeleteDepartment(int departmentId)
        {
            var accessToken = await GetAccessToken();
            return await WeixinApi.DeleteDepartment(accessToken.Value, departmentId);
        }

        /// <summary>
        /// 获取组织下的所有部门。
        /// </summary>
        /// <returns>组织下的部门清单。</returns>
        public async Task<DepartmentListModel> ListDepartments(int? departmentId = null)
        {
            var accessToken = await GetAccessToken();
            var departments = await WeixinApi.ListDepartment(accessToken.Value, departmentId);
            return departments;
        }
        #endregion

        #region 标签管理
        /// <summary>
        /// 创建标签。
        /// </summary>
        /// <param name="tagName">标签名</param>
        /// <param name="tagId">标签id，如果是null则自动生成一个id。</param>
        /// <returns>创建结果响应模型。</returns>
        public async Task<TagCreateResponseModel> CreateTag(string tagName, int? tagId)
        {
            var accessToken = await GetAccessToken();
            var model = new TagModel() { TagName = tagName };
            if (tagId.HasValue)
            {
                model.TagId = tagId.Value;
            }
            return await WeixinApi.CreateTag(accessToken.Value, model);
        }
        /// <summary>
        /// 更新标签名字。
        /// </summary>
        /// <param name="tagName">标签名</param>
        /// <param name="tagId">标签id。</param>
        /// <returns>响应模型。</returns>
        public async Task<ResponseModel> UpdateTag(string tagName, int tagId)
        {
            var accessToken = await GetAccessToken();
            var model = new TagModel() { TagName = tagName, TagId = tagId };
            return await WeixinApi.UpdateTag(accessToken.Value, model);
        }

        /// <summary>
        /// 删除标签。
        /// </summary>
        /// <param name="tagId">标签id。</param>
        /// <returns>响应模型。</returns>
        public async Task<ResponseModel> DeleteTag(int tagId)
        {
            var accessToken = await GetAccessToken();
            return await WeixinApi.DeleteTag(accessToken.Value, tagId);
        }

        /// <summary>
        /// 获取标签成员。
        /// </summary>
        /// <param name="tagId">标签Id。</param>
        /// <returns>标签成员结果模型。</returns>
        public async Task<TagDetailModel> GetTagMembers(int tagId)
        {
            var accessToken = await GetAccessToken();
            return await WeixinApi.GetTag(accessToken.Value, tagId);
        }

        /// <summary>
        /// 增加标签成员
        /// </summary>
        /// <param name="tagId">标签ID</param>
        /// <param name="userlist">企业成员ID列表，注意：userlist、partylist不能同时为空，单次请求个数不超过1000</param>
        /// <param name="partylist">企业部门ID列表，注意：userlist、partylist不能同时为空，单次请求个数不超过100</param>
        /// <returns>增加标签成员结果模型。</returns>
        public async Task<TagMemberManagementResponseModel> AddTagMember(int tagId, string[] userlist = null, int[] partylist = null)
        {
            if ((userlist == null || userlist.Length == 0) && (partylist == null || partylist.Length == 0))
            {
                throw new ArgumentException("userlist和partylist不能同时为空。");
            }

            var accessToken = await GetAccessToken();
            var model = new TagMemberManagementModel()
            {
                TagId = tagId,
                PartyList = partylist,
                UserList = userlist
            };
            return await WeixinApi.AddTagMember(accessToken.Value, model);
        }

        /// <summary>
        /// 删除标签成员
        /// </summary>
        /// <param name="tagId">标签ID</param>
        /// <param name="userlist">企业成员ID列表，注意：userlist、partylist不能同时为空，单次请求个数不超过1000</param>
        /// <param name="partylist">企业部门ID列表，注意：userlist、partylist不能同时为空，单次请求个数不超过100</param>
        /// <returns>删除标签成员结果模型。</returns>
        public async Task<TagMemberManagementResponseModel> DeleteTagMember(int tagId, string[] userlist = null, int[] partylist = null)
        {
            if ((userlist == null || userlist.Length == 0) && (partylist == null || partylist.Length == 0))
            {
                throw new ArgumentException("userlist和partylist不能同时为空。");
            }

            var accessToken = await GetAccessToken();
            var model = new TagMemberManagementModel()
            {
                TagId = tagId,
                PartyList = partylist,
                UserList = userlist
            };
            return await WeixinApi.DelTagMember(accessToken.Value, model);
        }

        /// <summary>
        /// 获取所有标签。
        /// </summary>
        /// <returns>标签清单模型。</returns>
        public async Task<TagListModel> ListTags()
        {
            var accessToken = await GetAccessToken();
            return await WeixinApi.ListTags(accessToken.Value);
        }
        #endregion

        #region 异步批量处理
        /// <summary>
        /// 增量更新成员。
        /// </summary>
        /// <param name="mediaId">临时媒体资源Id。</param>
        /// <param name="toInvite">是否邀请新建的成员使用企业微信（将通过微信服务通知或短信或邮件下发邀请，每天自动下发一次，最多持续3个工作日），默认值为true。</param>
        /// <returns></returns>
        public async Task<BatchResponseModel> BatchSyncUser(string mediaId, bool toInvite = true)
        {
            var accessToken = await GetAccessToken();
            var model = new BatchSyncUserRequestModel
            {
                ToInvite = toInvite,
                MediaId = mediaId
            };
            return await WeixinApi.BatchSyncUser(accessToken.Value, model);
        }

        /// <summary>
        /// 批量覆盖所有用户。
        /// </summary>
        /// <param name="mediaId">临时媒体资源Id。</param>
        /// <returns>覆盖结果。</returns>
        public async Task<BatchResponseModel> BatchReplaceUser(string mediaId)
        {
            var accessToken = await GetAccessToken();
            BatchReplaceUserRequestModel model = new BatchReplaceUserRequestModel
            {
                MediaId = mediaId
            };
            return await WeixinApi.BatchReplaceUser(accessToken.Value, model);
        }

        /// <summary>
        /// 批量覆盖所有部门。
        /// </summary>
        /// <param name="mediaId">临时媒体资源Id。</param>
        /// <returns>覆盖结果。</returns>
        public async Task<BatchResponseModel> BatchReplaceParty(string mediaId)
        {
            var accessToken = await GetAccessToken();
            BatchReplacePartyRequestModel model = new BatchReplacePartyRequestModel
            {
                MediaId = mediaId
            };
            return await WeixinApi.BatchReplaceParty(accessToken.Value, model);
        }

        /// <summary>
        /// 获取批量事务的执行进度。
        /// </summary>
        /// <param name="jobId">事务Id。</param>
        /// <returns>事务结果。</returns>
        public async Task<JobResultModel> GetBatchResult(string jobId)
        {
            var accessToken = await GetAccessToken();
            return await WeixinApi.GetBatchResult(accessToken.Value, jobId);
        }
        #endregion 异步批量处理
    }
}


