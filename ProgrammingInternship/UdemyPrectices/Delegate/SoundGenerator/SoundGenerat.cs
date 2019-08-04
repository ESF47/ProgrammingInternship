using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Delegate.SoundGenerator
{
    class SoundGenerat
    {
        private SoundChannels _channels = new SoundChannels();
        private SoundGeneratProcess _process = new SoundGeneratProcess();

        public void StartSoundGenerat()
        {
            SoundGeneratProcess.SoundGenerateHandler _soundGenerateHandler = _channels.AddChores;
            _soundGenerateHandler += _channels.AddWaves;
            _soundGenerateHandler += _channels.AddWind;
            _soundGenerateHandler += _channels.AddWolf;

            _process.OnSoundGenerate(_soundGenerateHandler);
        }
    }
}
