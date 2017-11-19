using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using static Przyrost_2.Muzyka;
namespace Przyrost_2
{

    /* program nie działa i nie ma wszytkich opcji, chiałbym dopytać sie pana o pewne sprawy w piatek*/


    class Program
    {
        static void Main(string[] args)
        {

            
            Muzyka muza = new Muzyka();
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };
            string json = JsonConvert.SerializeObject(muza, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(json);
            /*Muzyka muza = new Muzyka();
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(muza);
            Console.WriteLine(JSONresult);*/
            CheckFormat();
            /*JsonToXml();
            Console.WriteLine("/n");
            XmlToJson();*/
            Console.ReadLine();
        }
        public static bool CheckFormat()
        {
            DateTime json = File.GetLastWriteTime("json.json");
            DateTime xml = File.GetLastWriteTime("xml.xml");
            if (json > xml)
            {
                JsonToXml();
                return true;
            }
            else
                XmlToJson();
            return false;
        }
        public static void JsonToXml()
        {
            StreamReader jreader = new StreamReader("json.json");
            string json = jreader.ReadToEnd();
            XNode node = JsonConvert.DeserializeXNode(json);

            File.WriteAllText(@"xml.xml", node.ToString());
            Console.WriteLine(node.ToString());
        }
        public static void XmlToJson()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("xml.xml");
            string tojson = JsonConvert.SerializeXmlNode(xml);
            File.WriteAllText(@"json.json", tojson.ToString());
            Console.WriteLine(tojson);

        }
    }
}
