using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Serialization;

namespace WpfLibrary1
{
    public static class Serializer
    {
        // XML Serialization
        public static string SerializeToXml<T>(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, obj);
                return stringWriter.ToString();
            }
        }

        public static T DeserializeFromXml<T>(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                throw new ArgumentNullException(nameof(xml));
            }

            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var stringReader = new StringReader(xml))
            {
                return (T)xmlSerializer.Deserialize(stringReader);
            }
        }

        // JSON Serialization
        public static string SerializeToJson<T>(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            var jsonSerializer = new DataContractJsonSerializer(typeof(T));
            using (var memoryStream = new MemoryStream())
            {
                jsonSerializer.WriteObject(memoryStream, obj);
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }

        public static T DeserializeFromJson<T>(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentNullException(nameof(json));
            }

            var jsonSerializer = new DataContractJsonSerializer(typeof(T));
            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                return (T)jsonSerializer.ReadObject(memoryStream);
            }
        }
    }
}

