using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Delegate.CarTest
{
    class MontageApply
    {
        public delegate void CarMontageHandler(string dayTime);

        public void StartMontage(CarMontageHandler montageHandler)
        {
            montageHandler("Afternoon");
        }
    }
}
