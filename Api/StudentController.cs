using Microsoft.AspNetCore.Mvc;
using Hexagonality2.Application.Domain.Interfaces;
using Hexagonality2.Application.Domain;

namespace Hexagonalilty.Api;

[ApiController()]
[Route("/api/[controller]")]
public class StudentController : ControllerBase
{
    // TODO: change later to IStudentService
    private readonly IStudentRepository _repository;

    public StudentController(IStudentRepository repository)
    {
        this._repository = repository;
    }

    [HttpGet()]
    public IActionResult GetAllUsers()
    {
        return Ok(this._repository.GetAllStudents());
    }

    [HttpGet("/id:int")]
    public IActionResult GetStudent(int id)
    {
        StudentRepository student = null;

        try
        {
            student = this._repository.GetStudent(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok(student);
    }
}
