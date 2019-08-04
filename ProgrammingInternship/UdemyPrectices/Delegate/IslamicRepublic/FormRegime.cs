using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Delegate.IslamicRepublic
{
    class FormRegime
    {
        public delegate void RegimePartsHandler(string republicName);

        public void AddRegimeParts(RegimePartsHandler regimePartsHandler)
        {
            regimePartsHandler("Islamic Republic of Iran.");
        }
    }
}
