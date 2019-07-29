using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Age
    {
       public int years { get; set; }
       public int months { get; set; }
       public int days { get; set; }

        public Age(DateTime dob1)
        {
            DateTime now = DateTime.Now;
            DateTimeOffset dateofbirth = new DateTimeOffset(dob1);
            this.years = new DateTime(DateTimeOffset.Now.Subtract(dateofbirth).Ticks).Year - 1;
            this.months = new DateTime(DateTimeOffset.Now.Subtract(dateofbirth).Ticks).Month - 1;
            this.days = new DateTime(DateTimeOffset.Now.Subtract(dateofbirth).Ticks).Day - 1;                                    
        }
    }
}
