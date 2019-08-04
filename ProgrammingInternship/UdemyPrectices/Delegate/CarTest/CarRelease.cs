using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Delegate.CarTest
{
    class CarRelease
    {
        MontageFunctionalities functionalities = new MontageFunctionalities();
        MontageApply montageApply = new MontageApply();

        MontageApply.CarMontageHandler montageHandler;

        public void ReleaseTheCar()
        {
            montageHandler += functionalities.AddDoor;
            montageHandler += functionalities.AddEngine;
            montageHandler += functionalities.AddWheels;

            montageApply.StartMontage(montageHandler);
        }
    }
}
