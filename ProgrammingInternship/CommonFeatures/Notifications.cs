using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.CommonFeatures
{
    class Notifications
    {
        // this simple method tells user if his data is not from the correct type, also this is used in Format Check method
        public static void wrongInputTextPrint()
        {
            Console.Clear();
            Console.WriteLine("your input was invalid \n\npress any key to continue...");
            Console.ReadKey();
        }

        // use this method whenever you need to make sure user's input is a number
        public static int formatCheck(string textToAsk)
        {
            int numberToOut = 0;
            bool numFormat = false;
            while (!numFormat)
            {
                Console.Clear();
                Console.WriteLine(textToAsk);
                numFormat = int.TryParse(Console.ReadLine(), out numberToOut);
                if (!numFormat)
                    wrongInputTextPrint();
            }
            return numberToOut;
        }
    }
}
