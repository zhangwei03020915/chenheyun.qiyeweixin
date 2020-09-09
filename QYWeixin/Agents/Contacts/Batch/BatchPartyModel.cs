
using chenheyun.QYWeixin.Agents.Contacts.Departments;

namespace chenheyun.QYWeixin.Agents.Contacts.Batch
{
    public class BatchPartyModel : DepartmentModel
    {
        public override string ToString()
        {
            return $"{Name},{Id},{ParentId},{Order}";
        }
    }
}
