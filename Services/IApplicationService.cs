using UHB.Data;
using UHB.Models;

namespace UHB.Services
{
    public interface IApplicationService
    {
        List<Application> GetApplications();
        List<Application?> GetApplication(int id);
        //Task<Application> CreateApplication(Application Application);
    }
}
