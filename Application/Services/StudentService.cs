using Hexagonality2.Domain;
using Hexagonality2.Domain.Entities;
using Hexagonality2.Domain.Interfaces;
using System.Text.RegularExpressions;

namespace Hexagonality2.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;

    public StudentService(IStudentRepository repository)
    {
        _repository = repository;
    }

    public bool IsEmailValid(string email)
    {
        const string pattern = @"@faculdade.edu$";
        return Regex.IsMatch(email, pattern);
    }
    public bool IsInDatabase(int id)
    {
        return (_repository.GetAllStudents().Find(s  => s.Id == id) != null);
    }

    public StudentDto Create(StudentEntity s)
    {
        try {
            if (IsInDatabase(s.Id))
                throw new Exception("Student is already registered!");

            if (String.IsNullOrEmpty(s.FirstName))
                throw new Exception("Must have name!");

            if (!IsEmailValid(s.Email))
                throw new Exception("Email must be valid!");
        } catch (Exception e) { throw new Exception(e.Message); }

        _repository.Create(s);

        return new StudentDto
        {
            FirstName = s.FirstName,
            Email = s.Email,
            CreatedAt = s.CreatedAt,
            UpdatedAt = s.UpdatedAt,
        };
    }

    public StudentDto Delete(int id)
    {
        StudentEntity s = null;

        try {
            if (!IsInDatabase(id))
                throw new Exception("a valid id must be given");
        }
        catch (Exception e) { throw new Exception(e.Message); }

        s = _repository.Delete(id);

        return new StudentDto
        {
            FirstName = s.FirstName,
            Email = s.Email,
            CreatedAt= s.CreatedAt,
            DeletedAt = s.DeletedAt
        };
    }

    // different of seaching with the Id: this function is for the user
    // the id one is internal and only is not private 'cause it will give
    // an error if it turns to private
    public StudentDto FindByEmail(string email)
    {
        StudentEntity s = null;

        try {
            s = _repository.FindByEmail(email);

            if (!IsEmailValid(email))
                throw new Exception("Email must be valid!");

            if (s == null)
               throw new Exception("Student not found");
        }
        catch(Exception e) { throw new Exception(e.Message); }

        return new StudentDto
        {
            FirstName = s.FirstName,
            Email = s.Email,
            CreatedAt = s.CreatedAt,
            UpdatedAt = s.UpdatedAt,
        };
    }

    public List<StudentDto> GetAllStudents()
    {
        List<StudentEntity> sts = _repository.GetAllStudents();
        List<StudentDto> dtos = new List<StudentDto>();

        foreach (var st in sts)
        {
            dtos.Add(new StudentDto
            {
                FirstName = st.FirstName,
                Email = st.Email,
                CreatedAt = st.CreatedAt,
                UpdatedAt = st.UpdatedAt,
            });
        }

        return dtos;
    }

    public StudentDto GetStudent(int id)
    {
        StudentEntity s = null;

        try {
            if (!IsInDatabase(id))
                throw new Exception("a valid id must be given");

            s = _repository.GetStudent(id);
        }
        catch (Exception e) { throw new Exception(e.Message); }

        return new StudentDto
        {
            FirstName = s.FirstName,
            Email = s.Email,
            CreatedAt = s.CreatedAt,
            UpdatedAt = s.UpdatedAt,
        };
    }

    public StudentDto Update(int id, StudentEntity studentToUpdate)
    {
        StudentEntity s = null;

        try
        {
            if (!IsInDatabase(id))
                throw new Exception("a valid id must be given");

            s = _repository.Update(id, studentToUpdate);
        }
        catch (Exception e) { throw new Exception(e.Message); }

        return new StudentDto
        {
            FirstName = s.FirstName,
            Email = s.Email,
            CreatedAt = s.CreatedAt,
            UpdatedAt = s.UpdatedAt,
        };
    }
}