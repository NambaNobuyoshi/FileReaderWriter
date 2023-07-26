using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FileReadWrite.Domains
{
    /// <summary>
    /// XMLファイルを読み取るための機能を提供するクラス
    /// </summary>
    internal class XmlFileReader : IFileReader
    {
        public T Read<T>(string filePath)
        {
            try
            {
                var xmlDeserealizer = new XmlSerializer(typeof(T));
                var xmlSettings = new XmlReaderSettings() 
                {
                    CheckCharacters = false     // XML規格外の文字が入っていてもエラーにならないように設定
                };

                using (var reader = new StreamReader(filePath, Encoding.UTF8))
                using (var xmlReader = XmlReader.Create(reader, xmlSettings))
                {
                    return (T)xmlDeserealizer.Deserialize(xmlReader);
                }

            }catch (Exception e)
            {
                Console.WriteLine("XMLFileWriter でエラーが出ました : " + e.Message);
                return default(T);
            }
        }
    }
}
