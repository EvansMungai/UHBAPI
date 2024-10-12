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
        //public <List<Application?> UpdateApplicationDetails(Application update, int id)
        //{
        //    var application = GetApplication(id);
        //    if (application != null)
        //    {
        //        Application.Period = update.Period;
        //        Application.RegNO = update.RegNO;
        //        Application.PHostel = update.PHostel;
        //        Application.Disability = update.Disability;
        //        Application.DDetails = update.DDetails;
        //        Application.Accommodated = update.Accommodated;
        //        Application.APeriod = update.APeriod;
        //        Application.Sponsored = update.Sponsored;
        //        Application.Sponsor = update.Sponsor;
        //        Application.Helb = update.Helb;
        //        Application.HAmount = update.HAmount;
        //        Application.Bursary = update.Bursary;
        //        Application.BAmount = update.BAmount;
        //        Application.WSBenefits = update.WSBenefits;
        //        Application.WSPeriod = update.WSPeriod;
        //        Application.SpecialExams = update.SpecialExams;
        //        Application.SpecialPeriod = update.SpecialPeriod;
        //        Application.ConsiderationReason = update.ConsiderationReason;
        //    }
        //    return Application;
        //}
        //public static Application? UpdateApplicationStatus(string status, int id)
        //{
        //    Application? Application = GetApplication(id);
        //    if (Application != null)
        //    {
        //        Application.Status = status;
        //    }
        //    return Application;
        //}
        //public static Application? UpdateRoomNo(string roomNo, int id)
        //{
        //    Application? Application = GetApplication(id);
        //    if (Application != null)
        //    {
        //        Application.RNo = roomNo;
        //    }
        //    return Application;
        //}
        //public static Application? RemoveApplication(int id)
        //{
        //    Application? application = GetApplication(id);
        //    if (application != null)
        //    {
        //        _applications.Remove(application);
        //    }
        //    return application;
        //}
    }
}
