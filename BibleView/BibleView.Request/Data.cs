using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleView.Request
{
    public static class Data
    {
        public static List<Models.Version> GetData(Action<string> statusCallback, Action<int> progressCallback)
        {
            var files = Directory.GetFiles("data", "*.xml");

            progressCallback(files.Length);

            return files.Select(fileName =>
            {
                var version = Serialization.Deserialize<Models.Version>(fileName);

                statusCallback(version.Name);

                return version;
            }).ToList();
        }
    }
}
