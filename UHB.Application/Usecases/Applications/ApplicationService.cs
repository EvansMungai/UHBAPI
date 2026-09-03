using UHB.Application.Dtos.Application;
using UHB.Application.Interface;
using UHB.Domain.Entities;

namespace UHB.Application.Usecases.Applications;

public class ApplicationService : IApplicationService
{
    private readonly IRepository<ApplicationDomain, int> _repo;

    public ApplicationService(IRepository<ApplicationDomain, int> repo)
    {
        _repo = repo;
    }

    public async Task<List<ApplicationDto>> GetApplications() => await _repo.GetAllAsync<ApplicationDto>();
    public async Task<ApplicationDto?> GetApplication(int id) => await _repo.GetSingleAsync<ApplicationDto>(a => a.ApplicationNo == id);

    public async Task<List<ApplicationDto>> GetUserApplications(string regNo)
    {
        regNo = getRegNo(regNo);
        return await _repo.GetFilteredAsync<ApplicationDto>(a => a.RegistrationNo == regNo);
    }
    public async Task<List<ApplicationDto>> GetAcceptedApplications() => await _repo.GetFilteredAsync<ApplicationDto>(a => a.Status == "Accepted");
    public async Task<List<ApplicationDto>> GetAssignedApplications() => await _repo.GetFilteredAsync<ApplicationDto>(a => a.RoomNo != null);
    public async Task<List<ApplicationDto>> GetRejectedApplications() => await _repo.GetFilteredAsync<ApplicationDto>(a => a.Status == "Rejected");
    public async Task<ApplicationDto> CreateApplication(ApplicationCreateDto application) => await _repo.CreateAsync<ApplicationDto, ApplicationCreateDto>(application);
    public async Task UpdateApplicationDetails(ApplicationCreateDto update, int id) => await _repo.UpdateAsync(update, a => a.ApplicationNo == id);
    public async Task UpdateApplicationStatus(ApplicationUpdateStatusDto update, int id) => await _repo.UpdateAsync(update, a => a.ApplicationNo == id);
    public async Task UpdateRoomNo(ApplicationUpdateRoomDto update, int id) => await _repo.UpdateAsync(update, a => a.ApplicationNo == id);
    public async Task RemoveApplication(int id) => await _repo.RemoveAsync(a => a.ApplicationNo == id);

    #region Utilities
    private static string getRegNo(string regNo)
    {
        regNo = regNo.Replace("%2F", "/");
        return regNo;
    }
    #endregion
}
