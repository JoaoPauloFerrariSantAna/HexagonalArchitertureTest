using Hexagonality2.Domain.Entities;

namespace Hexagonality2.Domain.Interfaces;

public interface IDatabaseRepository
{
    public StudentEntity Insert(StudentEntity toInsert);
    public StudentEntity Update(int id, StudentEntity toUpdate);
    public StudentEntity Delete(int id);
    public List<StudentEntity> SelectAll();
    public StudentEntity SelectById(int id);
    public StudentEntity SelectByEmail(string email);

    public bool IsEmailValid(string email);
    public bool IsEmailUnique(string email);
    public bool IsInDatabase(int id);
}