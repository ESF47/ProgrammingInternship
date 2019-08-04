using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProgrammingInternship.CommonFeatures;

namespace ProgrammingInternship.GholizadehPractices
{
    class PrimeCheck
    {
        // refference types
        string[] menuButtonTexts = new string[] { "use 'Up' and 'Down' arrows to navigate ",
                                                  "\nstart the process ",
                                                  "go to hob" };

        // side methods 
        void primeCheckProcess()
        {
            int userInput = Notifications.formatCheck("enter a number to check if it's prime or not...");
            bool isPrime = true;
            for (int i = 2; i <= (userInput / 2) - 1; i++)
            {
                if ((userInput % i) == 0)
                {
                    isPrime = false;
                    Console.WriteLine("{0} is not a prime number \n\npress any key to continue...", userInput);
                    Console.ReadKey();
                    return;
                }
                else
                    isPrime = true;
            }
            if (isPrime)
            {
                Console.WriteLine("{0} is a prime number \n\npress any key to continue...", userInput);
                Console.ReadKey();
            }
        }

        // main process
        public void PrimeChecker()
        {
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
                                Console.Clear();
                                primeCheckProcess();
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
