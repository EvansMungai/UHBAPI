using UHB.Models;

namespace UHB.Services
{
    public interface IHostelService
    {
        List<Hostel> GetHostels();
        List<Hostel?> GetHostel(string id);
    }
}
