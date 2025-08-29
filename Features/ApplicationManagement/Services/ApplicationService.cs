using UHB.Features.ApplicationManagement.Models;

namespace UHB.Features.ApplicationManagement.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _repo;
        public ApplicationService(IApplicationRepository repo)
        {
            _repo = repo;
        }
        public async Task<IResult> GetApplications()
        {
            var applications = await _repo.GetAllApplicationsAsync();
            return applications == null || applications.Count == 0 ? Results.NotFound("No applications were found") : Results.Ok(applications);
        }

        public async Task<IResult> GetApplication(int id)
        {
            var application = await _repo.GetApplicationByIdAsync(id);
            return application == null ? Results.NotFound($"Application with application id ={id} was not found") : Results.Ok(application);
        }
        public async Task<IResult> GetAcceptedApplications()
        {
            var applications = await _repo.GetAcceptedApplicationsAsync();
            return applications == null || !applications.Any() ? Results.NotFound("No Accepted applications were found.") : Results.Ok(applications);
        }
        public async Task<IResult> GetRejectedApplications()
        {
            var applications = await _repo.GetRejectedApplicationsAsync();
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
                await _repo.CreateApplicationAsync(newApplication);
                return Results.Ok(application);
            }
            catch (Exception ex) { return Results.BadRequest(ex.InnerException?.Message ?? ex.Message); }
        }
        public async Task<IResult> UpdateApplicationDetails(Application update, int id)
        {
            var application = await _repo.GetApplicationByIdAsync(id);
            if (application == null)
                return Results.NotFound($"Application with application id ={id} was not found");

            try
            {
                await _repo.UpdateApplicationDetailsAsync(update, id);
                return Results.Ok(application);
            }
            catch (Exception ex) { return Results.BadRequest(ex.InnerException?.Message ?? ex.Message); }
        }
        public async Task<IResult> UpdateApplicationStatus(string status, string preferredHostel, int id)
        {
            var application = await _repo.GetApplicationByIdAsync(id);
            if (application == null)
                return Results.NotFound($"Application with application id={id} was not found");

            try
            {
                await _repo.UpdateApplicationStatusAsync(status, preferredHostel, id);
                return Results.Ok(application);
            }
            catch (Exception ex) { return Results.BadRequest(ex.InnerException?.Message ?? ex.Message); }
        }
        public async Task<IResult> UpdateRoomNo(string roomNo, int id)
        {
            var application = await _repo.GetApplicationByIdAsync(id);
            if (application == null)
                return Results.NotFound($"Application with id={id} was not found");


            try
            {
                await _repo.AssignRoomToApplicant(roomNo, id);
                return Results.Ok(application);
            }
            catch (Exception ex) { return Results.BadRequest(ex.InnerException?.Message ?? ex.Message); }
        }
        public async Task<IResult> RemoveApplication(int id)
        {
            var application = await _repo.GetApplicationByIdAsync(id);
            if (application == null)
                return Results.NotFound($"Application with application id={id} was not found");

            try
            {
                await _repo.RemoveApplicationAsync(id);
                return Results.Ok(application);
            }
            catch (Exception ex) { return Results.BadRequest(ex.InnerException?.Message ?? ex.Message); }

        }
    }
}
