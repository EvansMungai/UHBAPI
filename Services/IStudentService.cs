using UHB.Models;

namespace UHB.Services
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        Student? GetStudent(string regNo);
    }
}
