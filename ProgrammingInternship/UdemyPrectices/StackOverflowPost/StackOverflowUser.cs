using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProgrammingInternship.CommonFeatures;

namespace ProgrammingInternship.UdemyPrectices.StackOverflowPost
{
    class StackOverflowUser
    {
        List<StackOverflowPost> posts = new List<StackOverflowPost>();

        public void ProgramStart()
        {
            while (true)
            {
                Console.Clear();

                // when there are still no posts 
                while (posts.Count == 0)
                {
                    Console.WriteLine("There are no posts created yet, press Spacebar to create one!");

                    ConsoleKeyInfo userInput = Console.ReadKey();
                    switch (userInput.Key)
                    {
                        case ConsoleKey.Spacebar:
                            CreatePost();
                            break;

                        default:
                            break;
                    }
                }
                //if there is atleast one post created
                int currentButton = 1;
                while (posts.Count > 0)
                {
                    Console.ResetColor();
                    Console.Clear();

                    string[] buttonTexts = new string[posts.Count + 1];
                    for (int i = 0; i < buttonTexts.Length; i++)
                    {
                        if(i > 0)
                            buttonTexts[i] = posts[i - 1].PostName;
                        else
                            buttonTexts[i] = "Select a post and press enter to see details. Press Spacebar to create a new post!\n";
                    }

                    InteractiveMenu.buttonDrawer(buttonTexts, currentButton, ConsoleColor.Red, ConsoleColor.White);

                    ConsoleKeyInfo userInput = Console.ReadKey();
                    switch (userInput.Key)
                    {
                        case ConsoleKey.UpArrow:
                            currentButton = InteractiveMenu.buttonNavigator(1, buttonTexts.Length - 1, currentButton, ConsoleKey.UpArrow);
                            break;

                        case ConsoleKey.DownArrow:
                            currentButton = InteractiveMenu.buttonNavigator(1, buttonTexts.Length - 1, currentButton, ConsoleKey.DownArrow);
                            break;

                        case ConsoleKey.Enter:
                            PostDetail(currentButton - 1);
                            break;

                        case ConsoleKey.Spacebar:
                            CreatePost();
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        public void CreatePost()
        {
            Console.ResetColor();

            Console.Clear();
            Console.WriteLine("Please enter the title of the post and press Enter: ");
            var postName = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Please enter the description of the post and press Enter: ");
            var postDescription = Console.ReadLine();

            posts.Add(new StackOverflowPost(postName, postDescription, DateTime.Now));
        }

        public void PostDetail(int postIndex)
        {
            while (true)
            {
                Console.ResetColor();
                Console.Clear();
                string output = String.Format("Press Up Arrow to upvote, Down Arrow to downvote or press Enter to return to previous page: " +
                                              "\n\nPost Name: {0} " +
                                              "\nPost Description: {1}" +
                                              "\nPost Date: {2}" +
                                              "\nPost Vote: {3}\n"
                                              , posts[postIndex].PostName, posts[postIndex].PostDescription, posts[postIndex].CreationTime, posts[postIndex].VotesCount);

                Console.WriteLine(output);
                ConsoleKeyInfo userInput = Console.ReadKey();
                switch (userInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        posts[postIndex].UpVote();
                        break;

                    case ConsoleKey.DownArrow:
                        posts[postIndex].DownVote();
                        break;

                    case ConsoleKey.Enter:
                        return;

                    default:
                        break;
                }
            }
        }

        //private void CreatPost(string name, string description)
        //{
        //    posts.Add(new StackOverflowPost(name, description, DateTime.Today));
        //}

        //private void VoteCast(int postIndex, int upVoteNum, int downBoteNum)
        //{
        //    for (int i = 0; i < upVoteNum; i++)
        //    {
        //        posts[postIndex].UpVote();
        //    }
        //    for (int i = 0; i < downBoteNum; i++)
        //    {
        //        posts[postIndex].DownVote();
        //    }
        //}

        //private string PostInfo(int postIndex)
        //{
        //    string output = String.Format("Post Name: {0} " +
        //                                  "\nPost Description: {1}" +
        //                                  "\nPost Date: {2}" +
        //                                  "\nPost Vote: {3}\n"
        //                                  , posts[postIndex].PostName, posts[postIndex].PostDescription, posts[postIndex].CreationTime, posts[postIndex].VotesCount);

        //    return output;
        //}

        //public void ProgramStart()
        //{
        //    CreatPost("Graves", "ADC/Jungle");
        //    CreatPost("Darius", "Top");
        //    CreatPost("Pyke", "Support/Jungle/Top");

        //    VoteCast(0, 10, 3);
        //    VoteCast(1, 55, 63);
        //    VoteCast(2, 3, 3);

        //    Console.WriteLine(PostInfo(0));
        //    Console.WriteLine(PostInfo(1));
        //    Console.WriteLine(PostInfo(2));
        //}
    }
}
