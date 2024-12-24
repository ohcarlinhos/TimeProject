using App.Infra.Controllers;
using Core.Auth.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Auth;
using Shared.General.Util;

namespace App.Modules.Auth;

[ApiController]
[Route("api/auth")]
public class AuthController(
    ILoginUseCase loginUseCase,
    ISendRecoveryEmailUseCase sendRecoveryEmailUseCase,
    IRecoveryPasswordUseCase recoveryPasswordUseCase,
    ISendRegisterEmailUseCase sendRegisterEmailUseCase,
    IVerifyUserUseCase verifyUserUseCase) : CustomController
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
        return HandleResponse(await sendRecoveryEmailUseCase.Handle(dto.Email));
    }

    [HttpPost, Route("recovery/password")]
    public async Task<ActionResult<bool>> RecoveryPassword([FromBody] RecoveryPasswordDto dto)
    {
        return HandleResponse(await recoveryPasswordUseCase.Handle(dto));
    }

    [HttpPost, Route("verify")]
    [Authorize(Policy = "IsActiveAndVerified")]
    public async Task<ActionResult<bool>> Verify()
    {
        return HandleResponse(await sendRegisterEmailUseCase.Handle(UserClaims.Email(User)));
    }

    [HttpPost, Route("verify/{code}")]
    [Authorize(Policy = "IsActiveAndVerified")]
    public async Task<ActionResult<bool>> VerifyUser(string code)
    {
        return HandleResponse(await verifyUserUseCase.Handle(UserClaims.Id(User), UserClaims.Email(User), code));
    }
}