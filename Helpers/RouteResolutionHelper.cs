using Microsoft.AspNetCore.Mvc;
using UHB.Models;

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
            app.MapPut("/hostels", ([FromBody] Hostel hostel) => HostelService.UpdateHostel(hostel));

            // Student Routes
            app.MapGet("/students", () => StudentService.GetStudents());
            app.MapGet("/student/{id}", (string id) => StudentService.GetStudent(id));
            app.MapPost("/students", ([FromBody] Student student) => StudentService.CreateStudent(student));
            app.MapPut("/students", ([FromBody] Student student) => StudentService.UpdateStudent(student));
        }
    }
}
