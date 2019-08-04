using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Delegate.CharacterBuild
{
    class BuildCategories
    {
        public void EquipPrimaryWeapon(string characterName)
        {
            Console.WriteLine(characterName + "'s " + "Primary weapon is equiped...\n");
        }

        public void EquipSecondaryWeapon(string characterName)
        {
            Console.WriteLine(characterName + "'s " + "Secondary weapon is equiped...\n");
        }

        public void EquipArmor(string characterName)
        {
            Console.WriteLine(characterName + "'s " + "Armor is equiped...\n");
        }

        public void EquipBoots(string characterName)
        {
            Console.WriteLine(characterName + "'s " + "Boots are equiped...\n");
        }
    }
}
