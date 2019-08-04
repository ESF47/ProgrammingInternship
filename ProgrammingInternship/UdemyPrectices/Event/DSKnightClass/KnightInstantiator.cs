using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Event.DSKnightClass
{
    class KnightInstantiator
    {
        //Declare a delegate
        //Declare an event based on the defined delegate
        //Declare a method for defined event
        //Raise the event using the defined method  

        public delegate void ClassMadeEventHandler(object source, EventArgs args);

        public event ClassMadeEventHandler ClassMade;

        public void ClassInstantiator()
        {
            Console.WriteLine("Instantiating a Knight, Please be patient...");
            Thread.Sleep(2000);

            Console.WriteLine("\nApplying class attributes...");
            Thread.Sleep(2000);

            OnClassMade();

            Console.WriteLine("\nKnight is ready to go!\n");
        }

        protected virtual void OnClassMade()
        {
            if (ClassMade != null)
            {
                ClassMade(this, EventArgs.Empty);
            }
        }
    }
}
