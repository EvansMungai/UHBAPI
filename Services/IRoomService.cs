using UHB.Models;

namespace UHB.Services
{
    public interface IRoomService
    {
        List<Room> GetRooms();
        List<Room> GetRoom(string id);
        Room CreateRoom(Room room);
        Room? UpdateRoom(Room update, string id);
        //Room? RemoveRoom(string id);
    }
}
