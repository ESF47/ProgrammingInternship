using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Event.RoomMaker
{
    class FloorHandler
    {
        public void OnRoomMade(object source, EventArgs args)
        {
            Console.WriteLine("\nFloor Handler: Floor has been added to the room...");
        }
    }
}
