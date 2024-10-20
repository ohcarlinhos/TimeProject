using API.Core.Auth.UseCases;
using API.Infra.Controllers;
using Microsoft.AspNetCore.Mvc;
using Shared.Auth;

namespace API.Modules.Auth;

[ApiController]
[Route("api/auth")]
public class AuthController(
    ILoginUseCase loginUseCase,
    ISendRecoveryEmailUseCase sendRecoveryEmailUseCase,
    IRecoveryPasswordUseCase recoveryPasswordUseCase) : CustomController
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

    [HttpPost, Route("recovery")]
    public async Task<ActionResult<bool>> Recovery([FromBody] RecoveryDto dto)
    {
        return HandleResponse(await sendRecoveryEmailUseCase.Handle(dto));
    }

    [HttpPost, Route("recovery/password")]
    public async Task<ActionResult<bool>> RecoveryPassword([FromBody] RecoveryPasswordDto dto)
    {
        return HandleResponse(await recoveryPasswordUseCase.Handle(dto));
    }
}