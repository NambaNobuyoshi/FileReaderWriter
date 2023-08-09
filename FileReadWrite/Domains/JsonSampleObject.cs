using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FileReadWrite.Domains
{
    public class JsonSsmpleObjectAccessor
    {
        private static readonly string FILE_PATH = System.Environment.CurrentDirectory + @"\jsonSample.json";
        private static readonly JsonFileReader jsonFileReader = new JsonFileReader();
        private static readonly JsonFileWriter jsonFileWriter = new JsonFileWriter();

        public static JsonSampleObject GetSample()
        {
            return jsonFileReader.Read<JsonSampleObject>(FILE_PATH);
        }

        public static void SetSample(JsonSampleObject sampleObject)
        {
            jsonFileWriter.Write<JsonSampleObject>(FILE_PATH, sampleObject);
        }

        // @@TEST
        public static void InitSample()
        {
            Console.WriteLine(FILE_PATH);
            var sampleObject = new JsonSampleObject();

            sampleObject.books = new List<JsonSampleBook>
            {
                new JsonSampleBook{ id = 1, title = "sample_novel", publisher = "sample_syotenn"},
                new JsonSampleBook{ id = 2, title = "sample_zasshi", publisher = "sample_syotenn"},
                new JsonSampleBook{ id = 3, title = "sample_novel", publisher = "sample_syotenn"}
            };

            jsonFileWriter.Write<JsonSampleObject>(FILE_PATH, sampleObject);
        }
    }

    [JsonObject("sample")]
    public class JsonSampleObject
    {
        [JsonProperty("books")]
        public List<JsonSampleBook> books { get; set; }
    }

    [JsonObject("book")]
    public class JsonSampleBook
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("publisher")]
        public string publisher { get; set; }
    }
}
