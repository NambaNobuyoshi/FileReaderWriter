using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadWrite.Domains
{
    internal class JsonFileWriter : IFileWriter
    {
        public void Write<T>(string filepath, T content)
        {
            try
            {
                var jsonWriteData = JsonConvert.SerializeObject(content, Formatting.Indented);

                using (var writer = new StreamWriter(filepath, false, Encoding.UTF8))
                {
                    writer.Write(jsonWriteData);
                }

            }catch(Exception e)
            {
                Console.WriteLine("JsonFileWriter でエラーが出ました : " + e.Message);
            }
        }
    }
}
