using UHB.Models;
namespace UHB.Services
{
    public class RoomService
    {
        public static List<Rooms> _rooms = new List<Rooms>()
        {
            new Rooms{ RoomNo= "1", HostelNo= "1" },
            new Rooms{ RoomNo= "2", HostelNo= "1" }
        };
        public static List<Rooms> GetRooms() { return _rooms; }
        public static Rooms? GetRoom(string id)
        {
            return _rooms.SingleOrDefault(room => room.RoomNo == id);
        }
        public static Rooms CreateRoom(Rooms room)
        {
            _rooms.Add(room);
            return room;
        }
        public static Rooms UpdateRoom(Rooms update, string id)
        {
            _rooms = _rooms.Select(room => {
                if (room.RoomNo == id)
                {
                    room.HostelNo = update.HostelNo;
                } return room;
            }).ToList();
            return update;
        }
        public static Rooms RemoveRoom(string id)
        {
            var roomToRemove = _rooms.SingleOrDefault(r =>  r.RoomNo == id);
            if (roomToRemove != null) _rooms.Remove(roomToRemove);
            return roomToRemove;
        }
    }
}
