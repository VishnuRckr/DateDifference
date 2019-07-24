using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string ch="y";
            do
            {
                int days, months, years;
                string Dob;
                Console.WriteLine("\nEnter the date of birth in YYYY/MM/DD format : \n");
                Dob = Console.ReadLine();
                try
                {
                    DateTime Dob1 = Convert.ToDateTime(Dob);
                    DateTime CurrentDate = DateTime.Now;
                    if (Dob1.Year > CurrentDate.Year)
                    {
                        Console.WriteLine("\nPlease enter a proper date ");
                        break;
                    }
                    if (CurrentDate.Year > Dob1.Year)
                    {
                        years = CurrentDate.Year - Dob1.Year;
                    }
                    else
                    {
                        years = Dob1.Year - CurrentDate.Year;
                    }
                    if (CurrentDate.Month > Dob1.Month)
                    {
                        months = CurrentDate.Month - Dob1.Month;
                    }
                    else
                    {
                        months = Dob1.Month - CurrentDate.Month;
                    }
                    if (CurrentDate.Day > Dob1.Day)
                    {
                        days = CurrentDate.Day - Dob1.Day;
                    }
                    else
                    {
                        days = Dob1.Day - CurrentDate.Day;
                    }

                    Console.WriteLine("\nThe Difference is {0} days {1} months {2} years", days, months, years);
                    Console.WriteLine("\nDo you wish to continue(y/n)?");
                    ch = Console.ReadLine();
                    
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nPlease enter a proper date ");
                    Console.WriteLine("\nDo you wish to continue(y/n)?");
                    ch = Console.ReadLine();
                }
               
            } while (ch == "y");


                Console.ReadLine();
        }
    }
}

