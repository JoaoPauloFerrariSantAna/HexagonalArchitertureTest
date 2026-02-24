using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Hexagonality2.Application.Domain.Interfaces;

namespace Hexagonality2.Application.Domain;

public class StudentRepository : IStudentRepository
{
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Name is obligatory")]
    [NotNull()]
    [Length(minimumLength: 1, maximumLength: 50)]
    public string FirstName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; set; }

    // NOTE: temporary solution
    private static List<StudentRepository> students;

    public StudentRepository()
    {
        students = new List<StudentRepository>();
    }

    public void Create(StudentRepository student)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public void FindByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public void Update(StudentRepository studentToUpdate)
    {
        throw new NotImplementedException();
    }

    public List<StudentRepository> GetAllStudents()
    {
        return students;
    }

    public StudentRepository GetStudent(int id)
    {
        StudentRepository student = null;

        foreach (var currentStudent in students)
        {
            if (currentStudent.Id == id) student = currentStudent;
        }

        if (student == null) throw new Exception("User not found");

        return student;
    }
}
