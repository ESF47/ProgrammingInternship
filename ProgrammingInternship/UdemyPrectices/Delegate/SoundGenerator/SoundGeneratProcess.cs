using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Delegate.SoundGenerator
{
    class SoundGeneratProcess
    {
        public delegate void SoundGenerateHandler(string clipName);

        public void OnSoundGenerate(SoundGenerateHandler soundGenerateHandler)
        {
            soundGenerateHandler("Icy World");
        }
    }
}
