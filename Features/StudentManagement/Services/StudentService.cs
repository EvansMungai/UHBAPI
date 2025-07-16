using UHB.Features.StudentManagement.Models;

namespace UHB.Features.StudentManagement.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repo;
    public StudentService(IStudentRepository repo)
    {
        _repo = repo;
    }
    public async Task<IResult> GetStudents()
    {
        var students = await _repo.GetAllStudentsAsync();
        return students == null || students.Count == 0 ? Results.NotFound("No Categories found") : Results.Ok(students);
    }
    public async Task<IResult> GetStudent(string regNo)
    {
        var student = await _repo.GetStudentByIdAsync(regNo);
        return student == null ? Results.NotFound($"NO student with registration number = {regNo} was found") : Results.Ok(student);
    }
    public async Task<IResult> CreateStudent(Student student)
    {
        var existingStudent = await _repo.GetStudentByIdAsync(student.RegNo);
        if (existingStudent != null)
            return Results.BadRequest($"Student with Registration Number = {student.RegNo} exists");

        var newStudent = new Student
        {
            RegNo = student.RegNo,
            Surname = student.Surname,
            FirstName = student.FirstName,
            SecondName = student.SecondName,
            Gender = student.Gender
        };
        try
        {
            await _repo.CreateStudentAsync(newStudent);
            return Results.Ok(newStudent);
        }
        catch (Exception ex) { return Results.BadRequest(ex.InnerException?.Message ?? ex.Message); }

    }
    public async Task<IResult> UpdateStudent(Student update, string regNo)
    {
        regNo = getRegNo(regNo);
        var student = await _repo.GetStudentByIdAsync(regNo);
        if (student == null)
            return Results.NotFound($"Student with registration number ={regNo} was not found");

        try
        {
            await _repo.UpdateStudentDetailsAsync(update, regNo);
            return Results.Ok(update);
        }
        catch (Exception ex) { return Results.BadRequest(ex.InnerException?.Message ?? ex.Message); }
    }
    public async Task<IResult> RemoveStudent(string regNo)
    {
        regNo = getRegNo(regNo);
        var student = await _repo.GetStudentByIdAsync(regNo);
        if (student == null)
            return Results.NotFound($"Student with registration no={regNo} was not found");

        try
        {
            await _repo.RemoveStudentAsync(regNo);
        }
        catch (Exception ex) { return Results.BadRequest(ex.InnerException?.Message); }

        return Results.Ok(student);
    }
    #region Utilities
    private static string getRegNo(string regNo)
    {
        regNo = regNo.Replace("%2F", "/");
        return regNo;
    }
    #endregion
}

