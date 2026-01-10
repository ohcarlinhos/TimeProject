using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.Api.Controllers.Shared;
using TimeProject.Domain.UseCases.Code;
using TimeProject.Domain.RemoveDependencies.Dtos.Codes;
using TimeProject.Domain.RemoveDependencies.Util;

namespace TimeProject.Api.Controllers;

[ApiController]
[Route("api/codes")]
public class ConfirmCodeController(IGetRegisterCodeInfoUseCase getRegisterCodeInfoUseCase) : CustomController
{
    [HttpGet]
    [Route("register/info")]
    [Authorize]
    public async Task<ActionResult<ConfirmCodeOutDto>> HasVerifyCodeActive()
    {
        return HandleResponse(await getRegisterCodeInfoUseCase.Handle(UserClaims.Id(User)));
    }
}