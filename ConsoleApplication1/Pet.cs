using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Pet : PersonDetails
    {
        public string PetBreed { get; protected set; }

        public Pet(string name, string petbreed, DateTime dob) : base(name, dob)
        {
            this.PetBreed = petbreed;
        }
       
    }
}
