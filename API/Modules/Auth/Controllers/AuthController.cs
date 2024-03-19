using API.Modules.Auth.Models;
using API.Modules.Auth.Services;
using API.Modules.Shared.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Auth.Controllers;

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