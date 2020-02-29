using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BibleView.Request.Models
{
    [Serializable]
    public class Version
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlIgnore]
        public string URL { get; set; }
        
        [XmlElement("Book")]
        public List<Book> BooksList { get; set; }
    }
}
