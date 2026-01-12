using Microsoft.AspNetCore.Mvc;
using TimeProject.APIs.Controllers.Shared;
using TimeProject.Infrastructure.Entities;
using TimeProject.Infrastructure.Entities.Enums;
using TimeProject.Domain.UseCases.Login;
using TimeProject.Domain.RemoveDependencies.Dtos.Auth;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Infrastructure.ObjectValues.Auths;

namespace TimeProject.APIs.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(
    ILoginGithubUseCase loginGithubUseCase,
    ILoginGoogleUseCase loginGoogleUseCase
) : CustomController
{
    // [HttpPost, Route("login"), UserChallenge]
    // public async Task<ActionResult<JwtData>> Login([FromBody] LoginDto dto)
    // {
    //     return HandleResponse(await loginUseCase.Handle(dto, new UserAccessLogEntity
    //     {
    //         IpAddress = GetClientIpAddress(HttpContext) ?? "",
    //         UserAgent = Request.Headers.UserAgent.ToString(),
    //         AccessType = AccessType.Password
    //     }));
    // }

    [HttpPost]
    [Route("login/github")]
    public async Task<ActionResult<IJwtResult>> LoginGithub([FromBody] LoginGithubDto dto)
    {
        return HandleResponse(await loginGithubUseCase.Handle(dto, new UserAccessLog
        {
            IpAddress = GetClientIpAddress(HttpContext) ?? "",
            UserAgent = Request.Headers.UserAgent.ToString(),
            AccessType = AccessType.Provider,
            Provider = "github"
        }));
    }

    [HttpPost]
    [Route("login/google")]
    public async Task<ActionResult<IJwtResult>> LoginGoogle([FromBody] LoginGoogleDto dto)
    {
        return HandleResponse(await loginGoogleUseCase.Handle(dto, new UserAccessLog
        {
            IpAddress = GetClientIpAddress(HttpContext) ?? "",
            UserAgent = Request.Headers.UserAgent.ToString(),
            AccessType = AccessType.Provider,
            Provider = "google"
        }));
    }
}