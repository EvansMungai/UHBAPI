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

        public async Task<IResult> GetHostels()
        {
            var hostels = _context.Hostels.Select(s => new { s.HostelNo, s.HostelName, s.Capacity, s.Type }).ToList();
            return hostels == null || hostels.Count == 0 ? Results.NotFound("No hostels found") : Results.Ok(hostels);
        }
        public async Task<IResult> GetHostel(string id)
        {
            var hostel = _context.Hostels.Select(s => new { s.HostelNo, s.HostelName, s.Capacity, s.Type }).SingleOrDefault(s => s.HostelNo == id);
            return hostel == null ? Results.NotFound($"Hostel with id = {id} was not found") : Results.Ok(hostel);
        }
        public async Task<IResult> CreateHostel(Hostel hostel)
        {
            var newHostel = new Hostel
            {
                HostelNo = hostel.HostelNo,
                HostelName = hostel.HostelName,
                Capacity = hostel.Capacity,
                Type = hostel.Type
            };
            try
            {
                _context.Hostels.Add(newHostel);
                _context.SaveChangesAsync();
            }
            catch (Exception ex) { return Results.BadRequest(ex.InnerException?.Message); }
            return Results.Ok(newHostel);
        }
        public async Task<IResult> UpdateHostel(Hostel update, string id)
        {
            var hostel = _context.Hostels.SingleOrDefault(h => h.HostelNo == id);
            if (hostel != null)
            {
                hostel.HostelNo = update.HostelNo;
                hostel.HostelName = update.HostelName;
                hostel.Capacity = update.Capacity;
                hostel.Type = update.Type;
                try
                {
                    _context.Hostels.Update(hostel);
                    _context.SaveChanges();
                    return Results.Ok(hostel);
                }
                catch (Exception ex) { return Results.BadRequest(ex.InnerException?.Message); }
            }
            else
            {
                return Results.NotFound($"Hostel with id = {id} was not found");
            }

        }
        public async Task<IResult> RemoveHostel(string id)
        {
            var hostel = _context.Hostels.FirstOrDefault(h => h.HostelNo == id);
            if (hostel != null)
            {
                try
                {
                    _context.Remove(hostel);
                    _context.SaveChangesAsync();
                    return Results.Ok(hostel);
                }
                catch (Exception ex) { return Results.BadRequest(ex.InnerException?.Message); }
            }
            else
            {
                return Results.NotFound($"Hostel with id ={id} was not found.");
            }
        }
    }
}
