using UHB.Application.Dtos.Application;
using UHB.Application.Usecases.Applications;
using UHB.Extensions.RouteHandlers;

namespace UHB.Endpoints;

public class ApplicationEndpoints : IRouteRegistrar
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        RouteGroupBuilder group = app.MapGroup("").WithTags("Applications");
        group.MapGet("/applications", async (IApplicationService service) =>
        {
            List<ApplicationDto> applications = await service.GetApplications();
            return applications is null || applications.Count == 0 ? Results.NotFound("No applications were found") : Results.Ok(applications);
        }).Produces(200).Produces(404).Produces<List<ApplicationDto>>().RequireAuthorization("CanAccessApplications");
        group.MapGet("/user-applications", async (IApplicationService service, string regNo) =>
        {
            List<ApplicationDto> applications = await service.GetUserApplications(regNo);
            return applications is null || applications.Count == 0 ? Results.NotFound("No user applications were found") : Results.Ok(applications);
        }).Produces(200).Produces(404).Produces<List<ApplicationDto>>().RequireAuthorization("CanAccessEverything");
        group.MapGet("/accepted-applications", async (IApplicationService service) =>
        {
            List<ApplicationDto> applications = await service.GetAcceptedApplications();
            return applications is null || !applications.Any() ? Results.NotFound("No Accepted applications were found.") : Results.Ok(applications);
        }).Produces(200).Produces(404).Produces<List<ApplicationDto>>().RequireAuthorization("CanAccessAcceptedApplications");
        group.MapGet("/assigned-applications", async (IApplicationService service) =>
        {
            List<ApplicationDto> applications = await service.GetAssignedApplications();
            return applications is null || !applications.Any() ? Results.NotFound("No assigned applications were found.") : Results.Ok(applications);
        }).Produces(200).Produces(404).Produces<List<ApplicationDto>>().RequireAuthorization("CanAccessAcceptedApplications");
        group.MapGet("/rejected-applications", async (IApplicationService service) =>
        {
            List<ApplicationDto> applications = await service.GetRejectedApplications();
            return applications == null || !applications.Any() ? Results.NotFound("No Rejected applications were found.") : Results.Ok(applications);
        }).Produces(200).Produces(404).Produces<List<ApplicationDto>>().RequireAuthorization("CanAccessApplications");
        group.MapGet("/application/{id}", async (IApplicationService service, int id) =>
        {
            ApplicationDto application = await service.GetApplication(id);
            return application == null ? Results.NotFound($"Application with application id ={id} was not found") : Results.Ok(application);
        }).Produces(200).Produces(404).Produces<ApplicationDto>().RequireAuthorization("CanAccessEverything");
        group.MapPost("/application", async (IApplicationService service, ApplicationCreateDto application) =>
        {
            ApplicationDto createdApplication = await service.CreateApplication(application);
            return Results.Ok(createdApplication);
        }).Produces(200).Produces(404).Produces<ApplicationDto>().RequireAuthorization("CanAccessStudentDetails");
        group.MapPut("/application/{id}", async (IApplicationService service, ApplicationCreateDto application, int id) =>
        {
            await service.UpdateApplicationDetails(application, id);
            return Results.Ok($"Application details for application {id} has been updated.");
        }).WithTags("Applications").Produces(200).Produces(404).RequireAuthorization("CanAccessStudentDetails");
        group.MapPut("/application/{id}/status", async (IApplicationService service, ApplicationUpdateStatusDto update, int id) =>
        {
            await service.UpdateApplicationStatus(update, id);
            return Results.Ok($"Application status for application {id} has been updated.");
        }).WithTags("Applications").Produces(200).Produces(404).RequireAuthorization("CanAccessApplications");
        group.MapPut("/application/{id}/room", async (IApplicationService service, ApplicationUpdateRoomDto update, int id) =>
        {
            await service.UpdateRoomNo(update, id);
            return Results.Ok($"Application with application number {id} has been assigned a room.");
        }).WithTags("Applications").Produces(200).Produces(404).RequireAuthorization("CanAccessAcceptedApplications");
        group.MapDelete("/application/{id}", async (IApplicationService service, int id) =>
        {
            await service.RemoveApplication(id);
            return Results.Ok("Application has been deleted");
        }).WithTags("Applications").Produces(200).Produces(404).RequireAuthorization("CanAccessStudentDetails");
    }
}
