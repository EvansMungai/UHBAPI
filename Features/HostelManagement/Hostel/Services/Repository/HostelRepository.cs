using Microsoft.EntityFrameworkCore;
using UHB.Data.Infrastructure;
using UHB.Features.HostelManagement.Models;

namespace UHB.Features.HostelManagement.Services;

public class HostelRepository : IHostelRepository
{
    private readonly UhbContext _context;
    public HostelRepository(UhbContext context)
    {
        _context = context;
    }

    public async Task CreateHostelAsync(Hostel hostel)
    {
        _context.Hostels.Add(hostel);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Hostel>> GetAllHostelsAsync()
    {
        return await _context.Hostels.Select(s => new Hostel { HostelNo = s.HostelNo, HostelName = s.HostelName, Capacity = s.Capacity, Type = s.Type }).ToListAsync();
    }

    public async Task<Hostel?> GetHostelByIdAsync(string id)
    {
        return await _context.Hostels.Select(s => new Hostel { HostelNo = s.HostelNo, HostelName = s.HostelName, Capacity = s.Capacity, Type = s.Type }).SingleOrDefaultAsync(s => s.HostelNo == id);
    }

    public async Task RemoveHostelAsync(string id)
    {
        var hostel = await _context.Hostels.SingleOrDefaultAsync(h => h.HostelNo == id);
        if (hostel == null) return;

        _context.Hostels.Remove(hostel);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateHostelAsync(Hostel update, string id)
    {
        var hostel = await GetHostelByIdAsync(id);
        if (hostel == null) return;

        hostel.HostelNo = update.HostelNo;
        hostel.HostelName = update.HostelName;
        hostel.Capacity = update.Capacity;
        hostel.Type = update.Type;

        _context.Hostels.Update(hostel);
        await _context.SaveChangesAsync();
    }
}
