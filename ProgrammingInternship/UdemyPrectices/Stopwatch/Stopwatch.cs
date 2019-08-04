using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Stopwatch
{
    class Stopwatch
    {
        private DateTime _startTime;
        private DateTime _finishTime;
        private int _recordedTime;
        private bool _isWatchAlreadyStarted = false;

        public void WatchFunction()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Press S to start the watch, Press the H to stop it");

                var userInput = Console.ReadKey();
                switch (userInput.Key)
                {
                    case ConsoleKey.S:
                        WatchStart();
                        break;

                    case ConsoleKey.H:
                        WatchStop();
                        break;

                    default:
                        break;
                }
            }
        }

        private void WatchStart()
        {
            if (!_isWatchAlreadyStarted)
            {
                _startTime = DateTime.Now;
                _isWatchAlreadyStarted = true;
            }
        }

        private void WatchStop()
        {
            if (_isWatchAlreadyStarted)
            {
                _finishTime = DateTime.Now;
                CalculateAndShow();
                _isWatchAlreadyStarted = false;
            }
        }

        private void CalculateAndShow()
        {
            _recordedTime = (_finishTime - _startTime).Seconds;
            Console.Clear();
            Console.WriteLine("The tracked time which we recorded is {0} seconds \n\nPress any key to continue..." , _recordedTime);
            Console.ReadKey();
        }
    }
}
