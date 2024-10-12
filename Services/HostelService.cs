using UHB.Data;
using UHB.Models;

namespace UHB.Services
{
    public class HostelService : IHostelService
    {
        private readonly UhbContext _context;
        public HostelService(UhbContext context)
        {
            _context = context;
        }

        public List<Hostel> GetHostels() { return _context.Hostels.ToList(); }
        public List<Hostel?> GetHostel(string id) { return _context.Hostels.Where(h => h.HostelNo == id).ToList(); }
        //public static Hostel CreateHostel(Hostel hostel)
        //{
        //    _hostels.Add(hostel);
        //    return hostel;
        //}
        //public static Hostel? UpdateHostel(Hostel update, int id)
        //{
        //    Hostel? hostel = GetHostel(id);
        //    if (hostel != null)
        //    {
        //        hostel.NO = update.NO;
        //        hostel.Name = update.Name;
        //        hostel.Capacity = update.Capacity;
        //        hostel.Type = update.Type;
        //    }
        //    return hostel;
        //}
        //public static Hostel? RemoveHostel(int id)
        //{
        //    Hostel? hostel = GetHostel(id);
        //    if (hostel != null)
        //    {
        //        _hostels.Remove(hostel);
        //    }
        //    return hostel;
        //}
    }
}
