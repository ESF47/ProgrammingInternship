using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices
{
    class ConstructorAndObjInitializer
    {
        public string PersonName;
        public int PersonAge;
        public float PersonHeight;

        public ConstructorAndObjInitializer()
        {

        }

        public ConstructorAndObjInitializer(string name)
        {
            this.PersonName = name;
        }

        public ConstructorAndObjInitializer(int age)
        {
            this.PersonAge = age;
        }

        public ConstructorAndObjInitializer(float height)
        {
            this.PersonHeight = height;
        }

        public ConstructorAndObjInitializer(string name, int age, float height)
        {
            this.PersonName = name;
            this.PersonAge = age;
            this.PersonHeight = height;
        }

        public void ShowPersonInfo()
        {
            Console.WriteLine(this.PersonName + " " + this.PersonAge + " " + this.PersonHeight);
        }
    }
}
