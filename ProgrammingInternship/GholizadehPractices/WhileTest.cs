using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProgrammingInternship.CommonFeatures;

namespace ProgrammingInternship.GholizadehPractices
{
    class WhileTest
    {
        // refference types
        string[] menuButtonTexts = new string[] { "use 'Up' and 'Down' arrows to navigate ",
                                                  "\nstart the process ",
                                                  "go to hob" };

        // side methods
        void whileProcess()
        {
            int a = 10;
            while (a < 20)
            {
                Console.WriteLine(a);
                a = a + 1;
            }
            int b = 10;
            do
            {
                Console.WriteLine(b);
                b = b + 1;
            } while (b < 20);
            Console.WriteLine("press any key to continue");
            Console.ReadKey();
        }

        // main process
        public void WhileTester()
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
                                whileProcess();
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
