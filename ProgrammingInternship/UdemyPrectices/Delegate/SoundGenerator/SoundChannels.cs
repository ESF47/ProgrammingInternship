using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Delegate.SoundGenerator
{
    class SoundChannels
    {
        public void AddWaves(string clipName)
        {
            Console.WriteLine(clipName + "'s " + "wave sound has been added\n");
        }

        public void AddChores(string clipName)
        {
            Console.WriteLine(clipName + "'s " + "chores sound has been added\n");
        }

        public void AddWind(string clipName)
        {
            Console.WriteLine(clipName + "'s " + "night sound has been added\n");
        }

        public void AddWolf(string clipName)
        {
            Console.WriteLine(clipName + "'s " + "wolf sound has been added\n");
        }
    }
}
