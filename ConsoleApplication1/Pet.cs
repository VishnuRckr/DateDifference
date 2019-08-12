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
    [Serializable] 
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

        public override List<Pet> Serializer<Pet>(List<Pet> listPet)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Pet>));
            Stream stream = File.OpenWrite(@"D:/Pets.xml");
            xmlSerializer.Serialize(stream, listPet);
            stream.Close();
            return null;      
        }

        public override void Deserializer()
        {
            Console.WriteLine("\nDeserialized Pets' list is:\n");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<PersonDetails>));
            Stream stream = File.OpenRead(@"D:/Pets.xml");
            List<PersonDetails> petDetails = (List<PersonDetails>)xmlSerializer.Deserialize(stream);
            foreach (var element in petDetails)
            {
                var petMember = (Pet)element;
                Console.WriteLine("\nName: {0}\t Date Of Birth : {1}\t Pet Breed : {2}\t Age : {3} years {4} months {5} days\n", element.Name, element.Dob, petMember.PetBreed, element.Age.Years, element.Age.Months, element.Age.Days);
            }
        }
    }
}
