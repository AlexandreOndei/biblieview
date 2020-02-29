using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BibleView.Request.Models
{
    [Serializable]
    public class Chapter
    {
        [XmlAttribute("number")]
        public int Number { get; set; }

        [XmlElement("Verse")]
        public List<Verse> VersesList { get; set; }

        public Chapter()
        {
            VersesList = new List<Verse>();
        }
    }
}
