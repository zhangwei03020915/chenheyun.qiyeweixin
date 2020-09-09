using Newtonsoft.Json;

namespace chenheyun.QYWeixin.Agents.Contacts.Departments
{
    public class CreateDepartmentResponseModel : ResponseModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
