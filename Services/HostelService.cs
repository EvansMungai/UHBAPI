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
        public List<Hostel> GetHostel(string id) { return _context.Hostels.Where(h => h.HostelNo == id).ToList(); }
        public Hostel CreateHostel(Hostel hostel)
        {
            var newHostel = new Hostel
            {
                HostelNo = hostel.HostelNo,
                HostelName = hostel.HostelName,
                Capacity = hostel.Capacity,
                Type = hostel.Type
            };
            _context.Hostels.Add(newHostel);
            _context.SaveChanges();
            return hostel;
        }
        public Hostel? UpdateHostel(Hostel update, string id)
        {
            var hostel = _context.Hostels.Where(h => h.HostelNo == id).Single();
            if (hostel != null)
            {
                hostel.HostelNo = update.HostelNo;
                hostel.HostelName = update.HostelName;
                hostel.Capacity = update.Capacity;
                hostel.Type = update.Type;
                _context.Update(hostel);
                _context.SaveChanges();
            }
            return hostel;
        }
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
