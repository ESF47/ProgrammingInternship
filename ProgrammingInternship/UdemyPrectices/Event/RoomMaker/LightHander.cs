using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Event.RoomMaker
{
    class LightHander
    {
        public void OnRoomMade(object source, EventArgs args)
        {
            Console.WriteLine("\nLight Handler: A lamp has been added to the room...");
        }
    }
}
