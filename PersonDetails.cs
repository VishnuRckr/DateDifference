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

    public class PersonDetails
    {

        public string Name { get; protected set; }
        public DateTime Dob { get; protected set; }
        public Age Age { get; protected set; }

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
        public void _Serialize(PersonDetails item)
        {
            string jsonSerializer = JsonConvert.SerializeObject(item);
            string path = @"D:/PersonDetails.json";
            File.AppendAllText(path, jsonSerializer);

        }

        /* public void _Deserialize()
         {                      
             PersonDetails jsonDeserializer = JsonConvert.DeserializeObject<PersonDetails>(File.ReadAllText(@"D:/PersonDetails.json"));
             Console.WriteLine("Name : {0} \t Date Of Birth : {1} \t Age : {2}", jsonDeserializer.Name, jsonDeserializer.Dob, jsonDeserializer.Age);
         }*/

    }
}
