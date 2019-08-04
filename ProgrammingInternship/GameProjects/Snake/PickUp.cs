using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.GameProjects.Snake
{
    class PickUp
    {
        // general parameters
        private float pickUpXPos = 0;
        private float pickUpYPos = 0;
        private ConsoleColor pickUpColor = ConsoleColor.White;
        public PickUp(float XPos, float YPos, ConsoleColor color)
        {
            pickUpXPos = XPos;
            pickUpYPos = YPos;
            pickUpColor = color;
        }
        public void PickUpRenderer()
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = pickUpColor;
            Console.SetCursorPosition((int)pickUpXPos, (int)pickUpYPos);
            Console.Write("@");

            Console.ForegroundColor = defaultColor;
        }
        public bool ColisionCheck(float snakeHeadXPos, float snakeHeadYPos)
        {
            if (snakeHeadXPos == pickUpXPos && snakeHeadYPos == pickUpYPos)
            {
                return true;
            }
            return false;
        }
    }
}
