using Hexagonality2.Application.Domain;

namespace Hexagonality2.Application.Domain.Interfaces;

public interface IStudentRepository
{
    public void Create(StudentRepository student);
    public void Update(StudentRepository studentToUpdate);
    public void Delete(int id);
    public void FindByEmail(string email);
    public StudentRepository GetStudent(int id);
    public List<StudentRepository> GetAllStudents();
}
