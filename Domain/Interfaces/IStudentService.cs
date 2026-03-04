using Hexagonality2.Domain;
using Hexagonality2.Domain.Entities;

namespace Hexagonality2.Domain.Interfaces;

public interface IStudentService
{
    public StudentDto Create(StudentEntity student);
    public StudentDto Update(int id, StudentEntity studentToUpdate);
    public StudentDto Delete(int id);
    public StudentDto FindByEmail(string email);
    public StudentDto GetStudent(int id);
    public List<StudentDto> GetAllStudents();
    public bool IsEmailValid(string email);
}