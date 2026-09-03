using UHB.Application.Dtos.Hostel;

namespace UHB.Application.Usecases.Hostels;

public interface IHostelService
{
    Task<List<HostelDto>> GetHostels();
    Task<HostelDto> GetHostel(string id);
    Task<HostelDto> CreateHostel(HostelCreateDto hostel);
    Task UpdateHostel(HostelCreateDto update, string id);
    Task RemoveHostel(string id);
}

