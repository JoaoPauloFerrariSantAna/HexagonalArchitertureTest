using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Hexagonality2.Application.Domain.Interfaces;

namespace Hexagonality2.Application.Domain;

public class StudentRepository : IStudentRepository
{
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Name is obligatory")]
    [NotNull()]
    [Length(minimumLength: 1, maximumLength: 50)]
    public string FirstName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    // NOTE: temporary solution
    private static List<StudentRepository> students = new List<StudentRepository>();

    private StudentRepository SearchForUser(int id)
    {
        StudentRepository student = null;

        foreach (var currentStudent in students)
        {
            if (currentStudent.Id == id)
                student = currentStudent;
        }

        return student;
    }

    private StudentRepository UpdateUser(int id, StudentRepository datoToUpdate)
    {
        StudentRepository student = null;

        for (int i = 0; i < students.Count; i++)
        {
            if (students[i].Id == id)
            {
                students[i] = datoToUpdate;
                students[i].UpdatedAt = DateTime.UtcNow;
                // because i want to to retun back to the user
                student = students[i];
            }
        }

        return student;
    }

    public StudentRepository Create(StudentRepository studentToAdd)
    {
        if (studentToAdd == null)
            throw new Exception("Student data must be send");

        // student is in db
        if (this.SearchForUser(studentToAdd.Id) != null) 
            throw new Exception("User already exists");

        // NOTE: we do not need to keep an reference of `userToAdd`
        // at least for now, where there is no DTO at the moment
        students.Add(studentToAdd);

        return studentToAdd;
    }

    public StudentRepository Delete(int id)
    {
        StudentRepository student = this.SearchForUser(id);

        if (student == null)
            throw new Exception("User not found");

        students.Remove(student);
        student.DeletedAt = DateTime.UtcNow;

        return student;
    }

    public void FindByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public StudentRepository Update(int id, StudentRepository studentToUpdate)
    {
        StudentRepository student = null;

        if (studentToUpdate == null)
            throw new Exception("Student data must be send");

        if(this.SearchForUser(id) == null)
            throw new Exception("Student not found");

        student = this.UpdateUser(id, studentToUpdate);

        return student;
    }

    public List<StudentRepository> GetAllStudents()
    {
        return students;
    }

    public StudentRepository GetStudent(int id)
    {
        StudentRepository student = this.SearchForUser(id);

        if (student == null)
            throw new Exception("User not found");

        return student;
    }
}