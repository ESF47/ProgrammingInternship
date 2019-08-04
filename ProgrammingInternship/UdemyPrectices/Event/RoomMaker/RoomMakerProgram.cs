using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Event.RoomMaker
{
    class RoomMakerProgram
    {
        RoomMaker _roomMaker = new RoomMaker();

        FloorHandler _floorHandler = new FloorHandler();
        WallHandler _wallHandler = new WallHandler();
        RoofHandler _roofHandler = new RoofHandler();
        DoorHandler _doorHandler = new DoorHandler();
        LightHander _lightHandler = new LightHander();

        public void ConstructionProcess()
        {
            _roomMaker.RoomMade += _floorHandler.OnRoomMade;
            _roomMaker.RoomMade += _wallHandler.OnRoomMade;
            _roomMaker.RoomMade += _roofHandler.OnRoomMade;
            _roomMaker.RoomMade += _doorHandler.OnRoomMade;
            _roomMaker.RoomMade += _lightHandler.OnRoomMade;

            _roomMaker.MakeTheRoom();
        }
    }
}
