using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UHB.Data;
using UHB.Models;

namespace UHB.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly UhbContext _context;
        public ApplicationService(UhbContext context)
        {
            _context = context;
        }
        public List<Application> GetApplications()
        {
            var applications = _context.Applications.ToList();
            return applications;
        }

        public List<Application> GetApplication(int id)
        {
            return _context.Applications.Where(a => a.ApplicationNo == id).ToList();
        }
        public Application CreateApplication(Application application)
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
            _context.Applications.Add(newApplication);
            _context.SaveChangesAsync();
            return application;
        }
        public Application? UpdateApplicationDetails(Application update, int id)
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
                _context.Update(application);
                _context.SaveChanges();
            }
            return application;
        }
        public Application? UpdateApplicationStatus(string status, int id)
        {
            var application = _context.Applications.FirstOrDefault(a => a.ApplicationNo == id);
            if (application != null)
            {
                application.Status = status;
                _context.Update(application);
                _context.SaveChanges();
            }
            return application;
        }
        public Application? UpdateRoomNo(string roomNo, int id)
        {
            var application = _context.Applications.FirstOrDefault(a => a.ApplicationNo == id);
            if (application != null)
            {
                application.RoomNo = roomNo;
                _context.Update(application);
                _context.SaveChanges();
            }
            return application;
        }
        public Application? RemoveApplication(int id)
        {
            var application = _context.Applications.FirstOrDefault(a => a.ApplicationNo == id);
            if (application != null)
            {
                _context.Remove(application);
                _context.SaveChanges();
            }
            return application;
        }
    }
}
