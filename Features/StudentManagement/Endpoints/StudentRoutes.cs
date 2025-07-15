using UHB.Extensions.RouteHandlers;
using UHB.Features.StudentManagement.Models;

namespace UHB.Features.StudentManagement.Endpoints;

public class StudentRoutes : IRouteRegistrar
{
    public void RegisterRoutes(WebApplication application)
    {
        MapStudentRoutes(application);
    }
    private void MapStudentRoutes(WebApplication webApplication)
    {
        var app = webApplication.MapGroup("").WithTags("Student");
        app.MapGet("/students", (StudentHandler handler) => handler.GetStudents()).WithTags("Students").Produces(200).Produces(404).Produces<List<Student>>();
        app.MapGet("/student/{id}", (StudentHandler handler,string id) => handler.GetStudentById(id)).WithTags("Students").Produces(200).Produces(404).Produces<Student>();
        app.MapPost("/student", (StudentHandler handler,Student student) => handler.CreateStudent(student)).WithTags("Students").Produces(200).Produces(404).Produces<Student>();
        app.MapPut("/student/{id}", (StudentHandler handler, Student student, string id) => handler.UpdateStudentDetails(student, id)).WithTags("Students").Produces(200).Produces(404).Produces<Student>();
        app.MapDelete("/student/{id}", (StudentHandler handler, string id) => handler.RemoveStudent(id)).WithTags("Students").Produces(200).Produces(404).Produces<Student>();
    }
}
