using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace chenheyun.QYWeixin.Agents.Contacts.Users
{
    /// <summary>
    /// 部门成员模型。
    /// </summary>
    public class DepartmentMemberListModel : ResponseModel
    {
        [JsonProperty("userlist")]
        public List<DepartmentMemberModel> Users { get; set; }

        public int Count
        {
            get => Users.Count;
        }

        public DepartmentMemberModel this[string userId]
        {
            get => this.Users.FirstOrDefault(u => u.UserId.Equals(userId, System.StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
