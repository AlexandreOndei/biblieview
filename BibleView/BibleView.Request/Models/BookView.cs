using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleView.Request.Models
{
    public class BookView
    {
        public string Name { get; set; }
        public Dictionary<int, int> ChapterList { get; set; }
    }
}
