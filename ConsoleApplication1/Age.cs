using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Age
    {

        public int Years { get; set; }
        public int Months { get; set; }
        public int Days { get; set; }

        public Age(DateTime dob1)
        {
            DateTime now = DateTime.Now;
            DateTimeOffset dateofbirth = new DateTimeOffset(dob1);
            this.Years = new DateTime(DateTimeOffset.Now.Subtract(dateofbirth).Ticks).Year - 1;
            this.Months = new DateTime(DateTimeOffset.Now.Subtract(dateofbirth).Ticks).Month - 1;
            this.Days = new DateTime(DateTimeOffset.Now.Subtract(dateofbirth).Ticks).Day - 1;
        }

        public Age()
        {

        }
    }
}
