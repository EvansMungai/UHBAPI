using UHB.Application.Dtos.Hostel;
using UHB.Application.Interface;
using UHB.Domain.Entities;

namespace UHB.Application.Usecases.Hostels;

public class HostelService : IHostelService
{
    private readonly IRepository<HostelDomain, string> _repo;

    public HostelService(IRepository<HostelDomain, string> repo)
    {
        _repo = repo;
    }

    public async Task<List<HostelDto>> GetHostels() => await _repo.GetAllAsync<HostelDto>();
    public async Task<HostelDto?> GetHostel(string id) => await _repo.GetSingleAsync<HostelDto>(h => h.HostelNo == id);  
    public async Task<HostelDto> CreateHostel(HostelCreateDto hostel) => await _repo.CreateAsync<HostelDto, HostelCreateDto>(hostel);
    public async Task UpdateHostel(HostelCreateDto update, string id) => await _repo.UpdateAsync(update, h => h.HostelNo == id);
    public async Task RemoveHostel(string id) => await _repo.RemoveAsync(h => h.HostelNo == id);
}
