using Microsoft.EntityFrameworkCore;
using UHB.Data.Infrastructure;
using UHB.Features.StudentManagement.Models;

namespace UHB.Features.StudentManagement.Services;

public class StudentRepository : IStudentRepository
{
    private readonly UhbContext _context;
    public StudentRepository(UhbContext context)
    {
        _context = context;
    }
    public async Task CreateStudentAsync(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Student>> GetAllStudentsAsync()
    {
        return await _context.Students.Select(s => new Student { RegNo = s.RegNo, Surname = s.Surname, FirstName = s.FirstName, SecondName = s.SecondName, Gender = s.Gender }).ToListAsync();
    }

    public async Task<Student?> GetStudentByIdAsync(string regNo)
    {
        return await _context.Students.Select(s => new Student { RegNo = s.RegNo, Surname = s.Surname, FirstName = s.FirstName, SecondName = s.SecondName, Gender = s.Gender }).SingleOrDefaultAsync(s => s.RegNo == regNo);
    }

    public async Task RemoveStudentAsync(string regNo)
    {
        var student = await GetStudentByIdAsync(regNo);
        if (student == null) return;

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateStudentDetailsAsync(Student update, string regNo)
    {
        var student = await GetStudentByIdAsync(regNo);
        if (student == null) return;

        student.Surname = update.Surname;
        student.FirstName = update.FirstName;
        student.SecondName = update.SecondName;
        student.Gender = update.Gender;

        _context.Students.Update(student);
        await _context.SaveChangesAsync();
    }
}