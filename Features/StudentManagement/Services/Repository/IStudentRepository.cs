using UHB.Features.StudentManagement.Models;

namespace UHB.Features.StudentManagement.Services;

public interface IStudentRepository
{
    Task<List<Student>> GetAllStudentsAsync();
    Task<Student?> GetStudentByIdAsync(string regNo);
    Task CreateStudentAsync(Student student);
    Task UpdateStudentDetailsAsync(Student student, string regNo);
    Task RemoveStudentAsync(string regNo);
}
