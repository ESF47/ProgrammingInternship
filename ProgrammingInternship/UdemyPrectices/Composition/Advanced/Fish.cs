using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Composition.Advanced
{
    class Fish
    {
        private readonly Animal _animal;
        private readonly Swimable _swimable;

        public Fish (Animal animal, Swimable swimable)
        {
            _animal = animal;
            _swimable = swimable;
        }

        public void Introduce()
        {
            Console.WriteLine("Fish is an {0}, fish can {1} \n",
                              _animal.DeclareAnimal(), 
                              _swimable.DeclareSwiming());
        }
    }
}
