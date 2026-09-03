using UHB.Application.Dtos.Student;
using UHB.Application.Usecases.Students;
using UHB.Extensions.RouteHandlers;

namespace UHB.Endpoints;

public class StudentEndpoints : IRouteRegistrar
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        RouteGroupBuilder group = app.MapGroup("").WithTags("Student");
        app.MapGet("/students", async (IStudentService service) =>
        {
            List<StudentDto> students = await service.GetStudents();
            return students is null || students.Count == 0 ? Results.NotFound("No Categories found") : Results.Ok(students);
        }).WithTags("Students").Produces(200).Produces(404).Produces<List<StudentDto>>().RequireAuthorization("CanAccessManagement");
        app.MapGet("/student", async (IStudentService service, string id) =>
        {
            StudentDto? student = await service.GetStudent(id);
            return student is null ? Results.NotFound($"NO student with registration number = {id} was found") : Results.Ok(student);
        }).WithTags("Students").Produces(200).Produces(404).Produces<StudentDto>().RequireAuthorization("CanAccessEverything");
        app.MapPost("/student", async (IStudentService service, StudentCreateDto student) =>
        {
            StudentDto createdStudent = await service.CreateStudent(student);
            return Results.Ok(student);
        }).WithTags("Students").Produces(200).Produces(404).Produces<StudentDto>().RequireAuthorization("CanAccessStudentDetails");
        app.MapPut("/student/{id}", async (IStudentService service, StudentCreateDto student, string id) =>
        {
            await service.UpdateStudent(student, id);
            return Results.Ok($"Student details for registration number = {id} have been updated.");
        }).WithTags("Students").Produces(200).Produces(404).RequireAuthorization("CanAccessStudentDetails");
        app.MapDelete("/student/{id}", async (IStudentService service, string id) =>
        {
            await service.RemoveStudent(id);
            return Results.Ok($"Student with registration number = {id} has been removed.");
        }).WithTags("Students").Produces(200).Produces(404).RequireAuthorization("CanAccessManagement");
    }
}
