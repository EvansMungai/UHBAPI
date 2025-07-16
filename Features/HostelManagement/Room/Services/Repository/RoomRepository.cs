using Microsoft.EntityFrameworkCore;
using UHB.Data.Infrastructure;
using UHB.Features.HostelManagement.Models;

namespace UHB.Features.HostelManagement.Services;

public class RoomRepository : IRoomRepository
{
    private readonly UhbContext _context;
    public RoomRepository(UhbContext context)
    {
        _context = context;
    }
    public async Task CreateRoomAsync(Room room)
    {
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Room>> GetAllRoomsAsync()
    {
        return await _context.Rooms.Select(r => new Room { RoomNo = r.RoomNo, HostelNo = r.HostelNo }).ToListAsync();
    }

    public async Task<Room?> GetRoomByIdAsync(string id)
    {
        return await _context.Rooms.Select(r => new Room { RoomNo = r.RoomNo, HostelNo = r.HostelNo }).SingleOrDefaultAsync(r => r.RoomNo == id);
    }

    public async Task RemoveRoomAsync(string id)
    {
        var room = await GetRoomByIdAsync(id);
        if (room == null) return;

        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRoomDetailsAsync(Room update, string id)
    {
        var room = await GetRoomByIdAsync(id);
        if (room == null) return;

        room.RoomNo = update.RoomNo;
        room.HostelNo = update.HostelNo;

        _context.Rooms.Update(room);
        await _context.SaveChangesAsync();
    }
}
