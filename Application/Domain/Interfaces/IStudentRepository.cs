using Hexagonality2.Application.Domain;

namespace Hexagonality2.Application.Domain.Interfaces;

public interface IStudentRepository
{
    public StudentRepository Create(StudentRepository student);
    public StudentRepository Update(int id, StudentRepository studentToUpdate);
    public StudentRepository Delete(int id);
    public void FindByEmail(string email);
    public StudentRepository GetStudent(int id);
    public List<StudentRepository> GetAllStudents();
}
