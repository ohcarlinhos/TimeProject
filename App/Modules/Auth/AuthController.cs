using App.Infra.Controllers;
using Core.Auth.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Auth;
using Shared.General.Util;

namespace App.Modules.Auth;

[ApiController]
[Route("api/auth")]
public class AuthController(ILoginUseCase loginUseCase) : CustomController
{
    [HttpPost, Route("login")]
    public async Task<ActionResult<JwtData>> Login([FromBody] LoginDto dto)
    {
        return HandleResponse(await loginUseCase.Handle(dto));
    }

    [HttpPost, Route("panel")]
    public async Task<ActionResult<JwtData>> PanelLogin([FromBody] LoginDto dto)
    {
        return HandleResponse(await loginUseCase.Handle(dto, true));
    }
}