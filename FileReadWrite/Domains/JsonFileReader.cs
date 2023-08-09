using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileReadWrite.Domains
{
    internal class JsonFileReader : IFileReader
    {

        public T Read<T>(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    return default(T);
                }

                using (var stream = new FileStream(filePath, FileMode.Open))
                using (var reader = new StreamReader(stream))
                {
                    return JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("JsonFileReader でエラーが出ました : " + e.Message);
                return default(T);
            }
        }
    }
}
