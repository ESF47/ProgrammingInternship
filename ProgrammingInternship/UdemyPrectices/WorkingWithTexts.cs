using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices
{
    class WorkingWithTexts
    {
        string subStringTest = "This text is for the Sub-String test!";

        public void StringFunctions()
        {
            string subtringed = subStringTest.Substring(5, 15);
            Console.WriteLine(subtringed);
        }
    }
}
