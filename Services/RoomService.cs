using UHB.Data;
using UHB.Models;

namespace UHB.Services
{
    public class RoomService : IRoomService
    {
        private readonly UhbContext _context;
        public RoomService(UhbContext context)
        {
            _context = context;
        }
        public  List<Room> GetRooms() { return _context.Rooms.ToList(); }
        public  List<Room> GetRoom(string id)
        {
            return _context.Rooms.Where(a => a.RoomNo == id).ToList();
        }
        //public Room CreateRoom(Room room)
        //{
        //    var newRoom = new Room
        //    {
        //        RoomNo = room.RoomNo,
        //        HostelNo = room.HostelNo,
        //    };
        //    _context.Rooms.Add(newRoom);
        //    _context.SaveChanges();
        //    return room;
        //}
        //public Room? UpdateRoom(Room update, string id)
        //{
        //    Room? room = GetRoom(id);
        //    if (room != null)
        //    {
        //        room.RoomNo = update.RoomNo;
        //        room.HostelNo = update.HostelNo;
        //    }
        //    return room;
        //}
        //public Room? RemoveRoom(string id)
        //{
        //    Room? room = GetRoom(id);
        //    if (room != null)
        //    {
        //        _rooms.Remove(room);
        //    }
        //    return room;
        //}
    }
}
