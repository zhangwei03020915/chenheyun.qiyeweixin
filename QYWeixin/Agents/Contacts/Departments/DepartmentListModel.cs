using chenheyun.QYWeixin.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace chenheyun.QYWeixin.Agents.Contacts.Departments
{
    public class DepartmentListModel : ResponseModel
    {
        [JsonProperty("department")]
        public List<DepartmentModel> Departments
        {
            get; set;
        }

        public DepartmentModel this[int id]
        {
            get
            {
                return Departments.FirstOrDefault(x => x.Id == id);
            }
            set
            {
                var item = Departments.FirstOrDefault(x => x.Id == id);
                item = value;
            }
        }

        public DepartmentModel this[string name]
        {
            get
            {
                return Departments.FirstOrDefault(x => x.Name.Equals(name, System.StringComparison.InvariantCultureIgnoreCase));
            }
            set
            {
                var item = Departments.FirstOrDefault(x => x.Name.Equals(name, System.StringComparison.InvariantCultureIgnoreCase));
                item = value;
            }
        }
    }
}
