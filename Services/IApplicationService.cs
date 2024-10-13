using UHB.Data;
using UHB.Models;


namespace UHB.Services
{
    public interface IApplicationService
    {
        List<Application> GetApplications();
        List<Application> GetApplication(int id);
        Application CreateApplication(Application application);
        Application? UpdateApplicationDetails(Application update, int id);
        Application? UpdateApplicationStatus(string status, int id);
        Application? UpdateRoomNo(string roomNo, int id);
    }
}
