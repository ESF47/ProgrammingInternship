using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Event.RoomMaker
{
    class WallHandler
    {
        public void OnRoomMade(object source, EventArgs args)
        {
            Console.WriteLine("\nWall Handelr: Walls have been added to the room...");
        }
    }
}
