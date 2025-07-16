using UHB.Features.ApplicationManagement.Models;

namespace UHB.Features.ApplicationManagement.Services
{
    public interface IApplicationService
    {
        Task<IResult> GetApplications();
        Task<IResult> GetApplication(int id);
        Task<IResult> GetAcceptedApplications();
        Task<IResult> GetRejectedApplications();
        Task<IResult> CreateApplication(Application application);
        Task<IResult> UpdateApplicationDetails(Application update, int id);
        Task<IResult> UpdateApplicationStatus(string status, int id);
        Task<IResult> UpdateRoomNo(string roomNo, int id);
        Task<IResult> RemoveApplication(int id);
    }
}
