using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProgrammingInternship.CommonFeatures;

namespace ProgrammingInternship.GholizadehPractices
{
    class NumPrinter
    {
        // refference types
        List<int> ListOfNumbers = new List<int>();
        string[] mainMenuButtonTexts = new string[] { "use 'Up' and 'Down' arrows to navigate ",
                                                      "\nstart the process ",
                                                      "go to hob" };
        string[] sideMenuButtonTexts = new string[] { "do you want to enter another number?",
                                                      "Yes",
                                                      "No" };

        // side methods 
        void listDataInput()  // use this method in the Data Entry process
        {
            Console.Clear();
            int added = Notifications.formatCheck("enter a number");
            ListOfNumbers.Add(added);
        }
        void processClose()   // use this method in the Data Entry process
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Your numbers from last to first are :");
            for (int i = ListOfNumbers.Count - 1; i >= 0; i = i - 1)
            {
                Console.WriteLine(ListOfNumbers[i]);
            }
            Console.WriteLine("\npress any key to continue");
            Console.ReadKey();
            Console.Clear();
            ListOfNumbers.Clear();
        }
        void dataEntry()
        {
            // take numbers from user
            listDataInput();

            Console.Clear();
            int currentButton = 1; // the default button which indicator starts from

            while (true)
            {
                Console.Clear();

                // making the Yes/No side menu
                InteractiveMenu.buttonDrawer(sideMenuButtonTexts, currentButton, ConsoleColor.Red, ConsoleColor.White);

                ConsoleKeyInfo userInput = Console.ReadKey();
                switch (userInput.Key)
                {
                    case ConsoleKey.DownArrow:
                        currentButton = InteractiveMenu.buttonNavigator(1, sideMenuButtonTexts.Length - 1, currentButton, ConsoleKey.DownArrow);
                        break;

                    case ConsoleKey.UpArrow:
                        currentButton = InteractiveMenu.buttonNavigator(1, sideMenuButtonTexts.Length - 1, currentButton, ConsoleKey.UpArrow);
                        break;

                    case ConsoleKey.Enter:
                        switch (currentButton)
                        {
                            case 1:
                                listDataInput();
                                break;

                            case 2:
                                processClose();
                                return;

                            default:
                                break;
                        }
                        break; ;

                    default:
                        break;
                }
            }
        }

        // main process
        public void Printer()
        {
            int currentButton = 1;

            while (true)
            {
                Console.Clear();

                InteractiveMenu.buttonDrawer(mainMenuButtonTexts, currentButton, ConsoleColor.Red, ConsoleColor.White);

                ConsoleKeyInfo userInput = Console.ReadKey();
                switch (userInput.Key)
                {
                    case ConsoleKey.DownArrow:
                        currentButton = InteractiveMenu.buttonNavigator(1, mainMenuButtonTexts.Length - 1, currentButton, ConsoleKey.DownArrow);
                        break;

                    case ConsoleKey.UpArrow:
                        currentButton = InteractiveMenu.buttonNavigator(1, mainMenuButtonTexts.Length - 1, currentButton, ConsoleKey.UpArrow);
                        break;

                    case ConsoleKey.Enter:
                        switch (currentButton)
                        {
                            case 1:
                                dataEntry();
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
