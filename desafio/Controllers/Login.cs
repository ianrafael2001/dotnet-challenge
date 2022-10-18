using desafio.Models;
using desafio.Repository;
using desafio.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace desafio.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase{

    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public IActionResult Login([FromBody] UserModel model)
    {
        UserModel user = UserRepository.Get(model.username, model.password);

        if (user == null) return BadRequest(new {
            message = "Usuário ou senha invalido"
        });

        var token = TokenService.generateToken(user);
        user.password = "";

        return Ok( new {
            user = user,
            token = token
        });
    }
}
