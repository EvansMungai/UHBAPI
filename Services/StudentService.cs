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
        public List<Student> GetStudents() { return _context.Students.ToList(); }
        public List<Student> GetStudent(string regNo)
        {
            regNo = getRegNo(regNo);
            return _context.Students.Where(s => s.RegNo == regNo).ToList();
        }
        public Student CreateStudent(Student student)
        {
            var newStudent = new Student
            {
                RegNo = student.RegNo,
                Surname = student.Surname,
                FirstName = student.FirstName,
                SecondName = student.SecondName,
                Gender = student.Gender
            };
            _context.Students.Add(newStudent);
            _context.SaveChanges();
            return student;
        }
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

