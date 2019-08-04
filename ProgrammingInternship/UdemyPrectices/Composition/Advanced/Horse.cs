using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Composition.Advanced
{
    class Horse
    {
        private readonly Animal _animal;
        private readonly Walkable _walkable;
        private readonly Swimable _swimable;

        public Horse(Animal animal, Walkable walkable, Swimable swimable)
        {
            _animal = animal;
            _walkable = walkable;
            _swimable = swimable;
        }

        public void Introduce()
        {
            Console.WriteLine("Horse is an {0}, horse can {1} and {2} \n",
                              _animal.DeclareAnimal(), 
                              _walkable.DeclareWalking(), 
                              _swimable.DeclareSwiming());
        }
    }
}
