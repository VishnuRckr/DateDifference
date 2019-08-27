
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOB.Model.Interfaces;
using DOB.DBHelper;
using System.Xml.Serialization;
using System.IO;

namespace DOB.Model
{
    [Serializable]
    public class Pet : PersonDetails, IDatabaseOperation, IFileOperation
    {
        public string PetBreed { get; set; }

        public Pet(string name, string petbreed, DateTime dob) : base(name, dob)
        {
            this.PetBreed = petbreed;
        }

        public Pet()
        {
        }
        public void Write(List<PersonDetails> pet)
        {
            List<PetDBHelper> list = new List<PetDBHelper>();
            foreach (var item in pet)
            {
                var petMember = (Pet)item;
                list.Add(new PetDBHelper
                {

                    Name = item.Name,
                    Dob = item.Dob,
                    Age = new DBHelper.Age(item.Age.Years),
                    PetBreed = petMember.PetBreed
                });
            }

            PetDBHelper petDB = new PetDBHelper();
            petDB.Write(list);
        }

        public void Read()
        {
            List<PetDBHelper> list = new List<PetDBHelper>();
            List<Pet> pet = new List<Pet>();

            foreach (var item in pet)
            {
                list.Add(new PetDBHelper
                {
                    Name = item.Name,
                    Dob = item.Dob,
                    Age = new DBHelper.Age(item.Age.Years),
                    PetBreed = item.PetBreed
                });
            }
            PetDBHelper petDB = new PetDBHelper();
            petDB.Read();
        }

        public List<Pet> Serializer<Pet>(List<Pet> listPet)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Pet>));
            Stream stream = File.OpenWrite(@"D:/Pets.xml");
            xmlSerializer.Serialize(stream, listPet);
            stream.Close();
            return null;
        }

        public void Deserializer()
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
