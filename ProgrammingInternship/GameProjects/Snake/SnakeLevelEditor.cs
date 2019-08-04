using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.GameProjects.Snake
{
    class SnakeLevelEditor
    {
        enum BlockType
        {
            wall,
            reward
        }
        class Block
        {
            BlockType type;
            int x, y;
            string shape = "";
            public Block() { }
            public Block(int x, int y, BlockType type)
            {
                this.x = x;
                this.y = y;
                this.type = type;
                if (type == BlockType.wall)
                {
                    shape = "▓";
                }
                else
                {
                    shape = "♥";
                }
            }
            public void Render()
            {
                Console.SetCursorPosition(x, y);
                Console.Write(shape);
            }
        }
        int cX, cY;
        List<Block> blocks = new List<Block>();
        public void UpdateEditor()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
                switch (userInput.Key)
                {
                    case ConsoleKey.RightArrow:
                        cX++;
                        break;
                    case ConsoleKey.LeftArrow:
                        cX--;
                        break;
                    case ConsoleKey.UpArrow:
                        cY--;
                        break;
                    case ConsoleKey.DownArrow:
                        cY++;
                        break;
                    case ConsoleKey.D1:
                        blocks.Add(new Block(cX, cY, BlockType.wall));
                        break;
                    case ConsoleKey.D2:
                        blocks.Add(new Block(cX, cY, BlockType.reward));
                        break;
                    case ConsoleKey.Enter:
                        break;
                    default:
                        break;
                }
            }
        }
        public void RenderEditor()
        {
            //Console.Clear();
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i].Render();
            }
            Console.SetCursorPosition(cX, cY);
            //Console.Write("░");
        }
    }
}
