using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices
{
    class WorkingWithFiles
    {
        string testFile = "Text01";
        string testDirectory = @"F:\Work\Programming\ProgrammingInternship\ExerciseMaterials";
        string testPath = @"F:\Work\Programming\ProgrammingInternship\ExcerciseMaterials\Text01.txt";

        string writeThis = "This line is new!";
        string readText = "";

        public void FileAndFileInfo()
        {
            using(StreamWriter outputFile = new StreamWriter(testPath, true))
            {
                outputFile.WriteLine(writeThis);
            }  

            if (File.Exists(testPath))
            {
                readText = File.ReadAllText(testPath);
                Console.WriteLine(readText);
            }
            else
                Console.WriteLine("no file found!");

        }
    }
}
