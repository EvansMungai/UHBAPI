using UHB.Application.Dtos.Student;
using UHB.Application.Interface;
using UHB.Domain.Entities;

namespace UHB.Application.Usecases.Students;

public class StudentService : IStudentService
{
    private readonly IRepository<StudentDomain, string> _repo;

    public StudentService(IRepository<StudentDomain, string> repo)
    {
        _repo = repo;
    }

    public async Task<List<StudentDto>> GetStudents() => await _repo.GetAllAsync<StudentDto>();
    public async Task<StudentDto?> GetStudent(string regNo)
    {
        regNo = getRegNo(regNo);
        return await _repo.GetSingleAsync<StudentDto>(s => s.RegNo == regNo);
    }
    public async Task<StudentDto> CreateStudent(StudentCreateDto student) => await _repo.CreateAsync<StudentDto, StudentCreateDto>(student);
    public async Task UpdateStudent(StudentCreateDto update, string regNo)
    {
        regNo = getRegNo(regNo);
        await _repo.UpdateAsync(update, s => s.RegNo == regNo);        
    }
    public async Task RemoveStudent(string regNo)
    {
        regNo = getRegNo(regNo);
        await _repo.RemoveAsync(s => s.RegNo == regNo);
    }
    #region Utilities
    private static string getRegNo(string regNo)
    {
        regNo = regNo.Replace("%2F", "/");
        return regNo;
    }
    #endregion
}

