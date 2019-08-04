using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProgrammingInternship.CommonFeatures;

namespace ProgrammingInternship.GholizadehPractices
{
    class PowerNumber
    {
        // value types
        int powerBase = 0;
        int powerObject = 0;

        // refference types
        enum powerElements
        {
            powerBase = 0,
            powerObject = 1
        }
        string[] ordinalNumbers = new string[] {"second", "third", "fourth", "fifth", "sixth", "seventh", "eight", "ninth", "tenth",
                                                "eleventh", "twelfth", "thirteenth", "fourteenth", "fifteenth", "sixteenth", "seventeenth",
                                                "eighteenth", "nineteenth", "twentieth", "twenty-first", "twenty-second", "twenty-third",
                                                "twenty-fourth", "twenty-fifth", "twenty-sixth", "twenty-seventh", "twenty-eighth",
                                                "twenty-ninth", "thirtieth"};
        string[] menuButtonTexts = new string[] { "use 'Up' and 'Down' arrows to navigate ",
                                                  "\nstart the process ",
                                                  "go to hob" };
        string[] numberInputTexts = new string[] { "enter the first number as power base",
                                                   "enter the second number as power dealer"};

        // side methods 
        void numberTaker(powerElements powerPart)
        {
            switch (powerPart)
            {
                // process of taking the first number
                case powerElements.powerBase:
                    powerBase = Notifications.formatCheck(numberInputTexts[(int)powerPart]);
                    break;
                // process of taking the second number
                case powerElements.powerObject:
                    powerObject = Notifications.formatCheck(numberInputTexts[(int)powerPart]);
                    break;

                default:
                    break;
            }
        }
        void powerCalculator()
        {
            numberTaker(powerElements.powerBase);
            numberTaker(powerElements.powerObject);
            long result = powerBase;
            for (int i = 0; i <= powerObject - 2; i++)
            {
                result = result * powerBase;
            }
            Console.Clear();
            Console.WriteLine("{0} to the {1} power is {2} \npress any key to continue", powerBase, ordinalNumbers[powerObject - 2], result);
            Console.ReadKey();
        }

        // main process
        public void PowerNumberDealer()
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
                                powerCalculator();
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
