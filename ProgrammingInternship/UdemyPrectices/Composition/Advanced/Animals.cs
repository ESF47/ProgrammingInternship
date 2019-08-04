using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Composition.Advanced
{
    class Animals
    {
        private Horse _horse = new Horse(new Animal(), new Walkable(), new Swimable());
        private Fish _fish = new Fish(new Animal(), new Swimable());
        private Duck _duck = new Duck(new Animal(), new Walkable(), new Swimable());
        private Crow _crow = new Crow(new Animal(), new Walkable(), new Flyable());
                                        
        public void Specimen()
        {
            _horse.Introduce();
            _fish.Introduce();
            _duck.Introduce();
            _crow.Introduce();
        }
    }
}
