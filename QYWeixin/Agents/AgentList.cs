using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace chenheyun.QYWeixin.Agents
{
    public class AgentList : List<Agent>
    {
        public Agent this[string id]
        {
            get
            {
                var agent = this.FirstOrDefault(x => x.Id.Equals(id, System.StringComparison.InvariantCultureIgnoreCase));
                if(agent == null)
                {
                    throw new IndexOutOfRangeException();
                }

                return agent;
            }
        }
    }
}


