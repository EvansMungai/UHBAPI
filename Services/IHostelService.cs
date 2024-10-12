using UHB.Models;

namespace UHB.Services
{
    public interface IHostelService
    {
        List<Hostel> GetHostels();
        Hostel? GetHostel(string id);
    }
}
