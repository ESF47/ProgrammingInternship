using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Composition.Advanced
{
    class Crow
    {
        private readonly Animal _animal;
        private readonly Walkable _walkable;
        private readonly Flyable _flyable;

        public Crow (Animal animal, Walkable walkable, Flyable flyable)
        {
            _animal = animal;
            _walkable = walkable;
            _flyable = flyable;
        }

        public void Introduce()
        {
            Console.WriteLine("Crow is an {0}, crow can {1} and {2} \n", 
                              _animal.DeclareAnimal(), 
                              _walkable.DeclareWalking(),
                              _flyable.DeclareFlying());
        }
    }
}
