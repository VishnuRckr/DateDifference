using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;


namespace ConsoleApplication1
{
    public class Pet : PersonDetails, ISerializationAndDeserialization
    {

        public string PetBreed { get; set; }

        public Pet(string name, string petbreed, DateTime dob) : base(name, dob)
        {
            this.PetBreed = petbreed;
        }

        public Pet()
        {
        }

        public new void Serializer(List<PersonDetails> item)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<PersonDetails>));
            Stream stream = File.OpenWrite(@"D:/Pets.xml");
            xmlSerializer.Serialize(stream, item);
            stream.Close();
        }
        public new void Deserializer(List<PersonDetails> sortedList2)
        {
            Console.WriteLine("\nDeserialized Pets' list is:\n");
            using (FileStream stream = File.Open(@"D:/Pets.xml", FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<PersonDetails>));
                foreach(var item in sortedList2)
                {
                    List<PersonDetails> petDetails = (List<PersonDetails>)xmlSerializer.Deserialize(stream);
                }                
            }
        }
    }
}
