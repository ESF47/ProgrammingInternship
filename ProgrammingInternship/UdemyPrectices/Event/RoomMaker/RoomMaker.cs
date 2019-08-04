using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Event.RoomMaker
{
    class RoomMaker
    {
        //1. Decalare a delegate
        //2. Decalare an event based on the delegate
        //3 .Raise the event

        //declare the delegate
        public delegate void RoomMadeEventHandler(object source, EventArgs args);
        //decalre the event
        public event RoomMadeEventHandler RoomMade;

        public void MakeTheRoom()
        {
            Console.WriteLine("Instantiating a room...");
            Thread.Sleep(1500);

            OnRoomMade();
            Console.WriteLine("\nWrapping up the room, please wait...");
            Thread.Sleep(3000);

            Console.WriteLine("\nThe process is finished");
        }

        protected virtual void OnRoomMade()
        {
            if(RoomMade != null)
            {
                RoomMade(this, EventArgs.Empty);
            }
        }
    }
}
