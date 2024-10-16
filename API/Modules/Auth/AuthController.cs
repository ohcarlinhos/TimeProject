using API.Core.Auth;
using API.Modules.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using Shared.Auth;

namespace API.Modules.Auth;

[ApiController]
[Route("api/auth")]
public class AuthController(IAuthService authService) : CustomController
{
    [HttpPost, Route("login")]
    public async Task<ActionResult<JwtData>> Login([FromBody] LoginDto dto)
    {
        return HandleResponse(await authService.Login(dto));
    }

    [HttpPost, Route("panel")]
    public async Task<ActionResult<JwtData>> PanelLogin([FromBody] LoginDto dto)
    {
        return HandleResponse(await authService.Login(dto, true));
    }

    [HttpPost, Route("recovery")]
    public async Task<ActionResult<bool>> Recovery([FromBody] RecoveryDto dto)
    {
        return HandleResponse(await authService.Recovery(dto));
    }

    [HttpPost, Route("recovery/password")]
    public async Task<ActionResult<bool>> RecoveryPassword([FromBody] RecoveryPasswordDto dto)
    {
        return HandleResponse(await authService.RecoveryPassword(dto));
    }
}