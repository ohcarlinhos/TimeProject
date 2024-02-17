using Microsoft.AspNetCore.Mvc;
using PomodoroAPI.Infrastructure.Services;
using PomodoroAPI.Modules.Auth.Models;
using PomodoroAPI.Modules.Usuario.Repositories;

namespace PomodoroAPI.Modules.Auth.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public AuthController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpPost, Route("login")]
    public async Task<IActionResult> Login([FromBody] CredenciaisModelView credenciais)
    {
        var usuarioDb = await _usuarioRepository.FindByEmail(credenciais.Email);

        if (usuarioDb == null || usuarioDb.Senha != credenciais.Senha)
            throw new Exception($"Email ou senha incorretos");

        return Ok(TokenService.GenerateBearerJwt(usuarioDb));
    }
}