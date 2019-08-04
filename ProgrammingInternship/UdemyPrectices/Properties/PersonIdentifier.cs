using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Properties
{
    class PersonIdentifier
    {
        PersonIdentity person = new PersonIdentity("Jack", "Nickolson", new DateTime(1940, 5, 12), "Actor");

        public void IntroducePerson()
        {
            Console.WriteLine("Our person is " + person.Name +
                              " " + person.FamilyName + 
                              ", he is " + person.Age +
                              " and his job is " + 
                              person.Job + 
                              ".");
        }
    }
}
