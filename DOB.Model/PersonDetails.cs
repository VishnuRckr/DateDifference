using DOB.DBHelper;
using DOB.Model.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;


namespace DOB.Model
{
    [XmlInclude(typeof(Pet))]
    [Serializable]
    public class PersonDetails : IDatabaseOperation
    {
        public string Name { get; set; }

        public DateTime Dob { get; set; }

        public Age Age { get; set; }

        PersonDetailsDBHelper personObj = new PersonDetailsDBHelper();

        public PersonDetails(string name, DateTime dob)
        {
            this.Name = name;
            this.Dob = dob;
            this.Age = new Age(dob);
        }

        public PersonDetails()
        {
        }

        public void Write(List<PersonDetails> person)
        {

            List<PersonDetailsDBHelper> lst = new List<PersonDetailsDBHelper>();
            foreach (var item in person)
            {
                lst.Add(new PersonDetailsDBHelper
                {
                    Name = item.Name,
                    Dob = item.Dob,
                    Age = new DBHelper.Age(item.Age.Years)
                });
            }

            PersonDetailsDBHelper.Write(lst);
        }

        public void Read()
        {
            List<PersonDetailsDBHelper> lst = new List<PersonDetailsDBHelper>();
            List<PersonDetails> person = new List<PersonDetails>();
            foreach (var item in person)
            {
                lst.Add(new PersonDetailsDBHelper
                {
                    Name = item.Name,
                    Dob = item.Dob,
                    Age = new DBHelper.Age(item.Age.Years)
                });
            }
            PersonDetailsDBHelper personDB = new PersonDetailsDBHelper();
            List<PersonDetailsDBHelper> list = PersonDetailsDBHelper.Read();
            Console.WriteLine("PersonDetails table has the following entries :\n");
            foreach (var item in list)
            {
                Console.WriteLine("Name : {0}\t Dob : {1}\t Age : {2}\n", item.Name, item.Dob, item.Age.Years);
            }

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
