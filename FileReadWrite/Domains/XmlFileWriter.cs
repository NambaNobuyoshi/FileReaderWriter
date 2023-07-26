using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileReadWrite.Domains
{
    internal class XmlFileWriter : IFileWriter
    {
        public void Write<T>(string filepath, T content)
        {
            try
            {
                var xmlSerealizer = new XmlSerializer(typeof(T));

                using (var writer = new StreamWriter(filepath, false, Encoding.UTF8))
                {
                    xmlSerealizer.Serialize(writer, content);
                    writer.Flush();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("XMLFileWriter でエラーが出ました : " + e.Message);
            }
        }
    }
}
