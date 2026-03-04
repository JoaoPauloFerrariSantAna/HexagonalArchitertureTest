using Hexagonality2.Domain.Entities;

namespace Hexagonality2.Domain.Interfaces;

public interface IStudentRepository
{
    public StudentEntity Create(StudentEntity toCreate);
    public StudentEntity Update(int id, StudentEntity toUpdate);
    public StudentEntity Delete(int id);
    public StudentEntity GetStudent(int id);
    public List<StudentEntity> GetAllStudents();

    public StudentEntity FindByEmail(string email);


}
