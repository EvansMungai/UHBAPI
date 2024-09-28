using UHB.Models;

namespace UHB.Services
{
    public class ApplicationService
    {
        public static List<Applications> _applications = new List<Applications>()
        {
            new Applications{ Id= 1, Period="2022", RegNO="C026-01-0914/2022", PHostel="Batian", Status="Pending Review", Disability=false, Accommodated=false, Sponsored=false, Helb=false, Bursary=false, WSBenefits=false, SpecialExams=false, ConsiderationReason="I am worth it" }
        };
        public static List<Applications> GetApplications() { return _applications; }
        public static Applications? GetApplication(int id) { return _applications.SingleOrDefault(a => a.Id == id); }
        public static Applications CreateApplications(Applications applications)
        {
            _applications.Add(applications);
            return applications;
        }
        public static Applications? UpdateApplicationDetails(Applications update, int id)
        {
            Applications? applications = GetApplication(id);
            if (applications != null)
            {
                applications.Period = update.Period;
                applications.RegNO = update.RegNO;
                applications.PHostel = update.PHostel;
                applications.Disability = update.Disability;
                applications.DDetails = update.DDetails;
                applications.Accommodated = update.Accommodated;
                applications.APeriod = update.APeriod;
                applications.Sponsored = update.Sponsored;
                applications.Sponsor = update.Sponsor;
                applications.Helb = update.Helb;
                applications.HAmount = update.HAmount;
                applications.Bursary = update.Bursary;
                applications.BAmount = update.BAmount;
                applications.WSBenefits = update.WSBenefits;
                applications.WSPeriod = update.WSPeriod;
                applications.SpecialExams = update.SpecialExams;
                applications.SpecialPeriod = update.SpecialPeriod;
                applications.ConsiderationReason = update.ConsiderationReason;
            }
            return applications;
        }
        public static Applications? UpdateApplicationStatus(string status, int id)
        {
            Applications? applications = GetApplication(id);
            if (applications != null)
            {
                applications.Status = status;
            }
            return applications;
        }
        public static Applications? UpdateRoomNo(string roomNo, int id) {
            Applications? applications = GetApplication(id);
            if (applications != null)
            {
                applications.RNo= roomNo;
            }
            return applications;
        }
        public static Applications? RemoveApplication(int id)
        {
            Applications? application = GetApplication(id);
            if (application != null)
            {
                _applications.Remove(application);
            }
            return application;
        }
    }
}
