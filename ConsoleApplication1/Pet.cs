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
    public class Pet : PersonDetails
    {
        public string PetBreed { get; protected set; }

        public Pet(string name, string petbreed, DateTime dob) : base(name, dob)
        {
            this.PetBreed = petbreed;
        }

        public Pet()
        {
        }

        /* public void _petSerialize(PersonDetails item)
         {

             StreamWriter stream = new StreamWriter(@"D:/Pets.xml");
             XmlSerializer xmlSerializer = new XmlSerializer(typeof(PersonDetails));
             xmlSerializer.Serialize(stream, item);
         }*/
    }
}
