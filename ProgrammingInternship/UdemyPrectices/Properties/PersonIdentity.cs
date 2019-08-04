using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Properties
{
    class PersonIdentity
    {
        public string Name { get; private set; }
        public string FamilyName { get; private set; }
        public DateTime Birthdate { get; private set; }
        public string Job { get; private set; }

        public PersonIdentity(string name, string familyName, DateTime birthdate, string job)
        {
            Name = name;
            FamilyName = familyName;
            Birthdate = birthdate;
            Job = job;
        }

        public int Age
        {
            get
            {
                var timeSpan = DateTime.Today - Birthdate;
                var years = timeSpan.Days / 365;
                return years;
            }
        }
    }
}
