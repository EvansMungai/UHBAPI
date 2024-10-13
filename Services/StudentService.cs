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
        public Student? UpdateStudent(Student update, string regNo)
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
                _context.Update(student);
                _context.SaveChanges();
            }
            return student;
        }
        public Student? RemoveStudent(string regNo)
        {
            regNo = getRegNo(regNo);
            var student = _context.Students.FirstOrDefault(s => s.RegNo ==  regNo);
            if (student != null)
            {
                _context.Remove(student);
                _context.SaveChanges();
            }
            return student;
        }
        #region Utilities
        private static string getRegNo(string regNo)
        {
            regNo = regNo.Replace("%2F", "/");
            return regNo;
        }
        #endregion
    }
}

