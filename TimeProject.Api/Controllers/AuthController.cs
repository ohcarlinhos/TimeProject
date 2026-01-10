using Microsoft.AspNetCore.Mvc;
using TimeProject.Api.Controllers.Shared;
using TimeProject.Core.Application.Dtos.Auth;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.UseCases.Login;

namespace TimeProject.Api.Controllers;

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
    public async Task<ActionResult<JwtDto>> LoginGithub([FromBody] LoginGithubDto dto)
    {
        return HandleResponse(await loginGithubUseCase.Handle(dto, new UserAccessLogEntity
        {
            IpAddress = GetClientIpAddress(HttpContext) ?? "",
            UserAgent = Request.Headers.UserAgent.ToString(),
            AccessType = AccessType.Provider,
            Provider = "github"
        }));
    }

    [HttpPost]
    [Route("login/google")]
    public async Task<ActionResult<JwtDto>> LoginGoogle([FromBody] LoginGoogleDto dto)
    {
        return HandleResponse(await loginGoogleUseCase.Handle(dto, new UserAccessLogEntity
        {
            IpAddress = GetClientIpAddress(HttpContext) ?? "",
            UserAgent = Request.Headers.UserAgent.ToString(),
            AccessType = AccessType.Provider,
            Provider = "google"
        }));
    }
}