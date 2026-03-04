using System.Text.RegularExpressions;
using Hexagonality2.Domain.Entities;
using Hexagonality2.Domain.Interfaces;

namespace Hexagonality2.Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
    public static List<StudentEntity> _database { get; set; } = new List<StudentEntity>();

    

    public StudentEntity Create(StudentEntity toCreate)
    {
        _database.Add(toCreate);

        return toCreate;
    }

    public StudentEntity Delete(int id)
    {
        StudentEntity s = _database.Find(st => st.Id == id);

        _database.Remove(s);

        return s;
    }

    public StudentEntity FindByEmail(string email)
    {
        return _database.Find(st => st.Email == email);
    }

    public List<StudentEntity> GetAllStudents()
    {
        return _database;
    }

    public StudentEntity GetStudent(int id)
    {
        return _database.Find(st => st.Id == id);
    }

    public StudentEntity Update(int id, StudentEntity toUpdate)
    {
        StudentEntity s = null;
        
        for (int i = 0; i < _database.Count; i++)
        {
            if (_database[i].Id == id)
            {
                _database[i] = toUpdate;
                _database[i].UpdatedAt = DateTime.UtcNow;
                s = _database[i];
            }
        }

        return s;
    }
}
