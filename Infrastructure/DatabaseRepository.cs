using Hexagonality2.Application.Domain.Entities;
using Hexagonality2.Application.Domain.Interfaces;

namespace Hexagonality2.Infrastructure;

public class DatabaseRepository : IDatabaseRepository
{
    private readonly DatabaseEntity _context;

    public DatabaseRepository(DatabaseEntity context)
    {
        _context = context;
    }

    public StudentEntity Delete(int id)
    {
        StudentEntity st = null;



        st = _context.Students.Find(s => s.Id == id);

        st.DeletedAt = DateTime.UtcNow;

        _context.Students.Remove(st);

        return st;
    }

    public StudentEntity Insert(StudentEntity toInsert)
    {
        _context.Students.Add(toInsert);
        return toInsert;
    }

    public bool IsEmailUnique(string email)
    {
        for (int i = 0; i < _context.Students.Count; i++)
        {
            if (_context.Students[i].Email == email)
                return false;
        }

        return true;
    }

    public bool IsInDatabase(int id)
    {
        for (int i = 0; i < _context.Students.Count; i++)
        {
            if (_context.Students[i].Id == id)
                return true;
        }

        return false;
    }

    public List<StudentEntity> SelectAll()
    {
        return _context.Students;
    }

    public StudentEntity SelectByEmail(string email)
    {
        return _context.Students.Find(s => s.Email == email);
    }

    public StudentEntity SelectById(int id)
    {
        return _context.Students.Find(s => s.Id == id);
    }

    public StudentEntity Update(int id, StudentEntity toUpdate)
    {
        StudentEntity st = null;

        for (int i = 0; i < _context.Students.Count; i++)
        {
            if (_context.Students[i].Id == id)
            {
                _context.Students[i].UpdatedAt = DateTime.UtcNow;
                st = _context.Students[i];
            }
        }

        return st;
    }
}