using Hexagonality2.Application.Domain.Entities;

namespace Hexagonality2.Application.Domain.Interfaces;

public interface IDatabaseRepository
{
    public StudentEntity Insert(StudentEntity toInsert);
    public StudentEntity Update(int id, StudentEntity toUpdate);
    public StudentEntity Delete(int id);
    public List<StudentEntity> SelectAll();
    public StudentEntity SelectById(int id);
    public StudentEntity SelectByEmail(string email);

    public bool IsEmailUnique(string email);
    public bool IsInDatabase(int id);
}