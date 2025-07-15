using UHB.Extensions.RouteHandlers;
using UHB.Features.HostelManagement.Models;

namespace UHB.Features.HostelManagement.Endpoints;

public class RoomRoutes : IRouteRegistrar
{
    public void RegisterRoutes(WebApplication application)
    {
        MapRoomRoutes(application);
    }
    public void MapRoomRoutes(WebApplication application)
    {
        var app = application.MapGroup("").WithTags("Rooms");
        app.MapGet("/rooms", (RoomHandler handler) => handler.GetRooms()).WithTags("Rooms").Produces(200).Produces(404).Produces<List<Room>>();
        app.MapGet("/room/{id}", (RoomHandler handler, string id) => handler.GetRoomById(id)).WithTags("Rooms").Produces(200).Produces(404).Produces<Room>();
        app.MapPost("/room", (RoomHandler handler, Room room) => handler.CreateRoom(room)).WithTags("Rooms").Produces(200).Produces(404).Produces<Room>();
        app.MapPut("/room/{id}", (RoomHandler handler, Room room, string id) => handler.UpdateRoomDetails(room, id)).WithTags("Rooms").Produces(200).Produces(404).Produces<Room>();
        app.MapDelete("/room/{id}", (RoomHandler handler, string id) => handler.RemoveRoom(id)).WithTags("Rooms").Produces(200).Produces(404).Produces<Room>();
    }
}
