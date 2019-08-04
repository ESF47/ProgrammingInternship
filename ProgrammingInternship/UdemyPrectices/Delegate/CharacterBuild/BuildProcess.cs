using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Delegate.CharacterBuild
{
    class BuildProcess
    {
        public delegate void CharacterBuildHandler(string characterName);

        public void CharacterBuilder(CharacterBuildHandler characterBuildHandler)
        {
            characterBuildHandler("Jack");
        }
    }
}
