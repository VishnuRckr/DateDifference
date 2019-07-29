using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class program
    {
        public static int flag;
       
        public static void Main(string[] args)
        {
            List<Details> persons = new List<Details>();
            string ch = "y";
            flag = 1;
            
            do
            {
                int count = GetTotalPersons();
                if (flag == 1)
                {
                    string age;
                    for (int i = 1; i <= count; i++)
                    {

                        string name = GetName();

                        string dob = GetDateOfBirth();
                        DateTime dt = ValidateDob(dob);


                        if (dt != DateTime.MinValue)
                        {
                            persons.Add(new Details(name, dt));
                            Console.WriteLine("\nDetails Added\n");
                        }
                        else
                        {
                          
                            flag = 0;
                            break;
                        }

                        age = Age(dt);
                        Console.WriteLine(age);
                    }
                   
                }

                List<Details> SortedList = Details.SortPersons(persons);

                foreach (var item in SortedList)
                {

                    Console.WriteLine("Name : {0} \t Date Of Birth : {1}\n", item.Name, item.Dob);

                }
                                                
                 Console.WriteLine("\nDo you want to continue(y/n)?");
                 ch = Console.ReadLine();
             } while (ch == "y");
         
        }

        public static int GetTotalPersons()
        {
            Console.WriteLine("\nEnter the number of persons :");
            int num = Convert.ToInt32(Console.ReadLine());
            return num;
        }

        public static string GetName()
        {
            Console.WriteLine("\nEnter your name : ");
            string name = Console.ReadLine();
            return name;
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
                    Console.WriteLine("\nPlease Enter a Proper Date\n");
                    return DateTime.MinValue;
                    flag = 0;
                }
                return dob1;
                flag = 1;
            }
            else
            {
                Console.WriteLine("\nNot a date\n");
                return DateTime.MinValue;
                flag = 0;

            }
           
        }

        public static string Age(DateTime dob1)
        {
            if (flag==1)
            {
                DateTime now = DateTime.Now;
                DateTimeOffset dateofbirth = new DateTimeOffset(dob1);
                int years = new DateTime(DateTimeOffset.Now.Subtract(dateofbirth).Ticks).Year - 1;
                int months = new DateTime(DateTimeOffset.Now.Subtract(dateofbirth).Ticks).Month - 1;
                int days = new DateTime(DateTimeOffset.Now.Subtract(dateofbirth).Ticks).Day - 1;

                return string.Format("\nYour Age is : {0} years {1} months {2} days \n", years, months, days);
            }
            return null;
            

        }
    }

    class Details
    {
        public string Name { get;  set; }
        public DateTime Dob { get;  set; }
        public int Total { get;  set; }


        public Details(string name, DateTime dob)
        {
            this.Name = name;
            this.Dob = dob;
            this.Total = (DateTime.Now - dob).Days;

        }

        public static List<Details> SortPersons(List<Details> persons)
        {
            List<Details> SortedList = persons.OrderBy(order => order.Total).ToList();
            
            return SortedList;
        }
    }

}


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








   


