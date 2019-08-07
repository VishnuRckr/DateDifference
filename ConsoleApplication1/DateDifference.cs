using System;
using System.Collections.Generic;
using System.Globalization;
using System.Collections;
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
                PersonDetails personObj = new PersonDetails();
                Pet petObj = new Pet();
                List<PersonDetails> personList = new List<PersonDetails>();
                List<PersonDetails> petList = new List<PersonDetails>();
                switch (Type)
                {
                    case 1:


                        var getPerson = _Get();
                        if (getPerson.Item2 != DateTime.MinValue)
                        {
                            persons.Add(new PersonDetails(getPerson.Item1, getPerson.Item2));
                            Console.WriteLine("\nDetails Added\n");

                        }
                        else
                        {
                            Console.WriteLine("\nInvalid Date\n");
                        }
                        break;

                    case 2:

                        var getPet = _Get();
                        string petBreed = _GetPetBreed();

                        if (getPet.Item2 != DateTime.MinValue)
                        {
                            persons.Add(new Pet(getPet.Item1, petBreed, getPet.Item2));
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

                        foreach (var item in sortedList1)
                        {
                            if (item is Pet)
                            {
                                petList.Add(item);
                            }
                            else
                            {
                                personList.Add(item);
                            }
                        }
                        if (personList.Count != 0)
                        {
                            personObj.Serializer(personList);
                        }
                        if (petList.Count != 0)
                        {
                            petObj.Serializer(petList);
                        }
                        break;

                    case 5:

                        List<PersonDetails> sortedList2 = PersonDetails.SortPersons(persons);
                        foreach (var item in sortedList2)
                        {
                            if (item is Pet)
                            {
                                petList.Add(item);
                            }
                            else
                            {
                                personList.Add(item);
                            }
                        }
                        if (personList.Count != 0)
                        {
                            personObj.Deserializer();
                        }
                        if (petList.Count != 0)
                        {
                            petObj.Deserializer();
                        }
                        break;

                    default: Console.WriteLine("Invalid Entry"); break;
                }

                Console.WriteLine("Do you wish to continue(y/n)?");

            } while (Console.ReadLine() == "y");

            Console.WriteLine("\nPress any key to exit");
            Console.ReadLine();
        }

        private static Tuple<string, DateTime> _Get()
        {
            string name = _GetName();
            string dob = _GetDateOfBirth();
            DateTime dt = _ValidateDob(dob);
            return new Tuple<string, DateTime>(name, dt);
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
