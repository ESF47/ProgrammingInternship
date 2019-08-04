using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Delegate.IslamicRepublic
{
    class RepublicStart
    {
        FormRegime formRegime = new FormRegime();
        RegimeParts regimeParts = new RegimeParts();

        public void StartTheRegime()
        {
            FormRegime.RegimePartsHandler regimePartsHandler = regimeParts.AddKhobregan;
            regimePartsHandler += regimeParts.AddShorayeNegahban;
            regimePartsHandler += regimeParts.AddPrimeLeader;
            regimePartsHandler += regimeParts.SlayPeople;

            formRegime.AddRegimeParts(regimePartsHandler);
        }
    }
}
