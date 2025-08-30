using UHB.Extensions.RouteHandlers;
using UHB.Features.ApplicationManagement.Models;

namespace UHB.Features.ApplicationManagement.Endpoints;

public class ApplicationRoutes : IRouteRegistrar
{
    public void RegisterRoutes(WebApplication application)
    {
        MapApplicationRoutes(application);
    }

    public void MapApplicationRoutes(WebApplication application)
    {
        var app = application.MapGroup("").WithTags("Application");
        app.MapGet("/applications", (ApplicationHandler handler) => handler.GetApplications()).WithTags("Applications").Produces(200).Produces(404).Produces<List<Application>>();
        app.MapGet("/accepted-applications", (ApplicationHandler handler) => handler.GetAcceptedApplications()).WithTags("Applications").Produces(200).Produces(404).Produces<List<Application>>();
        app.MapGet("/assigned-applications", (ApplicationHandler handler) => handler.GetAssignedApplications()).WithTags("Applications").Produces(200).Produces(404).Produces<List<Application>>();
        app.MapGet("/rejected-applications", (ApplicationHandler handler) => handler.GetRejectedApplications()).WithTags("Applications").Produces(200).Produces(404).Produces<List<Application>>();
        app.MapGet("/application/{id}", (ApplicationHandler handler, int id) => handler.GetApplicationById(id)).WithTags("Applications").Produces(200).Produces(404).Produces<Application>();
        app.MapPost("/application", (ApplicationHandler handler, Application application) => handler.CreateApplication(application)).WithTags("Applications").Produces(200).Produces(404).Produces<Application>();
        app.MapPut("/application/{id}", (ApplicationHandler handler, Application application, int id) => handler.UpdateApplicationDetails(application, id)).WithTags("Applications").Produces(200).Produces(404).Produces<Application>();
        app.MapPut("/application/{id}/status", (ApplicationHandler handler, string status, string preferredHostel, int id) => handler.UpdateApplicationStatus(status, preferredHostel, id)).WithTags("Applications").Produces(200).Produces(404).Produces<Application>();
        app.MapPut("/application/{id}/room", (ApplicationHandler handler, string room, int id) => handler.AssignRoomToApplicant(room, id)).WithTags("Applications").Produces(200).Produces(404).Produces<Application>();
        app.MapDelete("/application/{id}", (ApplicationHandler handler, int id) => handler.RemoveApplication(id)).WithTags("Applications").Produces(200).Produces(404).Produces<Application>();
    }
}
