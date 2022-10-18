using Microsoft.AspNetCore.Mvc;
using desafio.Models;
using desafio.Service;
using Microsoft.AspNetCore.Authorization;

namespace desafio.Controllers;

[ApiController]
[Route("[controller]")]
public class MemberController : ControllerBase
{

    private readonly IMemberService _memberService;
    
    public MemberController(IMemberService memberService){
        _memberService = memberService;
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        try {
            MemberModel member = _memberService.getMember(id);
            return  Ok(member);
        } catch(Exception error) {
            return BadRequest(new {
                error = error,
                message = error.Message
             });
        }
    }

    [HttpPost]    
    [Authorize(Roles = "admin")]
    public IActionResult Add([FromBody] MemberModel member)
    {
        try {
            _memberService.addMember(member);
            return Ok(member);
        } catch(Exception error) {
            return BadRequest(new {
                error = error,
                message = error.Message
             });
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public IActionResult Delete(int id)
    {
        try {
            _memberService.deleteMember(id);
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
    public IActionResult GetAll(int page)
    {
        try {
            List<MemberModel> membersList = _memberService.getAllMembers(page);
            int pageCount = _memberService.pageCount();

            var response = new {
                members = membersList,
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
