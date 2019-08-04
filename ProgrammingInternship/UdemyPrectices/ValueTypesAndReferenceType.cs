using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices
{
    class ValueTypesAndReferenceType
    {
        public int Age;

        public void Increment(int enteredNumber)
        {
            enteredNumber += 10;
            Console.WriteLine(enteredNumber);
        }

        public void MakeOld(ValueTypesAndReferenceType person)
        {
            person.Age += 10;
        }
    }
}
