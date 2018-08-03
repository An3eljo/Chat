using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ChatServer
{
    public static class XmlActions
    {
        public const string ErrorMessagesPath = @"C:\Users\Administrator\Documents\ChatFiles\Errorlog.xml";
        public const string UserIdsPath = @"C:\Users\Administrator\Documents\ChatFiles\Ids\UserIds.xml";
        public const string ChatIdsPath = @"C:\Users\Administrator\Documents\ChatFiles\Ids\ChatIds.xml";
        /// <summary>
        /// Deserialize from file
        /// </summary>
        /// <param name="filename">name of file which will be deserialized</param>
        /// <param name="deserializationElement">Must be same Type as expected return type</param>
        /// <returns>Deserialized element(s)</returns>
        public static object Deserialize(string path, object deserializationElement)
        {
            var serializer = new XmlSerializer(deserializationElement.GetType());
            object deserialized;
            try
            {
                using (var reader = XmlReader.Create(path))
                {
                    deserialized = serializer.Deserialize(reader);
                    reader.Close();
                }
            }
            catch (Exception)
            {
                return null;
            }

            return deserialized;
        }

        /// <summary>
        /// Serialize to file
        /// </summary>
        /// <param name="filename">name of file in which will be serialized</param>
        /// <param name="serialisationElement">Instance which will be serialized</param>
        public async static Task Serialize(string filename, object serialisationElement)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var file = Path.Combine(path, filename);

            XmlSerializer serializer = new XmlSerializer(serialisationElement.GetType());

            using (StreamWriter writer = new StreamWriter(file))
            {
                serializer.Serialize(writer, serialisationElement);
                writer.Close();
            }
        }
    }
}
