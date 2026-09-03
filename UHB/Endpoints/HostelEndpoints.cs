using UHB.Application.Dtos.Hostel;
using UHB.Application.Usecases.Hostels;
using UHB.Extensions.RouteHandlers;

namespace UHB.Endpoints;

public class HostelEndpoints : IRouteRegistrar
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        RouteGroupBuilder group = app.MapGroup("").WithTags("Hostels");
        app.MapGet("/hostels", async (IHostelService service) =>
        {
            List<HostelDto> hostels = await service.GetHostels();
            return hostels is null || hostels.Count == 0 ? Results.NotFound("No hostels found") : Results.Ok(hostels);
        }).WithTags("Hostels").Produces(200).Produces(404).Produces<List<HostelDto>>().RequireAuthorization("CanAccessEverything");
        app.MapGet("/hostel/{id}", async (IHostelService service, string id) =>
        {
            HostelDto? hostel = await service.GetHostel(id);
            return hostel is null ? Results.NotFound($"Hostel with id = {id} was not found") : Results.Ok(hostel);
        }).WithTags("Hostels").Produces(200).Produces(404).Produces<HostelDto>().RequireAuthorization("CanAccessEverything");
        app.MapPost("/hostel", async (IHostelService service, HostelCreateDto hostel) =>
        {
            HostelDto createdHostel = await service.CreateHostel(hostel);
            return Results.Ok(createdHostel);

        }).WithTags("Hostels").Produces(200).Produces(404).Produces<HostelDto>().RequireAuthorization("CanAccessApplications");
        app.MapPut("/hostel/{id}", async (IHostelService service, HostelCreateDto hostel, string id) =>
        {
            await service.UpdateHostel(hostel, id);
            return Results.Ok($"Hostel details for hostel number {id} has been updated");
        }).WithTags("Hostels").Produces(200).Produces(404).RequireAuthorization("CanAccessApplications");
        app.MapDelete("/hostel/{id}", async (IHostelService service, string id) =>
        {
            await service.RemoveHostel(id);
            return Results.Ok($"Hostel number {id} has been deleted.");
        }).WithTags("Hostels").Produces(200).Produces(404).RequireAuthorization("CanAccessApplications");
    }
}
