using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.APIs.Controllers.Shared;
using TimeProject.Domain.UseCases.Code;
using TimeProject.Domain.RemoveDependencies.Dtos.Codes;
using TimeProject.Domain.RemoveDependencies.Util;

namespace TimeProject.APIs.Controllers;

[ApiController]
[Route("api/codes")]
public class ConfirmCodeController(IGetRegisterCodeInfoUseCase getRegisterCodeInfoUseCase) : CustomController
{
    [HttpGet]
    [Route("register/info")]
    [Authorize]
    public ActionResult<IConfirmCodeOutDto> HasVerifyCodeActive()
    {
        return HandleResponse(getRegisterCodeInfoUseCase.Handle(UserClaims.Id(User)));
    }
}