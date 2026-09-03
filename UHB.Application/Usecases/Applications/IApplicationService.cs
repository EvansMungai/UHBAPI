using UHB.Application.Dtos.Application;

namespace UHB.Application.Usecases.Applications;

public interface IApplicationService
{
    Task<List<ApplicationDto>> GetApplications();
    Task<ApplicationDto?> GetApplication(int id);
    Task<List<ApplicationDto>> GetUserApplications(string regNo);
    Task<List<ApplicationDto>> GetAcceptedApplications();
    Task<List<ApplicationDto>> GetAssignedApplications();
    Task<List<ApplicationDto>> GetRejectedApplications();
    Task<ApplicationDto> CreateApplication(ApplicationCreateDto application);
    Task UpdateApplicationDetails(ApplicationCreateDto update, int id);
    Task UpdateApplicationStatus(ApplicationUpdateStatusDto update, int id);
    Task UpdateRoomNo(ApplicationUpdateRoomDto update, int id);
    Task RemoveApplication(int id);
}
