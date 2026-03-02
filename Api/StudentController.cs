using Microsoft.AspNetCore.Mvc;
using Hexagonality2.Application.Domain.Interfaces;
using Hexagonality2.Application.Domain;
using Hexagonality2.Application.Domain.Entities;

namespace Hexagonalilty.Api;

[ApiController()]
[Route("/api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService  _service;

    public StudentController(IStudentService service)
    {
        this._service = service;
    }

    [HttpGet()]
    public IActionResult GetAllUsers()
    {
        return Ok(this._service.GetAllStudents());
    }

    [HttpGet("/id:int")]
    public IActionResult GetStudentById(int id)
    {
        StudentDto student = null;

        try { student = this._service.GetStudent(id); }
        catch (Exception e) { return BadRequest(e.Message); };
        return Ok(student);
    }

    [HttpGet("/email:string")]
    public IActionResult GetStudentByEmail(string email)
    {
        StudentDto student = this._service.FindByEmail(email);
        return Ok(student);
    }

    [HttpPut("/id:int")]
    public IActionResult UpdateStudent(int id, [FromBody] StudentEntity studentToUpdate)
    {
        StudentDto student = this._service.Update(id, studentToUpdate);
        return Ok(student);
    }

    [HttpPost()]
    public IActionResult PostStudent([FromBody] StudentEntity studentToCreate)
    {
        StudentDto student = this._service.Create(studentToCreate);
        return CreatedAtAction(nameof(PostStudent), student);
    }

    [HttpDelete()]
    public IActionResult DeleteStudent(int id)
    {
        StudentDto student = this._service.Delete(id);
        return Ok(student);
    }
}