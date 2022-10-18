using Microsoft.AspNetCore.Mvc;
using desafio.Models;
using desafio.Service;
using desafio.Validator;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace desafio.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{

    private readonly IEmployeeService _employeeService;
    
    public EmployeeController(IEmployeeService employeeService){
        _employeeService = employeeService;
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        try {
            EmployeeModel employee = _employeeService.getEmployee(id);
            return  Ok(employee);
        } catch(Exception error) {
            return BadRequest(new {
                error = error,
                message = error.Message
             });
        }
    }

    [HttpPost]
    public IActionResult Add([FromBody] EmployeeModel employee)
    {
        try {
            EmployeeValidator validator = new EmployeeValidator();
            validator.ValidateAndThrow(employee);

            _employeeService.addEmployee(employee);
            return Ok(employee);
        } catch(Exception error) {
            return BadRequest(new {
                error = error,
                message = error.Message
             });
        }
    }

    [HttpPut]
    public IActionResult Update([FromBody] EmployeeModel employee)
    {
        try {

            _employeeService.updateEmployee(employee);
            return Ok(employee);
        } catch(Exception error) {
            return BadRequest(new {
                error = error,
                message = error.Message
             });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try {
            _employeeService.deleteEmployee(id);
            return Ok(id);
        }
        catch(Exception error) {
            return BadRequest(new {
                error = error,
                message = error.Message
             });
        }
    }

    [HttpGet("page/{page}")]
    [Authorize]
    public IActionResult GetAll(int page)
    {
        try {
            List<EmployeeModel> employeesList = _employeeService.getAllEmployees(page);
            int pageCount = _employeeService.pageCount();

            var response = new {
                employees = employeesList,
                page = page,
                pageCount = pageCount,
            };

            return  Ok(response);
        } catch(Exception error) {
            return BadRequest(new {
                error = error,
                message = error.Message
             });
        }
    }
}
