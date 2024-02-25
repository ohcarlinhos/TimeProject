using Microsoft.AspNetCore.Mvc;
using PomodoroAPI.Modules.Auth.Models;
using PomodoroAPI.Modules.Auth.Services;
using PomodoroAPI.Modules.Shared.Controllers;

namespace PomodoroAPI.Modules.Auth.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IAuthService authService) : CustomController
{
    [HttpPost, Route("login")]
    public async Task<ActionResult<object>> Login([FromBody] LoginModel model)
    {
        return HandleResponse(await authService.Login(model));
    }
}