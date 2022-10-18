using Microsoft.AspNetCore.Mvc;
using desafio.Models;
using desafio.Service;
using desafio.Validator;
using FluentValidation.Results;
using FluentValidation;

namespace desafio.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectController : ControllerBase
{

    private readonly IProjectService _projectService;
    
    public ProjectController(IProjectService projectService){
        _projectService = projectService;
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        try {
            ProjectModel project = _projectService.getProject(id);
            return  Ok(project);
        } catch(Exception error) {
            return BadRequest(new {
                error = error,
                message = error.Message
             });
        }
    }

    [HttpPost]
    public IActionResult Add([FromBody] ProjectModel project)
    {
        try {
            ProjectValidator validator = new ProjectValidator(_projectService);
            validator.ValidateAndThrow(project);

            _projectService.addProject(project);
            return Ok(project);
        } catch(Exception error) {
            return BadRequest(new {
                error = error,
                message = error.Message
             });
        }
    }

    [HttpPut]
    public IActionResult Update([FromBody] ProjectModel project)
    
    {
        try {
            _projectService.updateProject(project);
            return Ok(project);
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
            _projectService.deleteProject(id);
            return Ok(id);
        } catch(Exception error) {
            return BadRequest(new {
                error = error,
                message = error.Message
             });
        }
    }
    
    [HttpGet("page/{page}")]
    public IActionResult GetAll(int page)
    {
        try {
            List<ProjectModel> projectsList = _projectService.getAllProjects(page);
            int pageCount = _projectService.pageCount();

            var response = new {
                projects = projectsList,
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
