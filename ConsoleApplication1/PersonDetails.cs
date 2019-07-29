using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class PersonDetails
    {
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public int Total { get; set; }
        public Age Age { get; set; }
        
        public PersonDetails(string name, DateTime dob)
        {
            this.Name = name;
            this.Dob = dob;
            this.Total = (DateTime.Now - dob).Days;
            this.Age = new Age(dob);           
        }

        public static List<PersonDetails> SortPersons(List<PersonDetails> persons)
        {
            List<PersonDetails> SortedList = persons.OrderBy(order => order.Total).ToList();
            return SortedList;
        }
    }
}
