using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProgrammingInternship.GameProjects.Snake;
using ProgrammingInternship.GholizadehPractices;
using ProgrammingInternship.OtherPractices;
using ProgrammingInternship.CommonFeatures;
using ProgrammingInternship.UdemyPrectices;
using ProgrammingInternship.UdemyPrectices.Composition;
using ProgrammingInternship.UdemyPrectices.Composition.Advanced;
using ProgrammingInternship.UdemyPrectices.StackOverflowPost;
using ProgrammingInternship.UdemyPrectices.Stopwatch;
using ProgrammingInternship.UdemyPrectices.Properties;
using ProgrammingInternship.UdemyPrectices.Indexer;
using ProgrammingInternship.UdemyPrectices.Delegate;
using ProgrammingInternship.UdemyPrectices.Delegate.CarTest;
using ProgrammingInternship.UdemyPrectices.Delegate.CharacterBuild;
using ProgrammingInternship.UdemyPrectices.Delegate.SoundGenerator;
using ProgrammingInternship.UdemyPrectices.Delegate.IslamicRepublic;
using ProgrammingInternship.UdemyPrectices.Event.BoilerMaintenance;
using ProgrammingInternship.UdemyPrectices.Event.VideoEncode;
using ProgrammingInternship.UdemyPrectices.Event.RoomMaker;
using ProgrammingInternship.UdemyPrectices.Event.DSKnightClass;

namespace ProgrammingInternship
{
    class MainProgram
    {
        static int defaultProgram = 0; // set default program value to zero to launch game menu normally
        // refference types
        static string[] mainMenuButtonTexts = new string[] {"use 'Up' and 'Down' arrows to navigate",
                                                      // gholizadeh practices
                                                      "\nlaunch Number Printer Function",       // case 1
                                                      "launch While Program",                   // case 2
                                                      "launch Nested Loop",                     // case 3
                                                      "launch Prime Check",                     // case 4
                                                      "launch Elite Prime Check",               // case 5
                                                      "launch Power Function",                  // case 6
                                                      "launch Arkanoid Game",                   // case 7
                                                      "launch Snake Game",                      // case 8
                                                      "launch Grand String Printer",            // case 9
                                                      // udemy practices
                                                      "\nlaunch Enum Test",                     // case 10
                                                      "launch Reference Types and Value Types", // case 11
                                                      "launch Control Flow Exercises Part 1",   // case 12
                                                      "launch Control Flow Exercises Part 2",   // case 13
                                                      "launch Arrays and Lists Exercises",      // case 14
                                                      "launch Working with Texts",              // case 15
                                                      "launch Working with Dates",              // case 16
                                                      "launch Working with Files",              // case 17
                                                      "launch Delegate Exercises",              // case 18
                                                      "launch Event Exercises",                 // case 19
                                                      "launch Constructor Exercises",           // case 20
                                                      "launch Properties Exercise",             // case 21
                                                      "launch Indexer Exercise",                // case 22
                                                      "Launch StackOverFlow Post Exercise",     // case 23
                                                      "Launch Stopwatch Exercise",              // case 24
                                                      "Launch Composition Exercise",            // case 25
                                                      "Launch Advanced Composition",            // case 26
                                                      // other practices
                                                      "\nlaunch buffer size example",           // case 27
                                                      "Barcode Range Minigame",                 // case 28
                                                      // quit
                                                      "\nor press Esc to quit"};

        // side methods 
        void programLoader(int programState)
        {
            switch (programState)
            {
                // Gholizadeh practices
                case 1:
                    Console.Clear();
                    var numPrinter = new NumPrinter();
                    numPrinter.Printer();
                    break;

                case 2:
                    Console.Clear();
                    var whileTest = new WhileTest();
                    whileTest.WhileTester();
                    break;

                case 3:
                    Console.Clear();
                    var nestedLoop = new NestedLoop();
                    nestedLoop.NestedLoopTester();
                    break;

                case 4:
                    Console.Clear();
                    var primeCheck = new PrimeCheck();
                    primeCheck.PrimeChecker();
                    break;

                case 5:
                    Console.Clear();
                    var elitePrimeCheck = new ElitePrimeCheck();
                    elitePrimeCheck.ElitePrimeChecker();
                    break;

                case 6:
                    Console.Clear();
                    var powerNumber = new PowerNumber();
                    powerNumber.PowerNumberDealer();
                    break;

                case 7:
                    Console.Clear();
                    var arkanoidMechanic = new ArkanoidMechanic();
                    arkanoidMechanic.MainMenu();
                    break;

                case 8:
                    Console.Clear();
                    var snakeMainLoop = new SnakeMainLoop();
                    snakeMainLoop.GameLaunch();
                    break;

                case 9:
                    Console.Clear();
                    var grandStringPrinter = new GrandStringPrinter();
                    grandStringPrinter.stringPrinter();
                    break;

                // Udemy practices
                case 10:
                    Console.Clear();
                    var EnumsTest = new EnumsTest();
                    EnumsTest.enumTester();
                    Console.ReadKey();
                    break;

                case 11:
                    Console.Clear();
                    int number = 1;
                    var valueTypesAndReferenceTypes = new ValueTypesAndReferenceType();
                    valueTypesAndReferenceTypes.Increment(number);
                    Console.WriteLine(number);
                    Console.WriteLine("press 'enter' to continue");
                    Console.ReadKey();
                    valueTypesAndReferenceTypes.Age = 20;
                    valueTypesAndReferenceTypes.MakeOld(valueTypesAndReferenceTypes);
                    Console.WriteLine(valueTypesAndReferenceTypes.Age);
                    Console.WriteLine("press 'enter' to continue");
                    Console.ReadKey();
                    break;

                case 12:
                    Console.Clear();
                    var controlFlowExercisesP1 = new ControlFlowExercises();
                    controlFlowExercisesP1.ControlFlowExercisePart1();
                    break;

                case 13:
                    Console.Clear();
                    var controlFlowExercisesP2 = new ControlFlowExercises();
                    controlFlowExercisesP2.ControlFlowExercisePart2();
                    break;

                case 14:
                    Console.Clear();
                    var arraysAndListsExercises = new ArraysAndListsExercises();
                    arraysAndListsExercises.ArraysAndListExecise();
                    break;

                case 15:
                    Console.Clear();
                    var workingWithTexts = new WorkingWithTexts();
                    workingWithTexts.StringFunctions();
                    break;

                case 16:
                    Console.Clear();
                    var workingWithDates = new WorkingWithDates();
                    workingWithDates.ShowTimeAndDate();
                    break;

                case 17:
                    Console.Clear();
                    var workingWithFiles = new WorkingWithFiles();
                    workingWithFiles.FileAndFileInfo();
                    break;

                case 18:
                    Console.Clear();
                    var republicStart = new RepublicStart();
                    republicStart.StartTheRegime();
                    break;

                case 19:
                    Console.Clear();
                    var knightAttributeHandler = new KnightAttributeHandler();
                    knightAttributeHandler.BuildKnight();
                    break;

                case 20:
                    Console.Clear();
                    var constructorAndObjInitializer = new ConstructorAndObjInitializer
                    {
                        PersonName = "ali",
                        PersonAge = 10,
                        PersonHeight = 110
                    };
                    constructorAndObjInitializer.ShowPersonInfo();
                    break;

                case 21:
                    Console.Clear();
                    var personIdentifier = new PersonIdentifier();
                    personIdentifier.IntroducePerson();
                    break;

                case 22:
                    Console.Clear();
                    var cookieAccessor = new CookieAccessor();
                    cookieAccessor.AccessUser();
                    break;

                case 23:
                    Console.Clear();
                    var stackOverflowUser = new StackOverflowUser();
                    stackOverflowUser.ProgramStart();
                    break;

                case 24:
                    Console.Clear();
                    var stopwatch = new Stopwatch();
                    stopwatch.WatchFunction();
                    break;

                case 25:
                    Console.Clear();
                    var serverTest01 = new ServerTest01();
                    serverTest01.ServerSetup();
                    break;

                case 26:
                    Console.Clear();
                    var animals = new Animals();
                    animals.Specimen();
                    break;

                case 27:
                    Console.Clear();
                    var bufferSizeExample = new ConsoleBufferSizeExample();
                    bufferSizeExample.ScreenBuffer();
                    break;

                case 28:
                    Console.Clear();
                    var barcodeRangeGame = new BarcodeRangeGame();
                    barcodeRangeGame.RangeCalculator();
                    break;

                default:
                    break;
            }
        }

        // main process
        static void Main(string[] args)
        {
            if (defaultProgram != 0)
            {
                MainProgram mainProgram = new MainProgram();
                mainProgram.programLoader(defaultProgram);
                return;
            }
            int currentButton = 1; 
            while (true)
            {
                Console.Clear();

                InteractiveMenu.buttonDrawer(mainMenuButtonTexts, currentButton, ConsoleColor.Red, ConsoleColor.White);

                ConsoleKeyInfo userInput = Console.ReadKey();
                switch (userInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        currentButton = InteractiveMenu.buttonNavigator(1, mainMenuButtonTexts.Length - 2, currentButton, ConsoleKey.UpArrow);
                        break;

                    case ConsoleKey.DownArrow:
                        currentButton = InteractiveMenu.buttonNavigator(1, mainMenuButtonTexts.Length - 2, currentButton, ConsoleKey.DownArrow);
                        break;

                    case ConsoleKey.Enter:
                        MainProgram mainProgram = new MainProgram();
                        mainProgram.programLoader(currentButton);
                        break;

                    // quit console application
                    case ConsoleKey.Escape:
                        return;

                    default:
                        break;
                }
            }
        }
    }
}

