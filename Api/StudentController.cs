using Microsoft.AspNetCore.Mvc;
using Hexagonality2.Domain;
using Hexagonality2.Domain.Entities;
using Hexagonality2.Domain.Interfaces;

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
        StudentDto s = null;

        try { s = this._service.GetStudent(id); }
        catch (Exception e) { return BadRequest(e.Message); }

        return Ok(s);
    }

    [HttpGet("/email:string")]
    public IActionResult GetStudentByEmail(string email)
    {
        StudentDto s = null;

        try { s = this._service.FindByEmail(email); }
        catch (Exception e) { return BadRequest(e.Message); }

        return Ok(s);
    }

    [HttpPut("/id:int")]
    public IActionResult UpdateStudent(int id, [FromBody] StudentEntity toUpdate)
    {
        StudentDto s = null;

        try { s = this._service.Update(id, toUpdate); }
        catch (Exception e) { return BadRequest(e.Message); }

        return Ok(s);
    }

    [HttpPost()]
    public IActionResult PostStudent([FromBody] StudentEntity toCreate)
    {
        StudentDto s = null;

        try { s = this._service.Create(toCreate); }
        catch (Exception e) { return BadRequest(e.Message); }
        
        return CreatedAtAction(nameof(PostStudent), s);
    }

    [HttpDelete()]
    public IActionResult DeleteStudent(int id)
    {
        StudentDto s = null;

        try { s = this._service.Delete(id); }
        catch (Exception e) { return BadRequest(e.Message); }

        return Ok(s);
    }
}