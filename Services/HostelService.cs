
using UHB.Models;

public class HostelService
{
    public static List<Hostel> _hostels = new List<Hostel>()
    {
        new Hostel{ NO=1, Name="Batian", Capacity=50, Type="Male" },
        new Hostel{ NO=2, Name="Serengeti", Capacity=50, Type="Female" },
        new Hostel{ NO=3, Name="Mt Kenya", Capacity=50, Type="Male" },
        new Hostel{ NO=4, Name="Lenana", Capacity=50, Type="Female" }
    };
    public static List<Hostel> GetHostels() { return _hostels; }
    public static Hostel? GetHostel(int id) { return _hostels.SingleOrDefault(hostel => hostel.NO == id); }
    public static Hostel CreateHostel(Hostel hostel)
    {
        _hostels.Add(hostel);
        return hostel;
    }
    public static Hostel UpdateHostel(Hostel update)
    {
        _hostels = _hostels.Select(hostel =>
        {
            if (hostel.NO == update.NO)
            {
                hostel.Name = update.Name;
            }
            return hostel;
        }).ToList();
        return update;
    }
    //public static  Hostel RemoveHostel(int id)
    //{
    //    _hostels = _hostels.FindAll(hostel => hostel.NO == id).ToList();
    //}
}
