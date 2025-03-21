using UHB.Models;

namespace UHB.Services
{
    public interface IRoomService
    {
        Task<IResult> GetRooms();
        Task<IResult> GetRoom(string id);
        Task<IResult> CreateRoom(Room room);
        Task<IResult> UpdateRoom(Room update, string id);
        Task<IResult> RemoveRoom(string id);
    }
}
