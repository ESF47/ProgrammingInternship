using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.GameProjects.Snake
{
    public enum MovementDirections
    {
        MovingLeft = 1,
        MovingRight = 2,
        MovingUp = 3,
        MovingDown = 4
    }
    class SnakeMainLoop
    {
        //Change
        // general parameters
        public int score = 0;
        // border parameters are set in the scene setup menu
        private float screenRightBorder;
        private float screenLeftBorder;
        private float screenTopBorder;
        private float screenDownBorder;
        // snake head parameters
        public float snakeHeadSpeed = 0.00005f;
        public float snakeHeadXPos = 1f;
        public float snakeHeadYPos = 1f;
        public string snakeDefaultHeadShape = ">";
        public string[] snakeHeadShapes = new string[]
        {
            ">", // moving east,  Index 0
            "<", // moving west,  Index 1
            "^", // moving north, Index 2
            "V"  // moving south, Index 3
        };
        public ConsoleColor snakeDefaultHeadColor = ConsoleColor.Red;
        public MovementDirections currentMovingDirection = MovementDirections.MovingRight;
        // snaked body parameters
        public ConsoleColor snakeBodyDefaultColor = ConsoleColor.DarkGreen;
        public int tailLenght = 5;
        public string bodyDefaultShape = "*";
        public List<float> bodyPartsXPos = new List<float>();
        public List<float> bodyPartsYPos = new List<float>();
        // pickups parameters
        public List<PickUp> pickUps = new List<PickUp>();
        public int initNumOfPickups = 6;
        // level geometry parameters
        public List<int> levelBoundryXPos = new List<int>();
        public List<int> levelBoundryYPos = new List<int>();
        // editor parameters
        SnakeLevelEditor levelEditor = new SnakeLevelEditor();

        // level editor
        public void EditorProcess()
        {
            levelEditor.UpdateEditor();
            levelEditor.RenderEditor();
        }

        // game initialization
        void GameInitialization()
        {
            SceneSetup();
            LevelGeometrySet();
            SnakeValueSet(4, 4, 1);
            SnakeBodyValueSet();
            PickUpGenerate(initNumOfPickups);
        }
        void SceneSetup()
        {
            Console.SetWindowSize(100, 40);
            Console.SetBufferSize(100, 40);
            Console.SetWindowPosition(0, 0);
            Console.CursorVisible = false;
            Console.Clear();

            screenRightBorder = Console.BufferWidth - 1;
            screenLeftBorder = 0;
            screenTopBorder = 0;
            screenDownBorder = Console.BufferHeight - 1;
        }
        void SnakeValueSet(float XPos, float YPos, float speed)
        {
            snakeHeadXPos = XPos;
            snakeHeadYPos = YPos;
            snakeHeadSpeed = speed;
        }
        void SnakeBodyValueSet()
        {
            switch (currentMovingDirection)
            {
                case MovementDirections.MovingLeft:
                    for (int i = 1; i <= tailLenght; i++)
                    {
                        bodyPartsXPos.Add(snakeHeadXPos + i);
                        bodyPartsYPos.Add(snakeHeadYPos);
                    }
                    break;
                case MovementDirections.MovingRight:
                    for (int i = 1; i <= tailLenght; i++)
                    {
                        bodyPartsXPos.Add(snakeHeadXPos - i);
                        bodyPartsYPos.Add(snakeHeadYPos);
                    }
                    break;
                case MovementDirections.MovingUp:
                    for (int i = 1; i <= tailLenght; i++)
                    {
                        bodyPartsXPos.Add(snakeHeadXPos);
                        bodyPartsYPos.Add(snakeHeadYPos + i);
                    }
                    break;
                case MovementDirections.MovingDown:
                    for (int i = 1; i <= tailLenght; i++)
                    {
                        bodyPartsXPos.Add(snakeHeadXPos);
                        bodyPartsYPos.Add(snakeHeadYPos - i);
                    }
                    break;
                default:
                    break;
            }
        }
        void PickUpGenerate(int number)
        {
            for (int i = 0; i < number; i++)
            {
                Random rnd = new Random(DateTime.Now.Millisecond * i);
                pickUps.Add(new PickUp(rnd.Next((int)screenLeftBorder, (int)screenRightBorder),
                                       rnd.Next((int)screenTopBorder, (int)screenDownBorder), ConsoleColor.Red));
            }
        }
        void LevelGeometrySet()
        {
            for (int i = 1; i < 41; i++)
            {
                for (int j = 10; j < 31; j++)
                {
                    if (i == 1 || i == 40)
                    {
                        levelBoundryXPos.Add(i);
                        levelBoundryYPos.Add(j);
                    }
                    else
                    {
                        if (j == 10 || j == 30)
                        {
                            levelBoundryXPos.Add(i);
                            levelBoundryYPos.Add(j);
                        }
                    }
                }
            }
        }
        void ValueReset()
        {
            score = 0;
            currentMovingDirection = MovementDirections.MovingRight;
            bodyPartsXPos.Clear();
            bodyPartsYPos.Clear();
            pickUps.Clear();
        }

        // user input
        void GameUserInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
                switch (userInput.Key)
                {
                    case ConsoleKey.RightArrow:
                        if (currentMovingDirection != MovementDirections.MovingLeft)
                            currentMovingDirection = MovementDirections.MovingRight;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (currentMovingDirection != MovementDirections.MovingRight)
                            currentMovingDirection = MovementDirections.MovingLeft;
                        break;
                    case ConsoleKey.UpArrow:
                        if (currentMovingDirection != MovementDirections.MovingDown)
                            currentMovingDirection = MovementDirections.MovingUp;
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentMovingDirection != MovementDirections.MovingUp)
                            currentMovingDirection = MovementDirections.MovingDown;
                        break;
                    case ConsoleKey.Escape:
                        ValueReset();
                        GameLaunch();
                        break;
                    default:
                        break;
                }
            }
        }

        // update process
        void GameUpdateProcess()
        {
            SnakeHeadProcess();
            SnakeBodyProcess();
            SnakeBodyCutOff();
            PickUpsColisionCheck();
            PickURespawn(8);
        }
        void SnakeHeadProcess()
        {
            // don't let snake get out of buffer
            if (snakeHeadXPos >= screenRightBorder)
                snakeHeadXPos = screenLeftBorder;
            else if (snakeHeadXPos <= screenLeftBorder)
                snakeHeadXPos = screenRightBorder;

            if (snakeHeadYPos >= screenDownBorder)
                snakeHeadYPos = screenTopBorder;
            else if (snakeHeadYPos <= screenTopBorder)
                snakeHeadYPos = screenDownBorder;

            switch (currentMovingDirection)
            {
                case MovementDirections.MovingLeft:
                    snakeHeadXPos -= snakeHeadSpeed;
                    break;
                case MovementDirections.MovingRight:
                    snakeHeadXPos += snakeHeadSpeed;
                    break;
                case MovementDirections.MovingUp:
                    snakeHeadYPos -= snakeHeadSpeed;
                    break;
                case MovementDirections.MovingDown:
                    snakeHeadYPos += snakeHeadSpeed;
                    break;
                default:
                    break;
            }
        }
        void SnakeBodyProcess()
        {
            float previousXPos = 0;
            float previousYPos = 0;
            switch (currentMovingDirection)
            {
                case MovementDirections.MovingLeft:
                    float posX = 0;
                    float posY = 0;
                    for (int i = 0; i < bodyPartsYPos.Count; i++)
                    {
                        if (i == 0)
                        {
                            previousXPos = bodyPartsXPos[i];
                            previousYPos = bodyPartsYPos[i];
                            bodyPartsXPos[i] = snakeHeadXPos + 1;
                            bodyPartsYPos[i] = snakeHeadYPos;
                        }
                        else
                        {
                            posX = bodyPartsXPos[i];
                            posY = bodyPartsYPos[i];
                            bodyPartsXPos[i] = previousXPos;
                            bodyPartsYPos[i] = previousYPos;
                            previousXPos = posX;
                            previousYPos = posY;
                        }
                    }
                    break;
                case MovementDirections.MovingRight:
                    for (int i = 0; i < bodyPartsYPos.Count; i++)
                    {
                        if (i == 0)
                        {
                            previousXPos = bodyPartsXPos[i];
                            previousYPos = bodyPartsYPos[i];
                            bodyPartsXPos[i] = snakeHeadXPos - 1;
                            bodyPartsYPos[i] = snakeHeadYPos;
                        }
                        else
                        {
                            posX = bodyPartsXPos[i];
                            posY = bodyPartsYPos[i];
                            bodyPartsXPos[i] = previousXPos;
                            bodyPartsYPos[i] = previousYPos;
                            previousXPos = posX;
                            previousYPos = posY;
                        }
                    }
                    break;
                case MovementDirections.MovingUp:
                    for (int i = 0; i < bodyPartsYPos.Count; i++)
                    {
                        if (i == 0)
                        {
                            previousXPos = bodyPartsXPos[i];
                            previousYPos = bodyPartsYPos[i];
                            bodyPartsXPos[i] = snakeHeadXPos;
                            bodyPartsYPos[i] = snakeHeadYPos + 1;
                        }
                        else
                        {
                            posX = bodyPartsXPos[i];
                            posY = bodyPartsYPos[i];
                            bodyPartsXPos[i] = previousXPos;
                            bodyPartsYPos[i] = previousYPos;
                            previousXPos = posX;
                            previousYPos = posY;
                        }
                    }
                    break;
                case MovementDirections.MovingDown:
                    for (int i = 0; i < bodyPartsYPos.Count; i++)
                    {
                        if (i == 0)
                        {
                            previousXPos = bodyPartsXPos[i];
                            previousYPos = bodyPartsYPos[i];
                            bodyPartsXPos[i] = snakeHeadXPos;
                            bodyPartsYPos[i] = snakeHeadYPos - 1;
                        }
                        else
                        {
                            posX = bodyPartsXPos[i];
                            posY = bodyPartsYPos[i];
                            bodyPartsXPos[i] = previousXPos;
                            bodyPartsYPos[i] = previousYPos;
                            previousXPos = posX;
                            previousYPos = posY;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        void SnakeBodyLengthIncrease()
        {
            bodyPartsXPos.Add(bodyPartsXPos[bodyPartsXPos.Count - 1]);
            bodyPartsYPos.Add(bodyPartsYPos[bodyPartsYPos.Count - 1]);
        }
        void SnakeBodyCutOff()
        {
            for (int i = 0; i < bodyPartsXPos.Count; i++)
            {
                if (bodyPartsXPos[i] == snakeHeadXPos && bodyPartsYPos[i] == snakeHeadYPos)
                {
                    for (int j = i; j < bodyPartsXPos.Count; j++)
                    {
                        bodyPartsXPos.Remove(bodyPartsXPos[j]);
                        bodyPartsYPos.Remove(bodyPartsYPos[j]);
                    }
                    return;
                }
            }
        }
        void PickUpsColisionCheck()
        {
            for (int i = 0; i < pickUps.Count; i++)
            {
                if (pickUps[i].ColisionCheck(snakeHeadXPos, snakeHeadYPos))
                {
                    pickUps.Remove(pickUps[i]);
                    score++;
                    SnakeBodyLengthIncrease();
                }
            }
        }
        void PickURespawn(int respawnNum)
        {
            if (pickUps.Count == 0)
                PickUpGenerate(respawnNum);
        }

        // game render process
        void GameRenderProcess()
        {
            RenderCleanUp();
            LevelGeometryRender();
            SnakeHeadRender(snakeDefaultHeadColor);
            SnakeBodyRender(bodyDefaultShape, snakeBodyDefaultColor);
            PickUpsRender();
            HUD(ConsoleColor.Green, ConsoleColor.Yellow);
        }
        void SnakeHeadRender(ConsoleColor defColor)
        {
            Console.SetCursorPosition((int)snakeHeadXPos, (int)snakeHeadYPos);
            // saving the default color to revert it afterwards
            ConsoleColor prechangedColor = Console.ForegroundColor;
            Console.ForegroundColor = defColor;
            // selecting the shape of snake head
            switch (currentMovingDirection)
            {
                case MovementDirections.MovingRight:
                    Console.Write(snakeHeadShapes[0]);
                    break;
                case MovementDirections.MovingLeft:
                    Console.Write(snakeHeadShapes[1]);
                    break;
                case MovementDirections.MovingUp:
                    Console.Write(snakeHeadShapes[2]);
                    break;
                case MovementDirections.MovingDown:
                    Console.Write(snakeHeadShapes[3]);
                    break;
                default:
                    break;
            }
            Console.ForegroundColor = prechangedColor;
        }
        void SnakeBodyRender(string defShape, ConsoleColor defColor)
        {
            ConsoleColor prechangedColor = Console.ForegroundColor;
            Console.ForegroundColor = defColor;
            for (int i = 0; i < bodyPartsXPos.Count; i++)
            {
                Console.SetCursorPosition((int)bodyPartsXPos[i], (int)bodyPartsYPos[i]);
                Console.Write(defShape);
            }
            Console.ForegroundColor = prechangedColor;
        }
        void PickUpsRender()
        {
            for (int i = 0; i < pickUps.Count; i++)
            {
                pickUps[i].PickUpRenderer();
            }
        }
        void HUD(ConsoleColor scoreColor, ConsoleColor lengthColor)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            // printing the player score
            Console.ForegroundColor = scoreColor;
            Console.SetCursorPosition(91, 0);
            Console.Write("Score: {0}", score);
            // printing the snake tail length
            Console.ForegroundColor = lengthColor;
            Console.SetCursorPosition(90, 1);
            Console.Write("Length: {0}", bodyPartsXPos.Count);

            Console.ForegroundColor = defaultColor;
        }
        void LevelGeometryRender()
        {
            for (int i = 0; i < levelBoundryXPos.Count; i++)
            {
                Console.SetCursorPosition(levelBoundryXPos[i], levelBoundryYPos[i]);
                Console.Write("#");
            }
        }
        void RenderCleanUp()
        {
            Console.Clear();
        }

        // game loop
        public void GameLaunch()
        {
            //while (true)
            //{
            //    EditorProcess();
            //    TickMaker(20, 20);
            //}
            GameInitialization();
            //editor.EditorInitialization();
            //while (editor.IsInEditorMode)
            //{
            //    EditorProcess();
            //    LevelGeometryRender();
            //    TickMaker(80, 80);
            //    RenderCleanUp();
            //}
            while (true)
            {
                GameUserInput();
                GameUpdateProcess();
                GameRenderProcess();
                TickMaker(80, 80);
            }
        }

        // side process
        public void TickMaker(int horizontalTick, int verticalTick)
        {
            // see if snake's moving horizontal
            if (currentMovingDirection == MovementDirections.MovingRight || currentMovingDirection == MovementDirections.MovingLeft)
                System.Threading.Thread.Sleep(horizontalTick);
            // see if snake's moving vertical
            else if (currentMovingDirection == MovementDirections.MovingUp || currentMovingDirection == MovementDirections.MovingDown)
                System.Threading.Thread.Sleep(verticalTick);
        }

        // game menus
    }

}
