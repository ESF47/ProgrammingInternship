using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.GholizadehPractices
{
    class GrandStringPrinter
    {
        public void stringPrinter()
        {
            // lowercase letters
            string[] LowercaseLetters = new string[26];
            int firstLowercaseLetter = 97;
            for (int i = 0; i <= LowercaseLetters.Length - 1; i++)
            {
                LowercaseLetters[i] = char.ConvertFromUtf32(firstLowercaseLetter);
                firstLowercaseLetter++;
            }
            // uppercase letters
            string[] UppercaseLetters = new string[26];
            int firstUppercaseLetter = 65;
            for (int i = 0; i <= UppercaseLetters.Length - 1; i++)
            {
                UppercaseLetters[i] = char.ConvertFromUtf32(firstUppercaseLetter);
                firstUppercaseLetter++;
            }

            // writing all letters together
            Console.Write("string[] chars = {");
            for (int i = 0; i <= (LowercaseLetters.Length + UppercaseLetters.Length) - 1; i++)
            {
                if(i <= LowercaseLetters.Length - 1)
                {
                    Console.Write("\"");
                    Console.Write(LowercaseLetters[i]);
                    Console.Write("\"");
                    Console.Write(",");
                }
                else
                {
                    Console.Write("\"");
                    Console.Write(UppercaseLetters[i - (UppercaseLetters.Length)]);
                    Console.Write("\"");
                    if (i < (LowercaseLetters.Length + UppercaseLetters.Length) - 1)
                        Console.Write(",");
                }
            }
            Console.Write("};");

            // ->
            int min = 65;
            int max = 90;
            string str = "string[] chars2 = {";
            for (int i = min; i <= max; i++)
            {
                str += "\"" + Convert.ToChar(i) + (i == 122 ? "\"" : "\", ");
                if (i == 90)
                {
                    min = 96;max = 122;
                    i = min;
                }
            }
            str += "};";
            Console.WriteLine("here it is : \n{0}", str);
            // <-
            Console.ReadKey();
        }

        /*Dictionary<int, char> dic = new Dictionary<int, char>();
            int upperCaseLow = 65;
            int upperCaseHigh = 90;
            int lowerCaseLow = 97;
            int lowerCaseHigh = 122;
            // add upper case characters
            for (int i = upperCaseLow; i < upperCaseHigh; i++)
            {
                dic.Add(i, Convert.ToChar(i));
            }
            Console.WriteLine("");
            // add lower case characters
            for (int i = lowerCaseLow; i < lowerCaseHigh; i++)
            {
                dic.Add(i, Convert.ToChar(i));
            }

            your code here
            "string[] chars = {"a", "b", ..};"*/
    }
}
