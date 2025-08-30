using Microsoft.EntityFrameworkCore;
using UHB.Data.Infrastructure;
using UHB.Features.ApplicationManagement.Models;

namespace UHB.Features.ApplicationManagement.Services;

public class ApplicationRepository : IApplicationRepository
{
    private readonly UhbContext _context;
    public ApplicationRepository(UhbContext context)
    {
        _context = context;
    }
    public async Task AssignRoomToApplicant(string roomNo, int id)
    {
        var application = await _context.Applications.SingleOrDefaultAsync(a => a.ApplicationNo == id);
        if (application == null) return;

        application.RoomNo = roomNo;
        _context.Applications.Update(application);
        await _context.SaveChangesAsync();
    }

    public async Task CreateApplicationAsync(Application application)
    {
        _context.Applications.Add(application);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Application>> GetAcceptedApplicationsAsync()
    {
        return await _context.Applications.Where(a => a.Status == "Accepted").ToListAsync();
    }

    public async Task<List<Application>> GetAllApplicationsAsync()
    {
        return await _context.Applications.ToListAsync();
    }
    public async Task<List<Application>> GetAssignedApplicationsAsync()
    {
        return await _context.Applications.Where(a => a.RoomNo != null).ToListAsync();
    }

    public async Task<Application?> GetApplicationByIdAsync(int id)
    {
        return await _context.Applications.SingleOrDefaultAsync(a => a.ApplicationNo == id);
    }

    public async Task<List<Application>> GetRejectedApplicationsAsync()
    {
        return await _context.Applications.Where(a => a.Status == "Rejected").ToListAsync();
    }

    public async Task RemoveApplicationAsync(int id)
    {
        var application = await _context.Applications.SingleOrDefaultAsync(a => a.ApplicationNo == id);
        if (application == null) return;

        _context.Applications.Remove(application);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateApplicationDetailsAsync(Application update, int id)
    {
        var application = await _context.Applications.SingleOrDefaultAsync(a => a.ApplicationNo == id);
        if (application == null) return;

        application.RegistrationNo = update.RegistrationNo;
        application.PreferredHostel = update.PreferredHostel;
        application.Disability = update.Disability;
        application.DisabilityDetails = update.DisabilityDetails;
        application.AccommodatedBefore = update.AccommodatedBefore;
        application.AccommodationPeriod = update.AccommodationPeriod;
        application.IsSponsored = update.IsSponsored;
        application.Sponsor = update.Sponsor;
        application.ReceivesHelb = update.ReceivesHelb;
        application.HelbAmount = update.HelbAmount;
        application.ReceivedBursary = update.ReceivedBursary;
        application.BursaryAmount = update.BursaryAmount;
        application.WorkStudyBenefitsBefore = update.WorkStudyBenefitsBefore;
        application.WorkStudyPeriod = update.WorkStudyPeriod;
        application.SpecialExamsOnFinancialGrounds = update.SpecialExamsOnFinancialGrounds;
        application.SpecialExamPeriod = update.SpecialExamPeriod;
        application.ReasonsForConsideration = update.ReasonsForConsideration;

        _context.Applications.Update(application);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateApplicationStatusAsync(string status, string preferredHostel, int id)
    {
        var application = await _context.Applications.SingleOrDefaultAsync(a => a.ApplicationNo == id);
        if (application == null) return;

        application.Status = status;
        application.PreferredHostel = preferredHostel;
        _context.Applications.Update(application);
        await _context.SaveChangesAsync();
    }
}
