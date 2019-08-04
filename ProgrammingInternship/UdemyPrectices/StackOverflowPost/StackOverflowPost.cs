using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.StackOverflowPost
{
    class StackOverflowPost
    {
        public string PostName { get; }
        public string PostDescription { get; }
        public DateTime CreationTime { get; }
        public int VotesCount { get; private set; }

        public StackOverflowPost(string postNameame, string postDesc, DateTime postTime)
        {
            PostName = postNameame;
            PostDescription = postDesc;
            CreationTime = postTime;
            VotesCount = 0;
        }

        public void UpVote()
        {
            VotesCount++;
        }

        public void DownVote()
        {
            VotesCount--;
        }
    }
}
