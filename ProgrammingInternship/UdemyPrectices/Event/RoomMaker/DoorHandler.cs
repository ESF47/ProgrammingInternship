using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Event.RoomMaker
{
    class DoorHandler
    {
        public void OnRoomMade(object source, EventArgs args)
        {
            Console.WriteLine("\nDoor Handler: A door has been added to the room...");
        }
    }
}
