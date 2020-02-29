using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BibleView.Request.Models
{
    [Serializable]
    public class Book
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlIgnore]
        public string URL { get; set; }

        [XmlIgnore]
        public int ChaptersCount { get; set; }

        [XmlElement("Chapter")]
        public List<Chapter> ChaptersList { get; set; }

        public Book()
        {
            ChaptersList = new List<Chapter>();
        }
    }
}
