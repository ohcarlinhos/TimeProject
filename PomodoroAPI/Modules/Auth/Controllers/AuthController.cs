using Microsoft.AspNetCore.Mvc;
using PomodoroAPI.Infrastructure.Services;
using PomodoroAPI.Modules.Auth.Models;
using PomodoroAPI.Modules.Auth.Services;
using PomodoroAPI.Modules.Usuario.Repositories;

namespace PomodoroAPI.Modules.Auth.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost, Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await authService.Login(request);
        if (result.HasError) return BadRequest(result.Message);
        return Ok(result.Data);
    }
}