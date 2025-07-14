using UHB.Features.HostelManagement.Hostel.Models;

namespace UHB.Features.HostelManagement.Hostel.Services
{
    public interface IHostelService
    {
        Task<IResult> GetHostels();
        Task<IResult> GetHostel(string id);
        Task<IResult> CreateHostel(Hostel hostel);
        Task<IResult> UpdateHostel(Hostel update, string id);
        Task<IResult> RemoveHostel(string id);
    }
}
