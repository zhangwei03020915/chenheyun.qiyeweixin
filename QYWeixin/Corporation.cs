using chenheyun.QYWeixin.Agents;
using chenheyun.QYWeixin.Agents.Contacts;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace chenheyun.QYWeixin
{
    [Serializable()]
    public class Corporation
    {
        private Corporation() { }

        /// <summary>
        /// Created a corporation definded in QiyeWeixin.
        /// </summary>
        /// <param name="settingsFile">The name of settings file.</param>
        /// <returns></returns>
        public static Corporation Create(string settingsFile)
        {
            if (Corp == null)
            {
                if (!File.Exists(settingsFile))
                {
                    throw new FileNotFoundException("The settings file was not found.", settingsFile);
                }

                XmlSerializer serializer = new XmlSerializer(typeof(Corporation));
                using (XmlReader reader = XmlReader.Create(settingsFile))
                {
                    Corp = serializer.Deserialize(reader) as Corporation;
                }
            }

            // Config every agents releated corp as created just now.
            Corp.Contacts.Corporation = Corp;
            Corp.Agents.ForEach(x => x.Corporation = Corp);

            return Corp;
        }

        /// <summary>
        /// corpId
        /// </summary>
        [XmlAttribute()]
        public string CorpId { get; set; }

        /// <summary>
        /// contacts agent。
        /// </summary>
        [XmlElement()]
        public ContactsAgent Contacts { get; set; }

        /// <summary>
        /// agents
        /// </summary>
        public AgentList Agents { get; set; }

        private static Corporation Corp { get; set; }
    }
}
