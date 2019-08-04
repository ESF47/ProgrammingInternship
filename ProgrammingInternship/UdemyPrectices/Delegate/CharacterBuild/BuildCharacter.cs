using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Delegate.CharacterBuild
{
    class BuildCharacter
    {
        private BuildProcess _buildProcess = new BuildProcess();
        private BuildCategories _buildCategories = new BuildCategories();
        
        public void OnCharacterBuild()
        {
            BuildProcess.CharacterBuildHandler characterBuildHandler = _buildCategories.EquipPrimaryWeapon;
            characterBuildHandler += _buildCategories.EquipSecondaryWeapon;
            characterBuildHandler += _buildCategories.EquipArmor;
            characterBuildHandler += _buildCategories.EquipBoots;

            _buildProcess.CharacterBuilder(characterBuildHandler);
        }
    }
}
