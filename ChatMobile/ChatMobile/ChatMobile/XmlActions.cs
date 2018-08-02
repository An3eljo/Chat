using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ChatMobile
{
    public static class XmlActions
    {
        /// <summary>
        /// Deserialize from file
        /// </summary>
        /// <param name="filename">name of file which will be deserialized</param>
        /// <param name="deserializationElement">Must be same Type as expected return type</param>
        /// <returns>Deserialized element(s)</returns>
        public static object Deserialize(string filename, object deserializationElement)
        {
            //string file = FileSystem.Current.LocalStorage.Path + "/" + filename;
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var file = Path.Combine(path, filename);

            var serializer = new XmlSerializer(deserializationElement.GetType());
            object deserialized;
            try
            {
                using (var reader = XmlReader.Create(file))
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
        public static void Serialize(string filename, object serialisationElement)
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
