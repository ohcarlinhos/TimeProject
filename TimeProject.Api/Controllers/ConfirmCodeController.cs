using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.Api.Controllers.Shared;
using TimeProject.Core.Application.Dtos.Codes;
using TimeProject.Core.Application.General.Util;
using TimeProject.Core.Domain.UseCases.Code;

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