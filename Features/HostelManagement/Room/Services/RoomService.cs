using UHB.Data.Infrastructure;
using UHB.Features.HostelManagement.Room.Models;

namespace UHB.Features.HostelManagement.Room.Services
{
    public class RoomService : IRoomService
    {
        private readonly UhbContext _context;
        public RoomService(UhbContext context)
        {
            _context = context;
        }
        public async Task<IResult> GetRooms()
        {
            var rooms = _context.Rooms.Select(r => new { r.RoomNo, r.HostelNo }).ToList();
            return rooms == null || rooms.Count == 0 ? Results.NotFound("No rooms were found") : Results.Ok(rooms);
        }
        public async Task<IResult> GetRoom(string id)
        {
            var room = _context.Rooms.Select(r => new { r.RoomNo, r.HostelNo }).SingleOrDefault(r => r.RoomNo == id);
            return room == null ? Results.NotFound($"Room with id ={id} was not found") : Results.Ok(room);
        }
        public async Task<IResult> CreateRoom(Room room)
        {
            var newRoom = new Room
            {
                RoomNo = room.RoomNo,
                HostelNo = room.HostelNo,
            };
            try
            {
                _context.Rooms.Add(newRoom);
                _context.SaveChangesAsync();
            }
            catch (Exception ex) { return Results.BadRequest(ex.InnerException?.Message); }
            return Results.Ok(newRoom);
        }
        public async Task<IResult> UpdateRoom(Room update, string id)
        {
            var room = _context.Rooms.Where(r => r.RoomNo == id).Single();
            if (room != null)
            {
                room.RoomNo = update.RoomNo;
                room.HostelNo = update.HostelNo;
                try
                {
                    _context.Rooms.Update(room);
                    _context.SaveChangesAsync();
                    return Results.Ok(room);
                }
                catch (Exception ex) { return Results.BadRequest(ex.InnerException?.Message); }
            }
            else
            {
                return Results.NotFound($"Room with id ={id} was not found");
            }
        }
        public async Task<IResult> RemoveRoom(string id)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.RoomNo == id);
            if (room != null)
            {
                try
                {
                    _context.Remove(room);
                    _context.SaveChangesAsync();
                    return Results.Ok(room);
                }
                catch (Exception ex) { return Results.BadRequest(ex.InnerException?.Message); }

            }
            else
            {
                return Results.NotFound($"Room with id = {id} was not found");
            }
        }
    }
}
