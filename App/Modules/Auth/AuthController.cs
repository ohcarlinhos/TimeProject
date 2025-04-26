using App.Infrastructure.Controllers;
using App.Infrastructure.Attributes;
using App.Modules.Auth.UseCases;
using Core.Auth.UseCases;
using Microsoft.AspNetCore.Mvc;
using Shared.Auth;

namespace App.Modules.Auth;

[ApiController]
[Route("api/auth")]
public class AuthController(ILoginUseCase loginUseCase, ILoginGithubUseCase loginGithubUseCase) : CustomController
{
    [HttpPost, Route("login"), UserChallenge]
    public async Task<ActionResult<JwtData>> Login([FromBody] LoginDto dto)
    {
        return HandleResponse(await loginUseCase.Handle(dto));
    }
    
    [HttpPost, Route("login/github")]
    public async Task<ActionResult<JwtData>> LoginGithub([FromBody] LoginGithubDto dto)
    {
        return HandleResponse(await loginGithubUseCase.Handle(dto));
    }
}