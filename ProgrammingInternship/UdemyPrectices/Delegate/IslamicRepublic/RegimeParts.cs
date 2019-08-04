using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Delegate.IslamicRepublic
{
    class RegimeParts
    {
        public void AddKhobregan(string republicName)
        {
            Console.WriteLine("Khobregan have been added to " + republicName);
        }

        public void AddShorayeNegahban(string republicName)
        {
            Console.WriteLine("Shoraye Negahban has been added to " + republicName);
        }

        public void AddPrimeLeader(string republicName)
        {
            Console.WriteLine("Prime Leader has been added to " + republicName);
        }

        public void SlayPeople(string republicName)
        {
            Console.WriteLine("People have been slayed for " + republicName);
        }
    }
}
