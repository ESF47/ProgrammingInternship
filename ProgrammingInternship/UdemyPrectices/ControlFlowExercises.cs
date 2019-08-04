using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProgrammingInternship.CommonFeatures;

namespace ProgrammingInternship.UdemyPrectices
{
    class ControlFlowExercises
    {
        // side methods part 1
        void numberValidator()
        {
            int enteredNumber = Notifications.formatCheck("please enter a number between 1 to 10");

            if (enteredNumber >= 1 && enteredNumber <= 10)
                Console.WriteLine("Valid");
            else
                Console.WriteLine("Invalid");

            Console.WriteLine("press anykey to continue");
            Console.ReadKey();
        }
        void numberComparison()
        {
            int enteredNumber01 = Notifications.formatCheck("please enter the first number");
            int enteredNumber02 = Notifications.formatCheck("please enter the second number");

            if (enteredNumber01 > enteredNumber02)
                Console.WriteLine(enteredNumber01);
            else if (enteredNumber02 > enteredNumber01)
                Console.WriteLine(enteredNumber02);
            else
                Console.WriteLine("entered numbers are equal");

            Console.WriteLine("press anykey to continue");
            Console.ReadKey();
        }
        void aspectRatioDetector()
        {
            int imageWidth = Notifications.formatCheck("please enter the image width");
            int imageHeight = Notifications.formatCheck("please enter the image height");

            if(imageWidth > imageHeight)
                Console.WriteLine("the image is Landscape");
            else if(imageHeight > imageWidth)
                Console.WriteLine("the image is Portrait");
            else
                Console.WriteLine("the aspect ratior is square");

            Console.WriteLine("press anykey to continue");
            Console.ReadKey();
        }
        void speedCamera()
        {
            float speedLimit = Notifications.formatCheck("please enter the speed limit");
            float carSpeed = Notifications.formatCheck("please enter the car speed");

            if(carSpeed <= speedLimit)
                Console.WriteLine("car speed is OK");
            else
            {
                var demeritPoint = Math.Floor((carSpeed - speedLimit) / 5);
                if(demeritPoint <= 12)
                    Console.WriteLine("car speed is higher than speed limit with {0} demerit points", demeritPoint);
                else
                    Console.WriteLine("License Suspended");

                Console.WriteLine("press anykey to continue");
                Console.ReadKey();
            }
        }

        // side methods part 2
        void randomPasswordGenerator()
        {
            int userInput = 0;
            while (userInput <= 0 || userInput > 10)
            {
                userInput = Notifications.formatCheck("enter the length of password you want program to generate, must be less than 10 letters");
                if(userInput <= 0)
                {
                    Console.WriteLine("the password could not be less than 1 letter \npress anykey to continue");
                    Console.ReadKey();
                }
                else if(userInput > 10)
                {
                    Console.WriteLine("the password could not be longer than 10 letters \npress anykey to continue");
                    Console.ReadKey();
                }
            }
            Console.Clear();
            var random = new Random();
            char[] password = new char[userInput];
            for (int i = 0; i <= password.Length - 1; i++)
            {
                password[i] = char.Parse(char.ConvertFromUtf32(random.Next(97, 122)));
            }
            foreach (var letter in password)
            {
                Console.Write(letter);
            }
            Console.WriteLine("\nhere's your password, press anykey to continue");
            Console.ReadKey();
        }
        void divisibleBy3()
        {
            Console.Clear();
            int totalDevisibleNumbers = 0;

            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0)
                {
                    totalDevisibleNumbers++;
                    Console.WriteLine("{0} is devisible by 3", i);
                }
            }
            Console.WriteLine("total number of devisible numbers by 3 between 1 and 100 is {0}", totalDevisibleNumbers);
            Console.WriteLine("press anykey to continue");
            Console.ReadKey();
        }
        void numberSum()
        {
            Console.Clear();

            int totalSum = 0;
            string userInput = "";
            while (userInput != "ok")
            {
                Console.WriteLine("enter a number or type 'ok' to exit");
                userInput = Console.ReadLine();
                if(userInput == "ok")
                {
                    Console.WriteLine("sum of previously entered numbers are : {0}", totalSum);
                    Console.WriteLine("press anykey to continue");
                    Console.ReadKey();
                }
                else
                {
                    int number;
                    bool formatCheck = int.TryParse(userInput, out number);
                    if (formatCheck)
                        totalSum += number;
                    else
                        Notifications.wrongInputTextPrint();
                }
            }
        }
        void factorialCalculator()
        {
            int userInput = Notifications.formatCheck("enter a number to calculate the factorial");
            int factorialNumber = 1;
            for (int i = userInput; i >= 1; i--)
            {
                factorialNumber = factorialNumber * i;
            }
            Console.Clear();
            Console.WriteLine("{0}! = {1} \npress anykey to continue", userInput, factorialNumber);
            Console.ReadKey();
        }
        void numberGuess()
        {
            Console.WriteLine("program is picking a random number between 1 to 10.... \n\npress anykey to continue");
            Console.ReadKey();

            Random random = new Random();
            int randomNumber = random.Next(1, 10);
            Console.Clear();
            Console.WriteLine("the random number is : {0}, press anykey to continue", randomNumber);
            Console.ReadKey();

            int remainedChance = 4;
            for(int i = remainedChance; i >= 1; i--)
            {
                Console.Clear();
                Console.WriteLine();
                int userInput = Notifications.formatCheck("guess a number, you have " + remainedChance + " chances");
                if(userInput == randomNumber)
                {
                    Console.WriteLine("You Won! \npress anykey to continue");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("your guess was incorrect \npress anykey to continue");
                    Console.ReadKey();
                    remainedChance--;
                }
                Console.Clear();
                Console.WriteLine("You Lost! \n\npress anykey to continue");
                Console.ReadKey();
            }
        }
        void eliteNumberComparison()
        {
            Console.WriteLine("enter your numbers using comma");
            string userInput = Console.ReadLine();

            char[] characters = new char[userInput.Length];
            // adding user input characters into the characters array
            for (int i = 0; i <= characters.Length -1; i++)
            {
                characters[i] = userInput[i];
            }

            List<int> detectedNumbers = new List<int>();
            // adding numbers into the detected number list
            foreach (var character in characters)
            {
                if (Convert.ToInt32(character) >= 48 && Convert.ToInt32(character) <= 57)
                    detectedNumbers.Add(Convert.ToInt32(character) - 48);
            }

            // detecting the biggest number
            int biggestNumber = 0;
            foreach (var number in detectedNumbers)
            {
                if (number >= biggestNumber)
                    biggestNumber = number;
            }

            // printing the biggest number
            Console.WriteLine("the biggest number is {0}", biggestNumber);
        }

        // main process part 1
        public void ControlFlowExercisePart1()
        {
            numberValidator();
            numberComparison();
            aspectRatioDetector();
            speedCamera();
        }

        // main process part 2
        public void ControlFlowExercisePart2()
        {
            randomPasswordGenerator();
            eliteNumberComparison();
            numberGuess();
            factorialCalculator();
            numberSum();
            divisibleBy3();
        }
    }
}
