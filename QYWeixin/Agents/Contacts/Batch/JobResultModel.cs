using Newtonsoft.Json;

namespace chenheyun.QYWeixin.Agents.Contacts
{
    /// <summary>
    /// 查询作业结果响应模型。
    /// </summary>
    public class JobResultModel : ResponseModel
    {
        /// <summary>
        /// 任务状态，整型，
        /// 1表示任务开始，
        /// 2表示任务进行中，
        /// 3表示任务已完成
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; set; }

        /// <summary>
        /// 操作类型，字节串，目前分别有：
        /// 1. sync_user(增量更新成员) 
        /// 2. replace_user(全量覆盖成员)
        /// 3. replace_party(全量覆盖部门)
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// 任务运行总条数
        /// </summary>
        [JsonProperty("total")]
        public long Total { get; set; }

        /// <summary>
        /// 目前运行百分比，当任务完成时为100
        /// </summary>
        [JsonProperty("percentage")]
        public int Percentage { get; set; }

        /// <summary>
        /// 详细的处理结果，具体格式参考下面说明。当任务完成后此字段有效。
        /// </summary>
        [JsonProperty("result")]
        public dynamic[] Result { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class UserBatchResultModel : ResponseModel
    {
        [JsonProperty("userid")]
        string UserId { get; set; }
    }

    public class PartyBatchResultModel : ResponseModel
    {
        /// <summary>
        /// 操作类型（按位或）：
        /// 1 新建部门 ，
        /// 2 更改部门名称， 
        /// 4 移动部门， 
        /// 8 修改部门排序
        /// </summary>
        public int Action { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public int PartyId { get; set; }
    }
}
