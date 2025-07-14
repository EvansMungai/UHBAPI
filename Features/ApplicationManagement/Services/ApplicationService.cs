using UHB.Data.Infrastructure;
using UHB.Features.ApplicationManagement.Models;

namespace UHB.Features.ApplicationManagement.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly UhbContext _context;
        public ApplicationService(UhbContext context)
        {
            _context = context;
        }
        public async Task<IResult> GetApplications()
        {
            var applications = _context.Applications.ToList();
            return applications == null || applications.Count == 0 ? Results.NotFound("No applications were found") : Results.Ok(applications);
        }

        public async Task<IResult> GetApplication(int id)
        {
            var application = _context.Applications.SingleOrDefault(a => a.ApplicationNo == id);
            return application == null ? Results.NotFound($"Application with application id ={id} was not found") : Results.Ok(application);
        }
        public async Task<IResult> GetAcceptedApplications()
        {
            var applications = _context.Applications.Where(a => a.Status == "Accepted").ToList();
            return applications == null || !applications.Any() ? Results.NotFound("No Accepted applications were found.") : Results.Ok(applications);
        }
        public async Task<IResult> GetRejectedApplications()
        {
            var applications = _context.Applications.Where(a => a.Status == "Rejected").ToList();
            return applications == null || !applications.Any() ? Results.NotFound("No Accepted applications were found.") : Results.Ok(applications);
        }
        public async Task<IResult> CreateApplication(Application application)
        {
            var newApplication = new Application
            {
                ApplicationPeriod = application.ApplicationPeriod,
                RegistrationNo = application.RegistrationNo,
                PreferredHostel = application.PreferredHostel,
                Disability = application.Disability,
                DisabilityDetails = application.DisabilityDetails,
                AccommodatedBefore = application.AccommodatedBefore,
                AccommodationPeriod = application.AccommodationPeriod,
                IsSponsored = application.IsSponsored,
                Sponsor = application.Sponsor,
                ReceivesHelb = application.ReceivesHelb,
                HelbAmount = application.HelbAmount,
                ReceivedBursary = application.ReceivedBursary,
                BursaryAmount = application.BursaryAmount,
                WorkStudyBenefitsBefore = application.WorkStudyBenefitsBefore,
                WorkStudyPeriod = application.WorkStudyPeriod,
                SpecialExamsOnFinancialGrounds = application.SpecialExamsOnFinancialGrounds,
                SpecialExamPeriod = application.SpecialExamPeriod,
                ReasonsForConsideration = application.ReasonsForConsideration
            };
            try
            {
                _context.Applications.Add(newApplication);
                _context.SaveChangesAsync();
                return Results.Ok(application);
            }
            catch (Exception ex) { return Results.BadRequest(ex.InnerException.Message); }
        }
        public async Task<IResult> UpdateApplicationDetails(Application update, int id)
        {
            var application = _context.Applications.FirstOrDefault(a => a.ApplicationNo == id);
            if (application != null)
            {
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
                try
                {
                    _context.Applications.Update(application);
                    _context.SaveChangesAsync();
                    return Results.Ok(application);
                }
                catch (Exception ex) { return Results.BadRequest(ex.InnerException.Message); }
            }
            else
            {
                return Results.NotFound($"Application with application id ={id} was not found");
            }

        }
        public async Task<IResult> UpdateApplicationStatus(string status, int id)
        {
            var application = _context.Applications.FirstOrDefault(a => a.ApplicationNo == id);
            if (application != null)
            {
                try
                {
                    application.Status = status;
                    _context.Applications.Update(application);
                    _context.SaveChangesAsync();
                    return Results.Ok(application);
                }
                catch (Exception ex) { return Results.BadRequest(ex.InnerException?.Message); }
            }
            else
            {
                return Results.NotFound($"Application with application id={id} was not found");
            }

        }
        public async Task<IResult> UpdateRoomNo(string roomNo, int id)
        {
            var application = _context.Applications.FirstOrDefault(a => a.ApplicationNo == id);
            if (application != null)
            {
                try
                {
                    application.RoomNo = roomNo;
                    _context.Applications.Update(application);
                    _context.SaveChangesAsync();
                    return Results.Ok(application);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.InnerException?.Message);

                }
            }
            else { return Results.NotFound($"Application with id={id} was not found"); }
        }
        public async Task<IResult> RemoveApplication(int id)
        {
            var application = _context.Applications.FirstOrDefault(a => a.ApplicationNo == id);
            if (application != null)
            {
                try
                {
                    _context.Applications.Remove(application);
                    _context.SaveChangesAsync();
                    return Results.Ok(application);
                }
                catch (Exception ex) { return Results.BadRequest(ex.InnerException?.Message); }
            }
            else { return Results.NotFound($"Application with application id={id} was not found"); }
        }
    }
}
