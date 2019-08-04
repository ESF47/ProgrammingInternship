using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices
{
    class WorkingWithDates
    {
        public void ShowTimeAndDate()
        {
            DateTime dateTime = new DateTime(1994, 5, 28);
            Console.WriteLine("Date time is : " + dateTime);
            DateTime now = DateTime.Now;
            Console.WriteLine("now time is : " + now);
            DateTime today = DateTime.Today;
            Console.WriteLine("today time is : " + today);

            DateTime tomorrow = now.AddDays(1);
            Console.WriteLine("tomorrow time would be : " + tomorrow);
            DateTime yesterday = now.AddDays(-1);
            Console.WriteLine("yesterday time was : " + yesterday);

            Console.WriteLine("long date string format : " + now.ToLongDateString());
            Console.WriteLine("short date string format : " + now.ToShortDateString());
            Console.WriteLine("long time string format : " + now.ToLongTimeString());
            Console.WriteLine("short time string format : " + now.ToShortTimeString());

            Console.WriteLine(now.ToString());
        }
    }
}
