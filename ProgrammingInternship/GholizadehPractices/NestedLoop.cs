using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProgrammingInternship.CommonFeatures;

namespace ProgrammingInternship.GholizadehPractices
{
    class NestedLoop
    {
        // refference types
        string[] menuButtonTexts = new string[] { "use 'Up' and 'Down' arrows to navigate ",
                                                  "\nstart the process ",
                                                  "go to hob" };

        // side methods
        void nestedLoopProcess()
        {
            int i;
            int j;
            for (i = 2; i < 100; i++)
            {
                for (j = 2; j <= (i / j); j++)
                {
                    if ((i % j) == 0)
                        break;
                }

                if (j > (i / j))
                    Console.WriteLine("{0} is prime", i);
            }
            Console.WriteLine("\npress any key to continue...");
            Console.ReadKey();
        }

        // main process
        public void NestedLoopTester()
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
                                nestedLoopProcess();
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
