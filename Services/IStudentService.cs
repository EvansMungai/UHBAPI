using UHB.Models;

namespace UHB.Services
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        List<Student> GetStudent(string regNo);
        Student CreateStudent(Student student);
        Student? UpdateStudent(Student update, string regNo);
    }
}
