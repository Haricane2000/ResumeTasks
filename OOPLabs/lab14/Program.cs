using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace lab
{ 
    class Program
    {
        static void PrintCartoon(Cartoon cartoon)
        {
            Console.WriteLine($"Author = {cartoon.Author.FirstName} {cartoon.Author.LastName}; Duration = {cartoon.Duration}; Ads = {cartoon.ContainsAds}");
        }

        static void Main(string[] args)
        {
            Author author = new Author
            {
                FirstName = "John",
                LastName = "Cena"
            };
            Cartoon cartoon = new Cartoon
            {
                Author = author,
                Duration = 10,
                ContainsAds = true
            };

            PrintCartoon(cartoon);

            // Serialization
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream stream = new FileStream("binary.dat", FileMode.Create))
                binaryFormatter.Serialize(stream, cartoon);
            Cartoon newCartoon;
            // Deserealization
            using (FileStream stream = new FileStream("binary.dat", FileMode.Open))
                newCartoon = binaryFormatter.Deserialize(stream) as Cartoon;
            PrintCartoon(newCartoon);
            // Serialization
            SoapFormatter soapFormatter = new SoapFormatter();
            using (FileStream stream = new FileStream("soap.soap", FileMode.Create))
                soapFormatter.Serialize(stream, cartoon);
            // Serialization
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Cartoon));
            using (FileStream stream = new FileStream("xml.xml", FileMode.Create))
                xmlSerializer.Serialize(stream, cartoon);
            // Serialization
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Cartoon));
            using (FileStream stream = new FileStream("json.json", FileMode.Create))
                jsonSerializer.WriteObject(stream, cartoon);

            CollectedList<Point> points = new CollectedList<Point>();
            Random random = new Random();
            for(int i = 0; i < 10; ++i)
            {
                Point newPoint = new Point
                {
                    X = random.Next(0, 100),
                    Y = random.Next(0, 100)
                };
                points.Add(newPoint);
            }

            DataContractJsonSerializer pointsSerializer = new DataContractJsonSerializer(typeof(CollectedList<Point>));
            using (Stream stream = new FileStream("points.json", FileMode.Create))
                pointsSerializer.WriteObject(stream, points);

            // XPath
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\xml.xml");
            XmlNode n = doc.SelectSingleNode("customers/customer[firstname='Jim']");
            XmlNode n1 = doc.SelectSingleNode("customers/customer/@id");
            Console.WriteLine(n.InnerText);
            Console.WriteLine(n1.InnerText);

            // Linq to XML
            XElement contacts = new XElement("Contacts"
                , new XElement("Contact", new XElement("Name", "Patric Heinz"), new XElement("Age", "20"))
                , new XElement("Contact", new XElement("Name", "Who me"), new XElement("Age", "31"))
                , new XElement("Contact", new XElement("Name", "Anonimous"), new XElement("Age", "1000"))
                , new XElement("Contact", new XElement("Name", "Charlie Chaplin"), new XElement("Age", "8")));

            Console.WriteLine("\tLINQ");
            var res = contacts.Descendants("Contact").Where(x => Int32.Parse(x.Element("Age").Value) >= 20).Select(x => x.Element("Name").Value);
            foreach (var item in res)
                Console.WriteLine(item);

        }
    }
}
