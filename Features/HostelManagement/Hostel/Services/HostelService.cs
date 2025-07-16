using UHB.Features.HostelManagement.Models;

namespace UHB.Features.HostelManagement.Services;

public class HostelService : IHostelService
{
    private readonly IHostelRepository _repo;
    public HostelService(IHostelRepository repo)
    {
        _repo = repo;
    }

    public async Task<IResult> GetHostels()
    {
        var hostels = await _repo.GetAllHostelsAsync();
        return hostels == null || hostels.Count == 0 ? Results.NotFound("No hostels found") : Results.Ok(hostels);
    }
    public async Task<IResult> GetHostel(string id)
    {
        var hostel = await _repo.GetHostelByIdAsync(id);
        return hostel == null ? Results.NotFound($"Hostel with id = {id} was not found") : Results.Ok(hostel);
    }
    public async Task<IResult> CreateHostel(Hostel hostel)
    {
        var retrievedHostel = await _repo.GetHostelByIdAsync(hostel.HostelNo);
        if (retrievedHostel != null)
            return Results.BadRequest($"Hostel with hostel No = {hostel.HostelNo} exists");

        var newHostel = new Hostel
        {
            HostelNo = hostel.HostelNo,
            HostelName = hostel.HostelName,
            Capacity = hostel.Capacity,
            Type = hostel.Type
        };
        try
        {
            await _repo.CreateHostelAsync(newHostel);
            return Results.Ok(newHostel);
        }
        catch (Exception ex) { return Results.BadRequest(ex.InnerException?.Message ?? ex.Message); }
    }
    public async Task<IResult> UpdateHostel(Hostel update, string id)
    {
        var hostel = await _repo.GetHostelByIdAsync(id);
        if (hostel == null)
            return Results.NotFound($"Hostel with id = {id} was not found");

        try
        {
            await _repo.UpdateHostelAsync(update, id);
            return Results.Ok(hostel);
        }
        catch (Exception ex) { return Results.BadRequest(ex.InnerException?.Message ?? ex.Message); }
    }
    public async Task<IResult> RemoveHostel(string id)
    {
        var hostel = await _repo.GetHostelByIdAsync(id);
        if (hostel == null)
            return Results.NotFound($"Hostel with id ={id} was not found.");

        try
        {
            await _repo.RemoveHostelAsync(id);
            return Results.Ok(hostel);
        }
        catch (Exception ex) { return Results.BadRequest(ex.InnerException?.Message ?? ex.Message); }

    }
}
