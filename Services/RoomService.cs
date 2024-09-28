using UHB.Models;
namespace UHB.Services
{
    public class RoomService
    {
        public static List<Rooms> _rooms = new List<Rooms>()
        {
            new Rooms{ RoomNo= "B1", HostelNo= "1" },
            new Rooms{ RoomNo= "B2", HostelNo= "1" }
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
        public static Rooms? UpdateRoom(Rooms update, string id)
        {
            Rooms? room = GetRoom(id);
            if (room != null)
            {
                room.RoomNo = update.RoomNo;
                room.HostelNo = update.HostelNo;
            }
            return room;
        }
        public static Rooms? RemoveRoom(string id)
        {
            Rooms? room = GetRoom(id);
            if (room != null)
            {
                _rooms.Remove(room);
            }
            return room;
        }
    }
}
