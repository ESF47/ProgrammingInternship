using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.GameProjects.Snake
{
    class LevelEditor
    {
        public void EditorInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
                switch (userInput.Key)
                {
                    case ConsoleKey.RightArrow:
                        // change cursor position
                        break;
                    case ConsoleKey.LeftArrow:
                        // change cursor position
                        break;
                    case ConsoleKey.UpArrow:
                        // change cursor position
                        break;
                    case ConsoleKey.DownArrow:
                        // change cursor position
                        break;
                    case ConsoleKey.D1:
                        // place some kind of block
                        break;
                    case ConsoleKey.D2:
                        // place some kind of block
                        break;
                    case ConsoleKey.Enter:
                        // end the editor phase
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
