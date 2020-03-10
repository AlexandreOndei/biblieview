using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleView.Request.Extensions
{
    public static class ListExtensions
    {
        public static Models.Chapter GetChapter(this List<Models.Version> versionList, string versionName, string bookName, int chapterNumber)
        {
            return versionList.Where(version => version.Name == versionName)
                .SelectMany(version => version.BooksList)
                .Where(book => book.Name == bookName)
                .SelectMany(book => book.ChaptersList)
                .FirstOrDefault(chapter => chapter.Number == chapterNumber);
        }
    }
}
