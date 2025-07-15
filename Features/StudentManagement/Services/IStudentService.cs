using UHB.Features.StudentManagement.Models;

namespace UHB.Features.StudentManagement.Services;

public interface IStudentService
{
    Task<IResult> GetStudents();
    Task<IResult> GetStudent(string regNo);
    Task<IResult> CreateStudent(Student student);
    Task<IResult> UpdateStudent(Student update, string regNo);
    Task<IResult> RemoveStudent(string regNo);
}
