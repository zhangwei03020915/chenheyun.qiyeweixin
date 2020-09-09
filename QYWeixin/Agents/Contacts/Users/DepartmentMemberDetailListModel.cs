using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace chenheyun.QYWeixin.Agents.Contacts.Users
{
    /// <summary>
    /// 部门成员详情模型。
    /// </summary>
    public class DepartmentMemberDetailListModel : ResponseModel
    {
        [JsonProperty("userlist")]
        public List<DepartmentMemberDetailModel> Users { get; set; }

        public int Count
        {
            get => Users.Count;
        }

        public DepartmentMemberDetailModel this[string userId]
        {
            get => this.Users.FirstOrDefault(u => u.UserId.Equals(userId, System.StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
