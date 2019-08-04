using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Delegate.CarTest
{
    class MontageFunctionalities
    {
        public void AddDoor(string dayTime)
        {
            Console.WriteLine("Door added to car at " + dayTime);
        }

        public void AddEngine(string daytime)
        {
            Console.WriteLine("Engine added to car at " + daytime);
        }

        public void AddWheels(string dayTime)
        {
            Console.WriteLine("Wheels added to car at " + dayTime);
        }
    }
}
