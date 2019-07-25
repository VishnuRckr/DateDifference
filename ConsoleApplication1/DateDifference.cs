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
            string ch = "y";
            do
            {

                string db = DateOfBirth();
                DateTime dt = ValidateDob(db);
                string output = Age(dt);
                Console.WriteLine(output);
                Console.WriteLine("Do you want to continue(y/n)?");
                ch = Console.ReadLine();
            } while (ch == "y");
            
        }
        public static string DateOfBirth()
        {
            Console.WriteLine("\nEnter your date of brirth seperated by '/' : ");
            string dob = Console.ReadLine();
            return dob;
        }

        public static DateTime ValidateDob(string dob)
        {

            DateTime dob1;
            if (DateTime.TryParseExact(dob, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob1))
             {
                if (dob1 > DateTime.Now)
                 {
                    Console.WriteLine("Please Enter a Proper Date");
                    return DateTime.MinValue;
                 }
                return dob1;
             }
            else
             {
                Console.WriteLine("Not a date");
                Console.ReadLine();
                Environment.Exit(0);
                return DateTime.MinValue;
             }
        }

        public static string Age(DateTime dob1)
        {
            DateTime Now = DateTime.Now;
            int years = new DateTime(DateTime.Now.Subtract(dob1).Ticks).Year - 1;
            DateTime d = dob1.AddYears(years);
            int months = 0;
            for(int i = 1; i <= 12; i++)
            {
                if (d.AddMonths(i) == Now)
                {
                    months = i;
                    break;
                }
                else if(d.AddMonths(i) >= Now)
                {
                    months = i - 1;
                    break;
                }
            }
            int days = Now.Subtract(d.AddMonths(months)).Days;
            return String.Format("The Age is : {0} years {1} months {2} days",years,months,days);

        }
    }
}


