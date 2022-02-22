using D10.Models;
using D10.Services;
using Microsoft.AspNetCore.Mvc;

namespace D10.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly ILogger<StudentController> _logger;
    private readonly IStudentService _studentService;

    public StudentController(ILogger<StudentController> logger, IStudentService studentService)
    {
        _logger = logger;
        _studentService = studentService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var entities = _studentService.GetAll();
        var results = from item in entities
                      select new StudentViewModel
                      {
                          Id = item.StudentId,
                          FullName = $"{item.LastName} {item.FirstName}",
                          City = item.City
                      };
        return new JsonResult(entities);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetOne(int id)
    {
        var entity = _studentService.GetOne(id);
        if (entity == null) return NotFound();

        return new JsonResult(new StudentViewModel
        {
            Id = entity.StudentId,
            FullName = $"{entity.LastName} {entity.FirstName}",
            City = entity.City
        });
    }

    [HttpPost]
    public IActionResult Create(StudentCreateModel model)
    {
        try
        {
            var entity = new Data.Entites.Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                City = model.City,
                State = model.State
            };

            var result = _studentService.Add(entity);
            return new JsonResult(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, StudentCreateModel model)
    {
        try
        {
            var entity = _studentService.GetOne(id);
            if (entity == null) return NotFound();

            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.City = model.City;

            _studentService.Edit(id, entity);
            return new JsonResult(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var entity = _studentService.GetOne(id);
            if (entity == null) return NotFound();

            _studentService.Remove(id, entity);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}