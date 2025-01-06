using App.Infrastructure.Controllers;
using Core.Codes.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Codes;
using Shared.General.Util;

namespace App.Modules.Codes.Controllers;

[ApiController]
[Route("api/confirm-code")]
public class ConfirmCodeController(IGetRegisterCodeInfoUseCase getRegisterCodeInfoUseCase) : CustomController
{
    [HttpGet, Route("register/info"), Authorize]
    public async Task<ActionResult<ConfirmCodeMap>> HasVerifyCodeActive()
    {
        return HandleResponse(await getRegisterCodeInfoUseCase.Handle(UserClaims.Id(User)));
    }
}