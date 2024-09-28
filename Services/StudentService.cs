using System.Security.Cryptography.X509Certificates;
using UHB.Models;

public class StudentService
{
    public static List<Student> _students = new List<Student>()
    {
        new Student { regNo = "C026-01-0914/2022", surname="Njagi", firstName="Griffins", secondName="Gitari"}
    };
    public static List<Student> GetStudents() { return _students; }
    public static Student? GetStudent(string regNo)
    {
        return _students.SingleOrDefault(Student => Student.regNo == regNo);
    }
    public static Student CreateStudent(Student student)
    {
        _students.Add(student);
        return student;
    }
}
