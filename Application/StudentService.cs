namespace Hexagonality2.Application;

using Hexagonality2.Application.Domain;
using Hexagonality2.Application.Domain.Interfaces;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;

    public StudentService(IStudentRepository repositoyr)
    {
        _repository = repositoyr;
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
}
