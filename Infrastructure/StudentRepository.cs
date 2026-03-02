using Hexagonality2.Application.Domain;
using Hexagonality2.Application.Domain.Entities;
using Hexagonality2.Application.Domain.Interfaces;

namespace Hexagonality2.Infrastructure;

public class StudentRepository : IStudentRepository
{
    private readonly IDatabaseRepository _table;

    public StudentRepository(IDatabaseRepository table)
    {
        this._table = table;
    }

    public StudentEntity Create(StudentEntity toCreate)
    {
        return this._table.Insert(toCreate);
    }

    public StudentEntity Delete(int id)
    {
        return this._table.Delete(id);
    }

    public StudentEntity FindByEmail(string email)
    {
        return this._table.SelectByEmail(email);
    }

    public List<StudentEntity> GetAllStudents()
    {
        return this._table.SelectAll();
    }

    public StudentEntity GetStudent(int id)
    {
        return this._table.SelectById(id);
    }

    public StudentEntity Update(int id, StudentEntity toUpdate)
    {
        return this._table.Update(id, toUpdate);
    }
}