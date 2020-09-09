using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApiClient.Attributes;

namespace chenheyun.QYWeixin.Agents.Contacts.Tags
{
    public class TagListModel : ResponseModel
    {
        [JsonProperty("taglist")]
        public List<TagModel> TagList { get; set; }

        public TagModel this[int tagId]
        {
            get => TagList.FirstOrDefault(t => t.TagId == tagId);
        }
    }
}
