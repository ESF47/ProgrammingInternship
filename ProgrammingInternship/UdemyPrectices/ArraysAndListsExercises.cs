using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProgrammingInternship.CommonFeatures;

namespace ProgrammingInternship.UdemyPrectices
{
    class ArraysAndListsExercises
    {
        // side methods
        void FaceBookMessage()
        {
            List<string> friendNames = new List<string>();

            string userInput = "Empty";
            while (userInput != "")
            {
                Console.Clear();
                Console.WriteLine("please enter a name or just press 'enter' button to end the process");
                userInput = Console.ReadLine();
                if (userInput != "")
                    friendNames.Add(userInput);
            }
            switch (friendNames.Count)
            {
                case 0:
                    Console.WriteLine("sry, but nobody gives a shit about your post \npress anykey to continue");
                    Console.ReadKey();
                    break;
                case 1:
                    Console.WriteLine("{0} likes your post \npress anykey to continue", friendNames[0]);
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("{0} and {1} like your post \npress anykey to continue", friendNames[0], friendNames[1]);
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("{0}, {1} and {2} others like your post \npress anykey to continue", friendNames[0], friendNames[1], friendNames.Count - 2);
                    Console.ReadKey();
                    break;
            }
        }
        void NameReversal()
        {
            string userInput = "";
            while (userInput == "")
            {
                Console.Clear();
                Console.WriteLine("Please enter your name in order to reverse it");
                userInput = Console.ReadLine();
                if (userInput != "")
                {
                    Console.Clear();
                    char[] reversedName = new char[userInput.Length];
                    int currentCharacter = reversedName.Length - 1;
                    foreach (var character in userInput)
                    {
                        reversedName[currentCharacter] = character;
                        currentCharacter--;
                    }
                    Console.Write("Here's your reversed name : ");
                    foreach (var character in reversedName)
                    {
                        Console.Write(character);
                    }
                    Console.WriteLine("\npress anykey to continue");
                    Console.ReadKey();
                }

            }
        }
        void NumberSorter()
        {
            Console.Clear();
            Console.WriteLine("please enter 5 numbers with space between them, also don't input duplicated numbers");

            int lastIndexOfSpaceChar;
            int searchStart = 0;
            List<char> firstNumber = new List<char>();
            List<char> secondNumber = new List<char>();
            List<char> thirdNumber = new List<char>();
            List<char> forthNumber = new List<char>();
            List<char> fifthNumber = new List<char>();
            int currentNumbertoDetect = 1;

            string userInput = "";
            while (userInput == "")
            {
                userInput = Console.ReadLine();
                for (int i = searchStart; i <= userInput.Length - 1; i++)
                {
                    // check if the character is space
                    if(Convert.ToInt32(userInput[i]) == 32)
                    {
                        lastIndexOfSpaceChar = userInput.IndexOf(userInput[i]);
                        searchStart = lastIndexOfSpaceChar;
                        switch (currentNumbertoDetect)
                        {
                            case 1:
                                if (firstNumber.Count > 0)
                                    currentNumbertoDetect++;
                                break;
                            case 2:
                                if (secondNumber.Count > 0)
                                    currentNumbertoDetect++;
                                break;
                            case 3:
                                if (thirdNumber.Count > 0)
                                    currentNumbertoDetect++;
                                break;
                            case 4:
                                if (forthNumber.Count > 0)
                                    currentNumbertoDetect++;
                                break;
                            case 5:
                                if (fifthNumber.Count > 0)
                                    currentNumbertoDetect++;
                                break;
                            default:
                                break;
                        }
                    }
                    // check if the character is number
                    else if(Convert.ToInt32(userInput[i]) >= 48 && Convert.ToInt32(userInput[i]) <= 57)
                    {
                        switch (currentNumbertoDetect)
                        {
                            case 1:
                                firstNumber.Add(userInput[i]);
                                break;
                            case 2:
                                secondNumber.Add(userInput[i]);
                                break;
                            case 3:
                                thirdNumber.Add(userInput[i]);
                                break;
                            case 4:
                                forthNumber.Add(userInput[i]);
                                break;
                            case 5:
                                fifthNumber.Add(userInput[i]);
                                break;
                            default:
                                break;
                        }
                    }
                    // if the character is not space neither number
                    else
                    {
                        Console.WriteLine("the {0} character is not covered", userInput[i]);
                        Console.ReadKey();
                    }
                }
            }
            // converting detected numbers to integers
            string number1 = "";
            for (int i = 0; i <= firstNumber.Count - 1; i++)
            {
                number1 += firstNumber[i];
            }
            int convertedNum1 = int.Parse(number1);

            string number2 = "";
            for (int i = 0; i <= secondNumber.Count - 1; i++)
            {
                number2 += secondNumber[i];
            }
            int convertedNum2 = int.Parse(number2);

            string number3 = "";
            for (int i = 0; i <= thirdNumber.Count - 1; i++)
            {
                number3 += thirdNumber[i];
            }
            int convertedNum3 = int.Parse(number3);

            string number4 = "";
            for (int i = 0; i <= forthNumber.Count - 1; i++)
            {
                number4 += forthNumber[i];
            }
            int convertedNum4 = int.Parse(number4);

            string number5 = "";
            for (int i = 0; i <= fifthNumber.Count - 1; i++)
            {
                number5 += fifthNumber[i];
            }
            int convertedNum5 = int.Parse(number5);

            // sorting numbers
            int[] numbers = new int[] { convertedNum1, convertedNum2, convertedNum3, convertedNum4, convertedNum5 };
            Array.Sort(numbers);
            string sortedNumbers = "";
            foreach (var number in numbers)
            {
                sortedNumbers += number + " , ";
            }

            // checking if there's any duplicated number or not
            for (int i = 0; i <= numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    if (i == j)
                        continue;
                    else
                    {
                        if(numbers[i] == numbers[j])
                        {
                            Console.WriteLine("The {0} is duplicated, please try again", numbers[i]);
                            Console.ReadKey();
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(sortedNumbers);
            Console.ReadKey();
        }
        void UniqueNumberDetector()
        {
            List<int> numberInputs = new List<int>();

            string userInput = "";
            while (userInput != "quit")
            {
                Console.Clear();
                Console.WriteLine("enter a number or type \"quit\" to exit the program");
                userInput = Console.ReadLine();
                int number;
                bool formatCheck = int.TryParse(userInput, out number);
                if (!formatCheck)
                {
                    if (userInput == "quit")
                        continue;
                    else
                    {
                        Console.WriteLine("your input was invalid, make sure to enter a number, press any key to continue");
                        Console.ReadKey();
                    }
                }
                else
                    numberInputs.Add(number);
            }
            string uniqueNumbers = "unique numbers are : ";
            for (int i = 0; i <= numberInputs.Count - 1; i++)
            {
                for (int j = 0; j <= numberInputs.Count - 1; j++)
                {
                    if (j == i)
                        continue;

                    if (numberInputs[i] == numberInputs[j])
                        numberInputs.Remove(numberInputs[j]);
                }
                uniqueNumbers += numberInputs[i] + " , ";
            }
            Console.WriteLine(uniqueNumbers);
            Console.ReadKey();
        }
        void ThreeSmalletNumbers()
        {
            Console.WriteLine("enter atleast 5 numbers in comma spearated format or any other format you want");
            string userInput = Console.ReadLine();

            int numberOfInvalidCharacters = 0;
            string finalStringToPrint = "Detected numbers are : ";
            string threeSmallestNumbers = "Three smallest numbers are : ";

            List<string> listOfNumbers = new List<string>();
            // current index represnts the index of list of numbers which we are going to add to
            int currentIndex = 0;
            int lastIndexOfSpaceOrComma = 0;
            for (int i = lastIndexOfSpaceOrComma; i <= userInput.Length - 1; i++)
            {
                // check if the character is space(32) or comma(44)
                if (Convert.ToInt32(userInput[i]) == 32 || Convert.ToInt32(userInput[i]) == 44)
                {
                    if (listOfNumbers.Count == 0)
                        listOfNumbers.Add("");

                    if (listOfNumbers[currentIndex] != "")
                    {
                        listOfNumbers.Add("");
                        currentIndex++;
                        lastIndexOfSpaceOrComma = i;
                    }
                    else
                        lastIndexOfSpaceOrComma = i;
                }
                else if(Convert.ToInt32(userInput[i]) >= 48 && Convert.ToInt32(userInput[i]) <= 57)
                {
                    if (listOfNumbers.Count == 0)
                        listOfNumbers.Add("");
                    listOfNumbers[currentIndex] += userInput[i];
                }
                else
                    numberOfInvalidCharacters++;
            }
            foreach (string number in listOfNumbers)
            {
                finalStringToPrint += (listOfNumbers.IndexOf(number) == listOfNumbers.Count - 1) ? number : number + ", ";
            }

            Console.Clear();
            if (numberOfInvalidCharacters > 0)
                Console.WriteLine("Number of invalid characters was : {0}", numberOfInvalidCharacters);

            if (listOfNumbers.Count > 0)
            {
                Console.WriteLine("Number of items in the list : {0}", listOfNumbers.Count);
                Console.WriteLine(finalStringToPrint);
                // detecting and printing 3 smallest numbers in the list of numbers
                int j = 0;
                while (j < 3)
                {
                    if(listOfNumbers.Count >= 1)
                    {
                        int min = Convert.ToInt32(listOfNumbers[0]);
                        foreach (string number in listOfNumbers)
                        {
                            if (Convert.ToInt32(number) < min)
                                min = Convert.ToInt32(number);
                        }
                        threeSmallestNumbers += min + ", ";
                        listOfNumbers.Remove(Convert.ToString(min));
                    }
                    j++;
                }
                Console.WriteLine(threeSmallestNumbers);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("There was no mumber detected");
                Console.ReadKey();
            }
        }

        // main process
        public void ArraysAndListExecise()
        {
            ThreeSmalletNumbers();
            UniqueNumberDetector();
            NumberSorter();
            NameReversal();
            FaceBookMessage();
        }
    }
}
