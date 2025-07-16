using UHB.Features.HostelManagement.Models;

namespace UHB.Features.HostelManagement.Services;

public interface IRoomRepository
{
    Task<List<Room>> GetAllRoomsAsync();
    Task<Room?> GetRoomByIdAsync(string id);
    Task CreateRoomAsync(Room room);
    Task UpdateRoomDetailsAsync(Room update, string id);
    Task RemoveRoomAsync(string id);
}
