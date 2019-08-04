using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Event.RoomMaker
{
    class RoofHandler
    {
        public void OnRoomMade(object source, EventArgs args)
        {
            Console.WriteLine("\nRoof Handler: Roof has been added to the room...");
        }
    }
}
