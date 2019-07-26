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
        public static int flag;
        public static void Main(string[] args)
        {
            string ch = "y";
            flag = 1;
            do
            {
                

                string db = GetDateOfBirth();
                DateTime dt = ValidateDob(db);
                if(flag==1)
                {
                    string output = Age(dt);
                    Console.WriteLine(output);
                }
                
                Console.WriteLine("\nDo you want to continue(y/n)?");
                ch = Console.ReadLine();
            } while (ch == "y");
            
        }
        public static string GetDateOfBirth()
        {
            Console.WriteLine("\nEnter your date of birth seperated by '/' : ");
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
                    Console.WriteLine("\nPlease Enter a Proper Date");
                    flag = 0;
                    return DateTime.MinValue;
                 }
                return dob1;
                flag = 1;
             }
            else
             {
                Console.WriteLine("\nNot a date");
                flag = 0;
               
                return DateTime.MinValue;
               
             }
        }

        public static string Age(DateTime dob1)
        {
            DateTime now = DateTime.Now;
            DateTimeOffset dateofbirth = new DateTimeOffset(dob1);
            int years = new DateTime(DateTimeOffset.Now.Subtract(dateofbirth).Ticks).Year - 1;
            int months = new DateTime(DateTimeOffset.Now.Subtract(dateofbirth).Ticks).Month - 1;
            int days = new DateTime(DateTimeOffset.Now.Subtract(dateofbirth).Ticks).Day - 1;
            /*DateTimeOffset d = dateofbirth.AddYears(years);


            int months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (d.AddMonths(i) == now)
                {
                    months = i;
                    break;
                }
                else if (d.AddMonths(i) > now)
                {
                    months = i - 1;
                    break;
                }
            }
            int days = DateTimeOffset.Now.Subtract(d.AddMonths(months)).Days;*/
            return string.Format("\nThe Age is : {0} years {1} months {2} days \n",years,months,days);


            /*int years = new DateTime(DateTime.Now.Subtract(dob1).Ticks).Year - 1;
            DateTime d = dob1.AddYears(years);
            
            
            int months = 0;
            for(int i = 1; i <= 12; i++)
            {
                if (d.AddMonths(i) == Now)
                {
                    months = i;
                    break;
                }
                else if(d.AddMonths(i) > Now)
                {
                    months = i - 1;
                    break;
                }
            }
            int days = Now.Subtract(d.AddMonths(months)).Days;
            
            return String.Format("\nThe Age is : {0} years {1} months {2} days", years, months, days);*/


        }
    }
}


