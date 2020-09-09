using Newtonsoft.Json;

namespace chenheyun.QYWeixin.Agents.Contacts.Departments
{
    public class DepartmentModel
    {
        /// <summary>
        /// 部门id，32位整型，指定时必须大于1。
        /// 更新部门时必须指定；创建时，若不填该参数，将自动生成id。
        /// </summary>
        [JsonProperty("id")]
        public int? Id { get; set; }

        /// <summary>
        /// 部门名称。同一个层级的部门名称不能重复。长度限制为1~32个字符，字符不能包括\:?”<>｜
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 英文名称。同一个层级的部门名称不能重复。需要在管理后台开启多语言支持才能生效。长度限制为1~32个字符，字符不能包括\:?”<>｜
        /// </summary>
        [JsonProperty("name_en")]
        public string NameEN { get; set; }

        /// <summary>
        /// 父部门id，32位整型
        /// </summary>
        [JsonProperty("parentid")]
        public int? ParentId { get; set; }

        /// <summary>
        /// 在父部门中的次序值。order值大的排序靠前。有效的值范围是[0, 2^32)
        /// </summary>
        [JsonProperty("order")]
        public int Order { get; set; }
    }
}
