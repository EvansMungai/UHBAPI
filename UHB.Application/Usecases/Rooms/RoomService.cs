using UHB.Application.Dtos.Room;
using UHB.Application.Interface;
using UHB.Domain.Entities;

namespace UHB.Application.Usecases.Rooms;

public class RoomService : IRoomService
{
    private readonly IRepository<RoomDomain, string> _repo;

    public RoomService(IRepository<RoomDomain, string> repo)
    {
        _repo = repo;
    }

    public async Task<List<RoomDto>> GetRooms() => await _repo.GetAllAsync<RoomDto>();
    public async Task<RoomDto?> GetRoom(string id) => await _repo.GetSingleAsync<RoomDto>(r => r.RoomNo == id);
    public async Task<RoomDto> CreateRoom(RoomCreateDto room) => await _repo.CreateAsync<RoomDto, RoomCreateDto>(room);
    public async Task UpdateRoom(RoomCreateDto update, string id) => await _repo.UpdateAsync(update, r => r.RoomNo == id);
    public async Task RemoveRoom(string id) => await _repo.RemoveAsync(r => r.RoomNo == id);
}
