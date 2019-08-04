using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.CommonFeatures
{
    class InteractiveMenu
    {
        // draws buttons and also changes the color of buttons
        public static void buttonDrawer(string[] buttonTexts, int startButton, ConsoleColor interactionColor, ConsoleColor idleColor)
        {
            for (int i = 0; i <= buttonTexts.Length - 1; i++)
            {
                if (i == startButton)
                    Console.ForegroundColor = interactionColor;
                else
                    Console.ForegroundColor = idleColor;

                Console.WriteLine(buttonTexts[i]);
            }
        }
        
        // handles the navigaton between buttons in different menus
        public static int buttonNavigator(int firstButton, int lastButton, int buttonState, ConsoleKey navigationButton)
        {
            switch (navigationButton)
            {
                case ConsoleKey.UpArrow:
                    if (buttonState == firstButton)
                        return firstButton;
                    else
                        return buttonState - 1;

                case ConsoleKey.DownArrow:
                    if (buttonState == lastButton)
                        return lastButton;
                    else
                        return buttonState + 1;

                default:
                    return buttonState;
            }
        }
    }
}
