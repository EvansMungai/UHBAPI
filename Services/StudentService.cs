using UHB.Data;
using UHB.Models;

namespace UHB.Services
{
    public class StudentService : IStudentService
    {
        private readonly UhbContext _context;
        public StudentService(UhbContext context)
        {
            _context = context;
        }
    //    public static List<Student> _students = new List<Student>()
    //{
    //    new Student { regNo = "C026-01-0914/2022", surname="Njagi", firstName="Griffins", secondName="Gitari"}
    //};
        public List<Student> GetStudents() { return _context.Students.ToList(); }
        public Student? GetStudent(string regNo)
        {
            regNo = getRegNo(regNo);
            return _context.Students.SingleOrDefault(Student => Student.RegNo == regNo);
        }
        //public static Student CreateStudent(Student student)
        //{
        //    _students.Add(student);
        //    return student;
        //}
        //public static Student? UpdateStudent(Student update, string regNo)
        //{
        //    Student? student = GetStudent(regNo);
        //    if (student != null)
        //    {
        //        student.regNo = update.regNo;
        //        student.surname = update.surname;
        //        student.firstName = update.firstName;
        //        student.secondName = update.secondName;
        //        student.gender = update.gender;
        //    }
        //    return student;
        //}
        //public static Student? RemoveStudent(string regNo)
        //{
        //    Student? student = GetStudent(regNo);
        //    if (student != null)
        //    {
        //        _students.Remove(student);
        //    }
        //    return student;
        //}
        #region Utilities
        private static string getRegNo(string regNo)
        {
            regNo = regNo.Replace("%2F", "/");
            return regNo;
        }
        #endregion
    }
}

