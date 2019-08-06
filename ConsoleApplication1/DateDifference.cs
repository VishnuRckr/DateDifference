using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    class Program
    {
        public static int Type = 0;

        public static void Main(string[] args)
        {
            List<PersonDetails> persons = new List<PersonDetails>();
            do
            {
                Type = _Menu();
                string name, dob;
                DateTime dt;
                PersonDetails personObj = new PersonDetails();
                Pet petObj = new Pet();
                switch (Type)
                {
                    case 1:

                        name = _GetName();
                        dob = _GetDateOfBirth();
                        dt = _ValidateDob(dob);
                        if (dt != DateTime.MinValue)
                        {
                            persons.Add(new PersonDetails(name, dt));
                            Console.WriteLine("\nDetails Added\n");

                        }
                        else
                        {
                            Console.WriteLine("\nInvalid Date\n");
                        }
                        break;

                    case 2:

                        name = _GetName();
                        dob = _GetDateOfBirth();
                        dt = _ValidateDob(dob);
                        if (dt != DateTime.MinValue)
                        {
                            string petBreed = _GetPetBreed();
                            persons.Add(new Pet(name, petBreed, dt));
                            Console.WriteLine("\nDetails Added\n");
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid Date\n");
                        }
                        break;

                    case 3:

                        if (persons.Count != 0)
                        {
                            List<PersonDetails> sortedList = PersonDetails.SortPersons(persons);
                            Console.WriteLine("\nThe sorted list is :\n");

                            foreach (var item in sortedList)
                            {
                                _Output(item);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nlist is empty\n");
                        }
                        break;

                    case 4:

                        List<PersonDetails> sortedList1 = PersonDetails.SortPersons(persons);
                        Console.WriteLine("\n1. Serialize Persons\n2. Serialize Pets\n");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1: personObj.Serializer(sortedList1); break;
                            case 2: petObj.Serializer(sortedList1); break;
                            default: Console.WriteLine("Invalid Entry"); break;
                        }

                        Console.WriteLine("\nDetails copied to file\n");
                        break;

                    case 5:

                        List<PersonDetails> sortedList2 = PersonDetails.SortPersons(persons);
                        Console.WriteLine("\n1. Deserialize Persons\n2. Deserialize Pets\n");
                        int choice1 = Convert.ToInt32(Console.ReadLine());
                        switch (choice1)
                        {
                            case 1: personObj.Deserializer(sortedList2); break;
                            case 2: petObj.Deserializer(sortedList2); break;
                            default: Console.WriteLine("Invalid Entry"); break;
                        }
                        break;

                    default: Console.WriteLine("Invalid Entry"); break;
                }

                Console.WriteLine("Do you wish to continue(y/n)?");

            } while (Console.ReadLine() == "y");

            Console.WriteLine("\nPress any key to exit");
            Console.ReadLine();

        }

        private static int _Menu()
        {
            Console.WriteLine("\nMENU\n 1.Add Person\n 2.Add pet\n 3.View All\n 4.Write to file\n 5.View From File\n");
            Type = Convert.ToInt32(Console.ReadLine());
            return Type;
        }

        private static string _GetName()
        {
            Console.WriteLine("\nEnter name : ");
            string name = Console.ReadLine();
            return name;
        }

        private static string _GetDateOfBirth()
        {
            Console.WriteLine("\nEnter date of birth seperated by '/' : ");
            string dob = Console.ReadLine();
            return dob;
        }

        private static DateTime _ValidateDob(string dob)
        {
            DateTime dob1;
            if (DateTime.TryParseExact(dob, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob1))
            {
                if (dob1 > DateTime.Now)
                {
                    return DateTime.MinValue;
                }
                return dob1;
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        private static string _GetPetBreed()
        {
            Console.WriteLine("\nEnter the pet breed :");
            string petBreed = Console.ReadLine();
            return petBreed;
        }

        private static void _Output(PersonDetails item)
        {
            Console.WriteLine("Name : {0} \t", item.Name);
            if (item is Pet)
            {
                var petMember = (Pet)item;
                Console.WriteLine("Breed : {0} \t", petMember.PetBreed);
            }
            Console.WriteLine("Date Of Birth : {0} \t ", item.Dob);
            Console.WriteLine("Age : {0} years {1} months {2} days \n ", item.Age.Years, item.Age.Months, item.Age.Days);
        }

    }
}
