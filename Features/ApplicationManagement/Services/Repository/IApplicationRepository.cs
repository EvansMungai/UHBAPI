using UHB.Features.ApplicationManagement.Models;

namespace UHB.Features.ApplicationManagement.Services;

public interface IApplicationRepository
{
    Task<List<Application>> GetAllApplicationsAsync();
    Task<Application?> GetApplicationByIdAsync(int id);
    Task<List<Application>> GetAcceptedApplicationsAsync();
    Task<List<Application>> GetAssignedApplicationsAsync();
    Task<List<Application>> GetRejectedApplicationsAsync();
    Task CreateApplicationAsync(Application application);
    Task UpdateApplicationDetailsAsync(Application update, int id);
    Task UpdateApplicationStatusAsync(string status, string preferredHostel, int id);
    Task AssignRoomToApplicant(string roomNo, int id);
    Task RemoveApplicationAsync(int id);
}
