using Microsoft.EntityFrameworkCore;
using UHB.Data;
using UHB.uhb;

namespace UHB.Services
{
    public class TrialService
    {
        private readonly UhbContext _context;
        public TrialService(UhbContext context)
        {
            _context = context;
        }
        public async ValueTask<IEnumerable<Hostel>> GetHostelsAsync()
        {
            var people = await _context.Hostels.ToListAsync();
            return people;
        }
    }
}
