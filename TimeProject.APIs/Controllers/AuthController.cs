using Microsoft.AspNetCore.Mvc;
using TimeProject.APIs.Controllers.Shared;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Infrastructure.Database.Entities.Enums;
using TimeProject.Domain.UseCases.Logins;
using TimeProject.Domain.Dtos.Auths;
using TimeProject.Infrastructure.ObjectValues.Auths;
using TimeProject.APIs.Controllers.Attributes;

namespace TimeProject.APIs.Controllers;

[ApiController]
[Route("auth")]
public class AuthController(
    ILoginUseCase loginUseCase,
    ILoginGithubUseCase loginGithubUseCase,
    ILoginGoogleUseCase loginGoogleUseCase
) : CustomController
{
    [HttpPost, Route("login")]
    // [UserChallenge]
    public ActionResult<IJwtResult> Login([FromBody] LoginDto dto)
    {
        return HandleResponse(loginUseCase.Handle(dto, new UserAccessLog
        {
            IpAddress = GetClientIpAddress(HttpContext) ?? "",
            UserAgent = Request.Headers.UserAgent.ToString(),
            AccessType = AccessType.Password
        }));
    }

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