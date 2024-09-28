using Microsoft.AspNetCore.Mvc;
using UHB.Models;
using UHB.Services;

namespace UHB.Helpers
{
    public class RouteResolutionHelper
    {
        public static void addMappings(WebApplication app)
        {
            // Hostel Routes
            app.MapGet("/hostels", () => HostelService.GetHostels());
            app.MapGet("/hostels/{id}", (int id) => HostelService.GetHostel(id));
            app.MapPost("/hostels", ([FromBody] Hostel hostel) => HostelService.CreateHostel(hostel));
            app.MapPut("/hostels/{id}", ([FromBody] Hostel hostel, int id) => HostelService.UpdateHostel(hostel, id));
            app.MapDelete("/hostel/{id}", (int id) => HostelService.RemoveHostel(id));

            // Student Routes
            app.MapGet("/students", () => StudentService.GetStudents());
            app.MapGet("/student/{id}", (string id) => StudentService.GetStudent(id));
            app.MapPost("/students", ([FromBody] Student student) => StudentService.CreateStudent(student));
            app.MapPut("/students/{id}", ([FromBody] Student student, string id) => StudentService.UpdateStudent(student, id));
            app.MapDelete("/students/{id}", (string id) => StudentService.RemoveStudent(id));

            // Room Routes
            app.MapGet("/rooms", () => RoomService.GetRooms());
            app.MapGet("/rooms/{id}", (string id) => RoomService.GetRoom(id));
            app.MapPost("/rooms", ([FromBody] Rooms room) => RoomService.CreateRoom(room));
            app.MapPut("/rooms/{id}", ([FromBody] Rooms room, string id) => RoomService.UpdateRoom(room, id));
            app.MapDelete("/rooms/{id}", (string id) => RoomService.RemoveRoom(id));

            // Applications Routes
            app.MapGet("/applications", () => ApplicationService.GetApplications());
            app.MapGet("/applications/{id}", (int id) => ApplicationService.GetApplication(id));
            app.MapPost("/applications", ([FromBody] Applications application) => ApplicationService.CreateApplications(application));
            app.MapPut("/applications/{id}", ([FromBody] Applications application, int id) => ApplicationService.UpdateApplicationDetails(application, id));
            app.MapPut("/applications/{id}/status", ([FromBody] string status, int id) => ApplicationService.UpdateApplicationStatus(status, id));
            app.MapPut("/applications/{id}/room", ([FromBody] string room, int id) => ApplicationService.UpdateRoomNo(room, id));
            app.MapDelete("/applications/{id}", (int id) => ApplicationService.RemoveApplication(id));
        }
    }
}
