﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BibleView.Request.Models
{
    [Serializable]
    public class Verse
    {
        [XmlAttribute("number")]
        public int Number { get; set; }

        public string Text { get; set; }
    }
}
