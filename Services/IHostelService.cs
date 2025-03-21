using UHB.Models;

namespace UHB.Services
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
