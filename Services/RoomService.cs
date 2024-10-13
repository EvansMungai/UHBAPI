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
        public Room CreateRoom(Room room)
        {
            var newRoom = new Room
            {
                RoomNo = room.RoomNo,
                HostelNo = room.HostelNo,
            };
            _context.Rooms.Add(newRoom);
            _context.SaveChanges();
            return room;
        }
        public Room? UpdateRoom(Room update, string id)
        {
            var room = _context.Rooms.Where(r => r.RoomNo == id).Single();
            if (room != null)
            {
                room.RoomNo = update.RoomNo;
                room.HostelNo = update.HostelNo;
                _context.Update(room);
                _context.SaveChanges();
            }
            return room;
        }
        public Room? RemoveRoom(string id)
        {
            var room =_context.Rooms.FirstOrDefault(r => r.RoomNo == id);
            if (room != null)
            {
                _context.Remove(room);
                _context.SaveChanges();
            }
            return room;
        }
    }
}
