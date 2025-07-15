using UHB.Features.HostelManagement.Models;

namespace UHB.Features.HostelManagement.Services;

public interface IRoomService
{
    Task<IResult> GetRooms();
    Task<IResult> GetRoom(string id);
    Task<IResult> CreateRoom(Room room);
    Task<IResult> UpdateRoom(Room update, string id);
    Task<IResult> RemoveRoom(string id);
}

