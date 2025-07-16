using UHB.Features.HostelManagement.Models;

namespace UHB.Features.HostelManagement.Services;

public interface IHostelRepository
{
    Task<List<Hostel>> GetAllHostelsAsync();
    Task<Hostel?> GetHostelByIdAsync(string id);
    Task CreateHostelAsync(Hostel hostel);
    Task UpdateHostelAsync(Hostel update, string id);
    Task RemoveHostelAsync(string id);
}
