using UHB.Application.Dtos.Room;
using UHB.Application.Usecases.Rooms;
using UHB.Extensions.RouteHandlers;

namespace UHB.Endpoints;

public class RoomEndpoints : IRouteRegistrar
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        RouteGroupBuilder group = app.MapGroup("").WithTags("Rooms");
        app.MapGet("/rooms", async (IRoomService service) =>
        {
            List<RoomDto> rooms = await service.GetRooms();
            return rooms is null || rooms.Count == 0 ? Results.NotFound("No rooms were found") : Results.Ok(rooms);
        }).WithTags("Rooms").Produces(200).Produces(404).Produces<List<RoomDto>>().RequireAuthorization("CanAccessEverything");
        app.MapGet("/room/{id}", async (IRoomService service, string id) =>
        {
            RoomDto? room = await service.GetRoom(id);
            return room is null ? Results.NotFound($"Room with id ={id} was not found") : Results.Ok(room);
        }).WithTags("Rooms").Produces(200).Produces(404).Produces<RoomDto>().RequireAuthorization("CanAccessEverything");
        app.MapPost("/room", async (IRoomService service, RoomCreateDto room) =>
        {
            RoomDto createdRoom = await service.CreateRoom(room);
            return Results.Ok(createdRoom);
        }).WithTags("Rooms").Produces(200).Produces(404).Produces<RoomDto>().RequireAuthorization("CanAccessApplications");
        app.MapPut("/room/{id}", async (IRoomService service, RoomCreateDto room, string id) =>
        {
            await service.UpdateRoom(room, id);
            return Results.Ok($"Room details have been updated.");
        }).WithTags("Rooms").Produces(200).Produces(404).RequireAuthorization("CanAccessApplications");
        app.MapDelete("/room/{id}", async (IRoomService service, string id) =>
        {
            await service.RemoveRoom(id);
            return Results.Ok($"Room with room number {id} has been removed.");
        }).WithTags("Rooms").Produces(200).Produces(404).RequireAuthorization("CanAccessApplications");
    }
}
