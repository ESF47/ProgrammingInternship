using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Event.DSKnightClass
{
    class KnightAttributeHandler
    {
        KnightInstantiator _knightInstantiator = new KnightInstantiator();

        VitalityHandler _vitalityHandler = new VitalityHandler();
        StrengthHandler _strenghtHandler = new StrengthHandler();
        DexterityHandler _dexterityHandler = new DexterityHandler();
        EnduranceHandler _enduranceHandler = new EnduranceHandler();

        public void BuildKnight()
        {
            _knightInstantiator.ClassMade += _vitalityHandler.SetVitality;
            _knightInstantiator.ClassMade += _strenghtHandler.SetStrength;
            _knightInstantiator.ClassMade += _dexterityHandler.SetDexterity;
            _knightInstantiator.ClassMade += _enduranceHandler.SetEndurance;

            _knightInstantiator.ClassInstantiator();
        }
    }
}
