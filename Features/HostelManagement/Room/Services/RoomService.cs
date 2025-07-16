using UHB.Features.HostelManagement.Models;

namespace UHB.Features.HostelManagement.Services;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _repo;
    public RoomService(IRoomRepository repo)
    {
        _repo = repo;
    }
    public async Task<IResult> GetRooms()
    {
        var rooms = await _repo.GetAllRoomsAsync();
        return rooms == null || rooms.Count == 0 ? Results.NotFound("No rooms were found") : Results.Ok(rooms);
    }
    public async Task<IResult> GetRoom(string id)
    {
        var room = await _repo.GetRoomByIdAsync(id);
        return room == null ? Results.NotFound($"Room with id ={id} was not found") : Results.Ok(room);
    }
    public async Task<IResult> CreateRoom(Room room)
    {
        var existingRooms = await _repo.GetRoomByIdAsync(room.RoomNo);
        if (existingRooms != null)
            return Results.BadRequest($"Room with Room No = {room.RoomNo} exists.");

        var newRoom = new Room
        {
            RoomNo = room.RoomNo,
            HostelNo = room.HostelNo,
        };
        try
        {
            await _repo.CreateRoomAsync(newRoom);
        }
        catch (Exception ex) { return Results.BadRequest(ex.InnerException?.Message ?? ex.Message); }
        return Results.Ok(newRoom);
    }
    public async Task<IResult> UpdateRoom(Room update, string id)
    {
        var room = await _repo.GetRoomByIdAsync(id);
        if (room == null)
            return Results.NotFound($"Room with id ={id} was not found");

        try
        {
            await _repo.UpdateRoomDetailsAsync(update, id);
            return Results.Ok(room);
        }
        catch (Exception ex) { return Results.BadRequest(ex.InnerException?.Message ?? ex.Message); }
    }
    public async Task<IResult> RemoveRoom(string id)
    {
        var room = await _repo.GetRoomByIdAsync(id);
        if (room == null)
            return Results.NotFound($"Room with id ={id} was not found");

        try
        {
            await _repo.RemoveRoomAsync(id);
            return Results.Ok(room);
        }
        catch (Exception ex) { return Results.BadRequest(ex.InnerException?.Message ?? ex.Message); }
    }
}
