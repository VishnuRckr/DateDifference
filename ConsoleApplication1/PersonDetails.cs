using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static List<PersonDetails> SortPersons(List<PersonDetails> persons)
        {
            List<PersonDetails> sortedList = persons.OrderBy(order => order.Dob).ToList();
            return sortedList;
        }
    }
}
