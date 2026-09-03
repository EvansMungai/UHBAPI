using UHB.Application.Dtos.Student;

namespace UHB.Application.Usecases.Students;

public interface IStudentService
{
    Task<List<StudentDto>> GetStudents();
    Task<StudentDto> GetStudent(string regNo);
    Task<StudentDto> CreateStudent(StudentCreateDto student);
    Task UpdateStudent(StudentCreateDto update, string regNo);
    Task RemoveStudent(string regNo);
}
