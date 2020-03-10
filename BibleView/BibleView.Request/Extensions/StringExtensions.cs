using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleView.Request.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveAccents(this string text)
        {
            var arrayText = text.Normalize(NormalizationForm.FormD)
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray();
            return new string(arrayText);
        }
    }
}
