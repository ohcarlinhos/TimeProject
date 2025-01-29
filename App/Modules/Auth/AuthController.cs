using App.Infrastructure.Controllers;
using App.Infrastructure.Attributes;
using Core.Auth.UseCases;
using Microsoft.AspNetCore.Mvc;
using Shared.Auth;

namespace App.Modules.Auth;

[ApiController]
[Route("api/auth")]
public class AuthController(ILoginUseCase loginUseCase) : CustomController
{
    [HttpPost, Route("login"), UserChallenge]
    public async Task<ActionResult<JwtData>> Login([FromBody] LoginDto dto)
    {
        return HandleResponse(await loginUseCase.Handle(dto));
    }

    [HttpPost, Route("login/panel")]
    public async Task<ActionResult<JwtData>> PanelLogin([FromBody] LoginDto dto)
    {
        return HandleResponse(await loginUseCase.Handle(dto, true));
    }
}