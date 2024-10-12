﻿using UHB.Data;
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

        //    public static List<Hostel> _hostels = new List<Hostel>()
        //{
        //    new Hostel{ NO=1, Name="Batian", Capacity=50, Type="Male" },
        //    new Hostel{ NO=2, Name="Serengeti", Capacity=50, Type="Female" },
        //    new Hostel{ NO=3, Name="Mt Kenya", Capacity=50, Type="Male" },
        //    new Hostel{ NO=4, Name="Lenana", Capacity=50, Type="Female" }
        //};
        public List<Hostel> GetHostels() { return _context.Hostels.ToList(); }
        public Hostel? GetHostel(string id) { return _context.Hostels.SingleOrDefault(h => h.HostelNo == id); }
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
