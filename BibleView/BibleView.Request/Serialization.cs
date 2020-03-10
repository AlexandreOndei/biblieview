using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BibleView.Request
{
    public static class Serialization
    {
        public static void Serialize<T>(T obj, string fileName) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextWriter writer = new StreamWriter(fileName);
            serializer.Serialize(writer, obj);
            writer.Close();
        }

        public static T Deserialize<T>(string fileName) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextReader reader = new StreamReader(fileName);
            var obj = (T)serializer.Deserialize(reader);
            reader.Close();
            return obj;
        }
    }
}
