using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProgrammingInternship.CommonFeatures;

namespace ProgrammingInternship.GholizadehPractices
{
    class ElitePrimeCheck
    {
        // value types
        int cycle = 2;                    // cycle is the number which we want to reach it
        int numberOfPrimeNumbers = 0;     // this is the number of prime numbers till we reach the end of the cycle number

        // refference types
        string[] menuButtonTexts = new string[] { "use 'Up' and 'Down' arrows to navigate ",
                                                  "\nstart the process ",
                                                  "go to hob" };

        // side methods
        void primeCheckCalculation()
        {
            cycle = Notifications.formatCheck("enter the number you want to check primes numbers till reach it");

            for (int i = 2; i <= cycle; i++)
            {
                bool isCurrentNumberPrime = true;
                for (int j = 1; j <= ((i / 2) + 1); j++)
                {
                    if ((i % j) == 0 && (i != j) && (j != 1))
                    {
                        isCurrentNumberPrime = false;
                        break;
                    }
                }
                if (isCurrentNumberPrime == true)
                {
                    Console.WriteLine("{0} is prime", i);
                    numberOfPrimeNumbers++;
                }
            }
        }
        void printPrimeNumbers()
        {
            Console.WriteLine("\nthe number of prime numbers in this cycle is : {0}", numberOfPrimeNumbers);
            Console.WriteLine("\nthe process is finished \npress any key to continue");
            Console.ReadKey();
        }

        // main process
        public void ElitePrimeChecker()
        {
            Console.Clear();
            int currentButton = 1;

            while (true)
            {
                Console.Clear();

                InteractiveMenu.buttonDrawer(menuButtonTexts, currentButton, ConsoleColor.Red, ConsoleColor.White);

                ConsoleKeyInfo userInput = Console.ReadKey();
                switch (userInput.Key)
                {
                    case ConsoleKey.DownArrow:
                        currentButton = InteractiveMenu.buttonNavigator(1, menuButtonTexts.Length - 1, currentButton, ConsoleKey.DownArrow);
                        break;

                    case ConsoleKey.UpArrow:
                        currentButton = InteractiveMenu.buttonNavigator(1, menuButtonTexts.Length - 1, currentButton, ConsoleKey.UpArrow);
                        break;

                    case ConsoleKey.Enter:
                        switch (currentButton)
                        {
                            case 1:
                                primeCheckCalculation();
                                printPrimeNumbers();
                                break;

                            case 2:
                                return;

                            default:
                                break;
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
