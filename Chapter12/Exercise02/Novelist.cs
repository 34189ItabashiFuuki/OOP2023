using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exercise02 {
    [XmlRoot("novelist")]
    [DataContract]
    public class Novelist {
        [XmlElement(ElementName = "name")]
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "birth")]
        public DateTime Birth { get; set; }
        [XmlArray("masterpieces")]
        [XmlArrayItem("title", typeof(string))]
        [DataMember(Name = "masterpieces")]
        public string[] Masterpieces { get; set; }
    }
}
