using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class PersonDetails
    {
        public string Name { get; private set; }
        public DateTime Dob { get; private set; }
        public int Total { get; private set; }
        public Age Age { get; private set; }
        
        public PersonDetails(string name, DateTime dob)
        {
            this.Name = name;
            this.Dob = dob;
            this.Total = (DateTime.Now - dob).Days;
            this.Age = new Age(dob);           
        }

        public static List<PersonDetails> SortPersons(List<PersonDetails> persons)
        {
            List<PersonDetails> sortedList = persons.OrderBy(order => order.Total).ToList();
            return sortedList;
        }
    }
}
