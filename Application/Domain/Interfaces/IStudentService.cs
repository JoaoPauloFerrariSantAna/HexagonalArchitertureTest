namespace Hexagonality2.Application.Domain.Interfaces;

public interface IStudentService
{
    public void Create(StudentRepository student);
    public void Update(StudentRepository studentToUpdate);
    public void Delete(int id);
    public void FindByEmail(string email);
}
