namespace Hexagonality2.Application;

using Hexagonality2.Application.Domain;
using Hexagonality2.Application.Domain.Entities;
using Hexagonality2.Application.Domain.Interfaces;

public class StudentService : IStudentService
{
    private readonly IDatabaseRepository _databaseRepository;

    public StudentService(IDatabaseRepository repository)
    {
        this._databaseRepository = repository;
    }

    public StudentDto Create(StudentEntity toCreate)
    {
        StudentEntity s = this._databaseRepository.Insert(toCreate);

        return new StudentDto
        {
            FirstName = s.FirstName,
            Email = s.Email,
            CreatedAt = DateTime.UtcNow,
        };
    }

    public StudentDto Delete(int id)
    {
        StudentEntity s = this._databaseRepository.Delete(id);

        return new StudentDto
        {
            FirstName = s.FirstName,
            Email = s.Email,
            DeletedAt = DateTime.UtcNow,
        };
    }

    public StudentDto FindByEmail(string email)
    {
        StudentEntity s = this._databaseRepository.SelectByEmail(email);

        return new StudentDto
        {
            FirstName = s.FirstName,
            Email = s.Email,
            CreatedAt = DateTime.UtcNow,
        };
    }

    public List<StudentDto> GetAllStudents()
    {
        List<StudentEntity> sts = this._databaseRepository.SelectAll();
        List<StudentDto> dtos = new List<StudentDto>();

        return dtos;
    }

    public StudentDto GetStudent(int id)
    {
        StudentEntity s = this._databaseRepository.SelectById(id);

        return new StudentDto
        {
            FirstName = s.FirstName,
            Email = s.Email,
            CreatedAt = DateTime.UtcNow,
        };
    }

    public StudentDto Update(int id, StudentEntity student)
    {
        StudentEntity s = this._databaseRepository.Update(id, student);

        return new StudentDto
        {
            FirstName = student.FirstName,
            Email= student.Email,
            UpdatedAt = DateTime.UtcNow
        };
    }
}