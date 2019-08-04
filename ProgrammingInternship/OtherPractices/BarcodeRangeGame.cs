using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.OtherPractices
{
    class BarcodeRangeGame
    {
        public int Price = 4;

        private int distance = 0;
        private int min = 0;
        private int max = 0;

        public void RangeCalculator()
        {
            
        }

        private void randomNumber()
        {
            Random random = new Random();
            distance = random.Next();
        }
    }
}
