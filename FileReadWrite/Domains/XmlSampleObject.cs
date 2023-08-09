using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileReadWrite.Domains
{
    public class XmlSampleObjectAccessor
    {
        private static readonly string FILE_PATH = System.Environment.CurrentDirectory + @"\xmlSample.xml";

        private static readonly XmlFileReader xmlReader = new XmlFileReader();
        private static readonly XmlFileWriter xmlWriter = new XmlFileWriter();


        public static XmlSampleObject GetSample()
        {
            return xmlReader.Read<XmlSampleObject>(FILE_PATH);
        }

        public static void SetSample(XmlSampleObject sampleObject)
        {
            xmlWriter.Write<XmlSampleObject>(FILE_PATH, sampleObject);
        }

        // @@TEST
        public static void InitSample()
        {

            Console.WriteLine(FILE_PATH);
            var sampleObject = new XmlSampleObject();

            sampleObject.books = new List<SampleBook>
            {
                new SampleBook{ id = 1, title = "sample_novel", publisher = "sample_syotenn"},
                new SampleBook{ id = 2, title = "sample_zasshi", publisher = "sample_syotenn"},
                new SampleBook{ id = 3, title = "sample_novel", publisher = "sample_syotenn"}
            };

            xmlWriter.Write<XmlSampleObject>(FILE_PATH, sampleObject);
        }
    }

    public class XmlSampleObject
    {
        [XmlArray("list_book")]
        [XmlArrayItem("book")]
        public List<SampleBook> books {  get; set; }
    }

    public class SampleBook
    {
        [XmlAttribute("id")]
        public int id { get; set; }
        [XmlElement("title")]
        public string title { get; set; }
        [XmlElement("publisher")]
        public string publisher { get; set; }
    }
}
