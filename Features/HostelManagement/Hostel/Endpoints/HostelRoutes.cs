using UHB.Extensions.RouteHandlers;
using UHB.Features.HostelManagement.Models;

namespace UHB.Features.HostelManagement.Endpoints;

public class HostelRoutes : IRouteRegistrar
{
    public void RegisterRoutes(WebApplication application)
    {
        MapHostelRoutes(application);
    }

    public void MapHostelRoutes(WebApplication application)
    {
        var app = application.MapGroup("").WithTags("Hostels");
        app.MapGet("/hostels", (HostelHandler handler) => handler.GetHostels()).WithTags("Hostels").Produces(200).Produces(404).Produces<List<Hostel>>();
        app.MapGet("/hostel/{id}", (HostelHandler handler ,string id) => handler.GetHostelById(id)).WithTags("Hostels").Produces(200).Produces(404).Produces<Hostel>();
        app.MapPost("/hostel", (HostelHandler handler, Hostel hostel) => handler.CreateHostel(hostel)).WithTags("Hostels").Produces(200).Produces(404).Produces<Hostel>();
        app.MapPut("/hostel/{id}", (HostelHandler handler, Hostel hostel, string id) => handler.UpdateHostel(hostel, id)).WithTags("Hostels").Produces(200).Produces(404).Produces<Hostel>();
        app.MapDelete("/hostel/{id}", (HostelHandler handler, string id) => handler.RemoveHostel(id)).WithTags("Hostels").Produces(200).Produces(404).Produces<Hostel>();
    }
}
