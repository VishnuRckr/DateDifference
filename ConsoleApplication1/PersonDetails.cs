using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApplication1
{

    [XmlInclude(typeof(Pet))]
    [Serializable]
    public class PersonDetails : ISerializationAndDeserialization
    {

        public string Name { get; set; }

        public DateTime Dob { get; set; }

        public Age Age { get; set; }

        public PersonDetails(string name, DateTime dob)
        {
            this.Name = name;
            this.Dob = dob;
            this.Age = new Age(dob);
        }

        public PersonDetails()
        {
        }

        public static List<PersonDetails> SortPersons(List<PersonDetails> persons)
        {
            List<PersonDetails> sortedList = persons.OrderBy(order => order.Dob).ToList();
            return sortedList;
        }

        public virtual List<PersonDetails> Serializer<PersonDetails>(List<PersonDetails> item)
        {
            string jsonSerializer = JsonConvert.SerializeObject(item);
            string path = @"D:/PersonDetails.json";
            File.AppendAllText(path, jsonSerializer);
            return null;
        }

        public virtual void Deserializer()
        {
            using (StreamReader reader = new StreamReader(@"D:/PersonDetails.json"))
            {
                string json = reader.ReadToEnd();
                var jsonDeserializer = JsonConvert.DeserializeObject<List<PersonDetails>>(json);
                Console.WriteLine("\nDeserialized Persons' list is\n");
                foreach (var element in jsonDeserializer)
                {
                    Console.WriteLine("Name: {0}\t Date Of Birth : {1}\t Age : {2} years {3} months {4} days\n", element.Name, element.Dob, element.Age.Years, element.Age.Months, element.Age.Days);
                }
            }
        }
    }
}
