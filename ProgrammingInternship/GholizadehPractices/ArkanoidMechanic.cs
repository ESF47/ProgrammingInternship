using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProgrammingInternship.CommonFeatures;

namespace ProgrammingInternship.GholizadehPractices
{
    public enum BallDirection
    {
        none = 0,
        horizontalEdges = 1,
        verticalEdges = 2,
        edgeCorner = 3
    }

    class ArkanoidMechanic
    {
        class Block
        {
            Vec2 min, max;
            int blockXPos = 0;
            int blockYPos = 0;
            int blockWidth = 5;
            int blockHeight = 2;
            bool hasPowerUp = false;
            // PowerUp pu = null;
            ConsoleColor color = ConsoleColor.White;
            // class constructor
            public Block(int XPosition, int YPosition, int width, int height, ConsoleColor blockColor)
            {
                blockXPos = XPosition;
                blockYPos = YPosition;
                blockWidth = width;
                blockHeight = height;
                min = new Vec2(blockXPos, blockYPos);
                max = new Vec2(blockXPos + blockWidth, blockYPos + blockHeight);
                color = blockColor;
            }
            public void BlockRenderer()
            {
                //color 
                for (int i = blockYPos; i < blockYPos + blockHeight; i++)
                {
                    Console.SetCursorPosition(blockXPos, i);
                    Console.ForegroundColor = color;
                    for (int j = 0; j  < blockWidth; j ++)
                    {
                        Console.Write("=");
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            public BallDirection BlockCollisionCheck(int ballXPos, int ballYPos, float ballSpeed)
            {
                if ((ballYPos + ballSpeed < blockYPos + blockHeight && ballYPos + ballSpeed > blockYPos) &&
                    (ballXPos + ballSpeed < blockXPos + blockWidth && ballXPos + ballSpeed > blockXPos))
                {
                    if (hasPowerUp)
                    {
                        hasPowerUp = false;
                        // pu = new PowerUp(...);
                        // pu.Activate();
                    }
                    // calculating the distance of ball from block edges
                    float[] distanceFromEdges = new float[4];
                    distanceFromEdges[0] = Math.Abs(ballXPos - min.x); // left edge
                    distanceFromEdges[1] = Math.Abs(ballYPos - min.y); // top edge
                    distanceFromEdges[2] = Math.Abs(ballXPos - max.x); // right edge
                    distanceFromEdges[3] = Math.Abs(ballYPos - min.y); // bottom edge

                    float least = 0;
                    for (int i = 0; i < distanceFromEdges.Length; i++)
                    {
                        if (distanceFromEdges[i] <= least)
                            least = distanceFromEdges[i];
                    }

                    if (least == distanceFromEdges[0] || least == distanceFromEdges[2])
                        return BallDirection.horizontalEdges;
                    else if (least == distanceFromEdges[1] || least == distanceFromEdges[3])
                        return BallDirection.verticalEdges;
                    else
                        return BallDirection.edgeCorner;
                }
                return BallDirection.none;
            }
            public bool BlockCollisionWithGuider(int guiderXPos, int guiderYPos)
            {
                if ((guiderYPos < blockYPos + blockHeight && guiderYPos > blockYPos) &&
                   (guiderXPos < blockXPos + blockWidth && guiderXPos > blockXPos))
                    return true;
                return false;
            }
        }

        // general parameters
        int score = 0;
        bool gameReset = false;
        bool gameQuit = false;
        // blocks objects
        List<Block> blocks = new List<Block>();
        int howManyBlocks = 16; 
        // ball parameters
        public float ballSpeed = 0.28f;
        public float ballPosX = 2f;
        public float ballPosY = 10f;
        public bool ballMovingForward = true;
        public bool ballMovingDownward = true;
        // ball guider parameters
        List<int> guiderXPoses = new List<int>();
        List<int> guiderYPoses = new List<int>();
        // platform parameters
        float platformSpeed = 2f;
        float platformPosX = 46f;
        float platformPosY = 36f;
        string platformShape = "========";

        // menu buttons text
        string[] startMenuButtonTexts = new string[] { "use 'Up' and 'Down' arrows to navigate ",
                                                       "\nstart the game ",
                                                       "go to hob" };
        string[] loseMenuTexts = new string[] { "You Lose! use 'Up' and 'Down' arrows to navigate",
                                                "\nstart again",
                                                "back to main menu"};

        // game initialization
        void GameInitialization()
        {
            SceneSetup();
            ValueReset();
            BallSetPosition(ballPosX, ballPosY);
            PlatformSetPosition(platformPosX, platformPosY, platformShape);
            BlockObjectCreat();
        }
        void SceneSetup()
        {
            Console.SetWindowSize(100, 40);
            Console.SetBufferSize(100, 40);
            Console.SetWindowPosition(0, 0);
            Console.CursorVisible = false;
            Console.Clear();
        }
        void ValueReset()
        {
            // resetting general parameters
            score = 0;
            gameReset = false;
            gameQuit = false;
            // resetting blocks objects
            blocks.Clear();
            howManyBlocks = 16;
            // resetting ball parameters
            ballSpeed = 0.28f;
            ballPosX = 2f;
            ballPosY = 10f;
            ballMovingForward = true;
            ballMovingDownward = true;
            // resetting platform parameters
            platformSpeed = 2f;
            platformPosX = 46f;
            platformPosY = 36f;
        }
        void BallSetPosition(float ballPosX, float ballPosY)
        {
            Console.SetCursorPosition((int)ballPosX, (int)ballPosY);
            Console.Write("*");
        }
        void PlatformSetPosition(float platformPosX, float platformPosY, string platformShape)
        {
            Console.SetCursorPosition((int)platformPosX, (int)platformPosY);
            Console.Write(platformShape);
        }
        void BlockObjectCreat()
        {
            int width = 4;
            int height = 2;
            int YPos = 10;
            int XPos = 0;
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < howManyBlocks; i++)
            {
                XPos = (i * width) + (i*2);
                /* if (XPos + width >= Console.BufferWidth)
                {
                    YPos += height * 2;
                } */ //not using this code block yet
                blocks.Add(new Block(XPos, YPos, width, height, (ConsoleColor)rnd.Next(1, 16)));
            }
        } // must be used in GameInitialization method

        // user input
        void GameUserInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
                switch (userInput.Key)
                {
                    case ConsoleKey.RightArrow:
                        platformPosX += platformSpeed;
                        break;
                    case ConsoleKey.LeftArrow:
                        platformPosX -= platformSpeed;
                        break;
                    case ConsoleKey.R:
                        gameReset = true;
                        break;
                    case ConsoleKey.Escape:
                        gameReset = true;
                        gameQuit = true;
                        break;
                    default:
                        break;
                }
            }
        }

        // update process
        void GameUpdateProcess()
        {
            BallProcess();
            PlatformProcess();
            BlocksCollisionCheck();
            BallGuiderRemoveProcess();
        }
        void BallProcess()
        {
            // moving ball and defining vector direction
            // vector A
            if(ballMovingForward && ballPosX <= Console.BufferWidth - 2 && ballMovingDownward && ballPosY <= Console.BufferHeight - 2)
            {
                ballPosX += ballSpeed;
                ballPosY += ballSpeed;
            }
            // vector B
            else if(!ballMovingForward && ballPosX >= 2 && ballMovingDownward && ballPosY <= Console.BufferHeight - 2)
            {
                ballPosX -= ballSpeed;
                ballPosY += ballSpeed;
            }
            // vector C
            else if (!ballMovingForward && ballPosX >= 2 && !ballMovingDownward && ballPosY >= 2)
            {
                ballPosX -= ballSpeed;
                ballPosY -= ballSpeed;
            }
            // vector D
            else if(ballMovingForward && ballPosX <= Console.BufferWidth - 2 && !ballMovingDownward && ballPosY >= 2)
            {
                ballPosX += ballSpeed;
                ballPosY -= ballSpeed;
            }

            // changing direction after hitting walls
            // hitting right side wall
            if (ballPosX >= Console.BufferWidth - 2)
            {
                ballMovingForward = false;
                if (ballMovingDownward)
                {
                    BallGuiderResetProcess();
                    BallGuiderInitProcess();
                }
            }
            // hitting left side wall
            else if (ballPosX <= 2)
            {
                ballMovingForward = true;
                if (ballMovingDownward)
                {
                    BallGuiderResetProcess();
                    BallGuiderInitProcess();
                }
            }
            // hitting bottom side wall
            if (ballPosY >= Console.BufferHeight - 2)
            {
                //LoseMenu();
                ballMovingDownward = false;
                BallGuiderResetProcess();
            }
            // hitting top side wall
            else if (ballPosY <= 2)
            {
                ballMovingDownward = true;
                BallGuiderResetProcess();
                BallGuiderInitProcess();
            }

            // changing direction after hitting the platform
            if (ballPosY > platformPosY && (ballPosX >= platformPosX && ballPosX <= platformPosX + (platformShape.Length - 1)))
            {
                ballMovingDownward = false;
                BallGuiderResetProcess();
            }
        }
        void PlatformProcess()
        {
            // don't let platform get out of buffer
            platformPosX = Math.Min(Math.Max(platformPosX, 0), Console.BufferWidth - platformShape.Length);
        }
        void BlocksCollisionCheck()
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                switch (blocks[i].BlockCollisionCheck((int)ballPosX, (int)ballPosY, ballSpeed))
                {
                    case BallDirection.horizontalEdges:
                        score++;
                        blocks.RemoveAt(i);
                        ballMovingForward = !ballMovingForward;
                        BallGuiderResetProcess();
                        if (ballMovingDownward)
                            BallGuiderInitProcess();
                        break;
                    case BallDirection.verticalEdges:
                        score++;
                        blocks.RemoveAt(i);
                        ballMovingDownward = !ballMovingDownward;
                        BallGuiderResetProcess();
                        if (ballMovingDownward)
                            BallGuiderInitProcess();
                        break;
                    case BallDirection.edgeCorner:
                        score++;
                        blocks.RemoveAt(i);
                        ballMovingForward = !ballMovingForward;
                        ballMovingDownward = !ballMovingDownward;
                        BallGuiderResetProcess();
                        if (ballMovingDownward)
                            BallGuiderInitProcess();
                        break;
                    default:
                        break;
                }
            }
        }
        void BallGuiderInitProcess() // make sure to use this method when the ballMovingDownward is true
        {
                int currentGuiderPosX = (int)ballPosX;
                int currentGuiderPosY = (int)ballPosY;
                while (currentGuiderPosX < Console.BufferWidth - 1 && currentGuiderPosX > 1 && currentGuiderPosY < Console.BufferHeight - 1)
                {
                    // check if guider has been reached any of blocks
                    for (int i = 0; i < blocks.Count; i++)
                    {
                        if (blocks[i].BlockCollisionWithGuider(currentGuiderPosX + 1, currentGuiderPosY + 1))
                            return;
                    }
                    // check if guider has been reached the platform
                    if (currentGuiderPosX + 1 <= platformPosX + platformShape.Length - 1 && currentGuiderPosX + 1 >= platformPosX &&
                        currentGuiderPosY + 1 >= platformPosY)
                        return;
                    // adding position points in position lists
                    currentGuiderPosY++;
                    guiderYPoses.Add(currentGuiderPosY);
                    if (ballMovingForward)
                    {
                        currentGuiderPosX++;
                        guiderXPoses.Add(currentGuiderPosX);
                    }
                    else if (!ballMovingForward)
                    {
                        currentGuiderPosX--;
                        guiderXPoses.Add(currentGuiderPosX);
                    }
                }
        }
        void BallGuiderRemoveProcess()
        {
            if (ballMovingForward)
            {
                for (int i = 0; i < guiderXPoses.Count; i++)
                {
                    if (ballPosX >= guiderXPoses[i])
                        guiderXPoses.Remove(guiderXPoses[i]);
                }
            }
            else if (!ballMovingForward)
            {
                for (int i = 0; i < guiderXPoses.Count; i++)
                {
                    if (ballPosX <= guiderXPoses[i])
                        guiderXPoses.Remove(guiderXPoses[i]);
                }
            }
            for (int i = 0; i < guiderYPoses.Count; i++)
            {
                if (ballPosY >= guiderYPoses[i])
                    guiderYPoses.Remove(guiderYPoses[i]);
            }
        }
        void BallGuiderResetProcess()
        {
            guiderXPoses.Clear();
            guiderYPoses.Clear();
        }

        // render process
        void GameRenderProcess()
        {
            RenderCleanUp();
            BallRenderer((int)ballPosX, (int)ballPosY);
            PlatformRender(platformPosX, platformPosY, platformShape);
            BlocksRender();
            BallGuiderRenderer(ConsoleColor.DarkRed);
            HUD(98, 0);

        }
        void RenderCleanUp()
        {
            Console.Clear();
        }
        void BallRenderer(float ballPosX, float ballPosY)
        {
            Console.SetCursorPosition((int)ballPosX, (int)ballPosY);
            Console.Write("*");
        }
        void PlatformRender(float platformPosX, float platformPosY, string platformShape)
        {
            Console.SetCursorPosition((int)platformPosX, (int)platformPosY);
            Console.Write(platformShape);
        }
        void BlocksRender()
        {
            for (int i = 0; i <= blocks.Count - 1; i++)
            {
                blocks[i].BlockRenderer();
            }
        }
        void HUD(int scoreXPos, int scoreYPos)
        {
            Console.SetCursorPosition(scoreXPos, scoreYPos);
            // storing and setting console color
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
 
            Console.Write(score);
            // setting color to default color
            Console.ForegroundColor = defaultColor;

        }
        void BallGuiderRenderer(ConsoleColor guiderColor)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = guiderColor;
            for (int i = 0; i < guiderYPoses.Count - 1; i++)
            {
                Console.SetCursorPosition(guiderXPoses[i], guiderYPoses[i]);
                Console.Write("'");
            }
            Console.ForegroundColor = defaultColor;
        }

        // game loop
        void GameLaunch()
        {
            while (gameQuit == false)
            {
                GameInitialization();
                while (gameReset == false)
                {
                    GameUserInput();
                    GameUpdateProcess();
                    GameRenderProcess();
                    System.Threading.Thread.Sleep(10);
                }
            }
            gameQuit = false;
        }
        
        // game menus
        public void MainMenu()
        {
            int currentButton = 1;

            while (true)
            {
                Console.Clear();

                InteractiveMenu.buttonDrawer(startMenuButtonTexts, currentButton, ConsoleColor.Red, ConsoleColor.White);

                ConsoleKeyInfo userInput = Console.ReadKey();
                switch (userInput.Key)
                {
                    case ConsoleKey.DownArrow:
                        currentButton = InteractiveMenu.buttonNavigator(1, startMenuButtonTexts.Length - 1, currentButton, ConsoleKey.DownArrow);
                        break;

                    case ConsoleKey.UpArrow:
                        currentButton = InteractiveMenu.buttonNavigator(1, startMenuButtonTexts.Length - 1, currentButton, ConsoleKey.UpArrow);
                        break;

                    case ConsoleKey.Enter:
                        switch(currentButton)
                        {
                            case 1:
                                GameLaunch();
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
        public void LoseMenu()
        {
            bool exitLoseMenu = false;
            int currentButton = 1;

            while (!exitLoseMenu)
            {
                Console.Clear();

                InteractiveMenu.buttonDrawer(loseMenuTexts, currentButton, ConsoleColor.Red, ConsoleColor.White);

                ConsoleKeyInfo userInput = Console.ReadKey();
                switch (userInput.Key)
                {
                    case ConsoleKey.DownArrow:
                        currentButton = InteractiveMenu.buttonNavigator(1, loseMenuTexts.Length - 1, currentButton, ConsoleKey.DownArrow);
                        break;

                    case ConsoleKey.UpArrow:
                        currentButton = InteractiveMenu.buttonNavigator(1, loseMenuTexts.Length - 1, currentButton, ConsoleKey.UpArrow);
                        break;

                    case ConsoleKey.Enter:
                        switch (currentButton)
                        {
                            case 1:
                                GameLaunch();
                                break;

                            case 2:
                                exitLoseMenu = true;
                                //MainMenu();
                                break;

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
