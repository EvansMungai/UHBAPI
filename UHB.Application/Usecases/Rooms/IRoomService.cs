using UHB.Application.Dtos.Room;

namespace UHB.Application.Usecases.Rooms;

public interface IRoomService
{
    Task<List<RoomDto>> GetRooms();
    Task<RoomDto> GetRoom(string id);
    Task<RoomDto> CreateRoom(RoomCreateDto room);
    Task UpdateRoom(RoomCreateDto update, string id);
    Task RemoveRoom(string id);
}

