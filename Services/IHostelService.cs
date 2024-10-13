using UHB.Models;

namespace UHB.Services
{
    public interface IHostelService
    {
        List<Hostel> GetHostels();
        List<Hostel> GetHostel(string id);
        Hostel CreateHostel(Hostel hostel);
        Hostel? UpdateHostel(Hostel update, string id);
        Hostel? RemoveHostel(string id);
    }
}
