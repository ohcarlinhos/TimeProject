using App.Infrastructure.Controllers;
using App.Infrastructure.Attributes;
using Core.Auth.UseCases;
using Entities;
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
        return HandleResponse(await loginUseCase.Handle(dto, new UserAccessLogEntity
        {
            IpAddress = GetClientIpAddress(HttpContext) ?? "",
            UserAgent = Request.Headers.UserAgent.ToString(),
            AccessType = AccessType.Password
        }));
    }

    [HttpPost, Route("login/github")]
    public async Task<ActionResult<JwtData>> LoginGithub([FromBody] LoginGithubDto dto)
    {
        return HandleResponse(await loginGithubUseCase.Handle(dto, new UserAccessLogEntity
        {
            IpAddress = GetClientIpAddress(HttpContext) ?? "",
            UserAgent = Request.Headers.UserAgent.ToString(),
            AccessType = AccessType.Provider,
            Provider = "github"
        }));
    }
}