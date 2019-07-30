using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {

        public static void Main(string[] args)
        {
            List<PersonDetails> persons = new List<PersonDetails>();
            string ch = "y";
            do
            {

                string name = GetName();
                string dob = GetDateOfBirth();
                DateTime dt = ValidateDob(dob);

                if (dt != DateTime.MinValue)
                {
                    persons.Add(new PersonDetails(name, dt));
                    Console.WriteLine("\nDetails Added\n");
                }
                else
                {
                    break;
                }
                Console.WriteLine("\nDo you want to add another person(y/n)?");
                ch = Console.ReadLine();

            } while (ch == "y");

            List<PersonDetails> sortedList = PersonDetails.SortPersons(persons);

            Console.WriteLine("\nThe Sorted List is :\n");

            foreach (var item in sortedList)
            {

                Console.WriteLine("Name : {0} \t Date Of Birth : {1} \t Age : {2} years {3} months {4} days \n ", item.Name, item.Dob, item.Age.Years, item.Age.Months, item.Age.Days);

            }
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        static string GetName()
        {
            Console.WriteLine("\nEnter your name : ");
            string name = Console.ReadLine();
            return name;
        }

        static string GetDateOfBirth()
        {
            Console.WriteLine("\nEnter your date of birth seperated by '/' : ");
            string dob = Console.ReadLine();
            return dob;
        }

        static DateTime ValidateDob(string dob)
        {
            DateTime dob1;
            if (DateTime.TryParseExact(dob, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob1))
            {
                if (dob1 > DateTime.Now)
                {
                    Console.WriteLine("\nPlease Enter a Proper Date\n");
                    return DateTime.MinValue;
                }
                return dob1;
            }
            else
            {
                Console.WriteLine("\nNot a date\n");
                return DateTime.MinValue;
            }
        }
    }
}
