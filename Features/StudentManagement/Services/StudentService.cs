using UHB.Data.Infrastructure;
using UHB.Features.StudentManagement.Models;

namespace UHB.Services;

public class StudentService : IStudentService
{
    private readonly UhbContext _context;
    public StudentService(UhbContext context)
    {
        _context = context;
    }
    public async Task<IResult> GetStudents()
    {
        var students = _context.Students.Select(s => new { s.RegNo, s.Surname, s.FirstName, s.SecondName, s.Gender }).ToList();
        return students == null || students.Count == 0 ? Results.NotFound("No Categories found") : Results.Ok(students);
    }
    public async Task<IResult> GetStudent(string regNo)
    {
        var student = _context.Students.Select(s => new { s.RegNo, s.Surname, s.FirstName, s.SecondName, s.Gender }).SingleOrDefault(s => s.RegNo == regNo);
        return student == null ? Results.NotFound($"NO student with registration number = {regNo} was found") : Results.Ok(student);
    }
    public async Task<IResult> CreateStudent(Student student)
    {
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
            _context.Students.Add(newStudent);
            _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.InnerException?.Message);
        }
        return Results.Ok(newStudent);

    }
    public async Task<IResult> UpdateStudent(Student update, string regNo)
    {
        regNo = getRegNo(regNo);
        var student = _context.Students.FirstOrDefault(s => s.RegNo == regNo);
        if (student != null)
        {
            //student.RegNo = update.RegNo;
            student.Surname = update.Surname;
            student.FirstName = update.FirstName;
            student.SecondName = update.SecondName;
            student.Gender = update.Gender;
            try
            {
                _context.Students.Update(student);
                _context.SaveChangesAsync();
                return Results.Ok(student);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.InnerException?.Message);
            }
        }
        else
        {
            return Results.NotFound($"Student with registration number ={regNo} was not found");
        }
    }
    public async Task<IResult> RemoveStudent(string regNo)
    {
        regNo = getRegNo(regNo);
        var student = _context.Students.FirstOrDefault(s => s.RegNo == regNo);
        if (student != null)
        {
            try
            {
                _context.Students.Remove(student);
                _context.SaveChangesAsync();
            }
            catch (Exception ex) { return Results.BadRequest(ex.InnerException?.Message); }

            return Results.Ok(student);
        }
        else
        {
            return Results.NotFound($"Student with registration no={regNo} was not found");
        }
    }
    #region Utilities
    private static string getRegNo(string regNo)
    {
        regNo = regNo.Replace("%2F", "/");
        return regNo;
    }
    #endregion
}

