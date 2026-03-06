using Hexagonality2.Domain.Entities;
using Hexagonality2.Domain.Interfaces;

namespace Hexagonality2.Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
    public static List<StudentEntity> _database { get; set; } = new List<StudentEntity>();    

    public StudentEntity Delete(int id)
    {
        StudentEntity s = GetStudent(id);
        _database.Remove(s);
        return s;
    }

    public StudentEntity FindByEmail(string email)
    {
        return _database.Find(st => st.Email == email);
    }
    public StudentEntity GetStudent(int id)
    {
        return _database.Find(st => st.Id == id);
    }

    public List<StudentEntity> GetAllStudents()
    {
        return _database;
    }

    public StudentEntity Create(StudentEntity toCreate)
    {
        _database.Add(toCreate);
        return toCreate;
    }

    public StudentEntity Update(int id, StudentEntity toUpdate)
    {
        StudentEntity s = null;
        
        // i'm weary of using a foreach here :v
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