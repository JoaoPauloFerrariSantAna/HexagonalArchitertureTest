using Hexagonality2.Application.Domain;
using Hexagonality2.Application.Domain.Entities;
using Hexagonality2.Application.Domain.Interfaces;

namespace Hexagonality2.Application;

public class DatabaseService : IDatabaseService
{
    private readonly IDatabaseRepository _database;

    public DatabaseService(IDatabaseRepository database)
    {
        _database = database;
    }

    public StudentEntity Create(StudentEntity toInsert)
    {
        StudentEntity st = null;

        if (toInsert == null)
            throw new Exception("Student data must be send");

        if (_database. IsInDatabase(toInsert.Id))
            throw new Exception("Student already exits");

        if (_database.IsEmailUnique(toInsert.Email))
            throw new Exception("Student is already exists with this email!");

        return _database.Insert(toInsert);
    }

    public StudentEntity Delete(int id)
    {
        StudentEntity st = null;

        if (_database.IsInDatabase(id))
            throw new Exception("Student not in database");

        st = _database.Delete(id);
        
        return st;
    }

    public StudentEntity FindByEmail(string email)
    {
        StudentEntity st = _database.SelectByEmail(email);
        
        if (st == null)
            throw new Exception("Student does not exists");
        
        return st;
    }

    public List<StudentEntity> GetAllStudents()
    {
        return _database.SelectAll();
    }

    public StudentEntity GetStudent(int id)
    {
        return _database.SelectById(id);
    }

    public StudentEntity Update(int id, StudentEntity toUpdate)
    {
        if (!_database.IsInDatabase(id))
            throw new Exception("Student does not exits");

        return _database.Update(id, toUpdate);
    }
}