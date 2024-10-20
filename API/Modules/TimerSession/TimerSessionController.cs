using API.Core.TimerSession.UseCases;
using API.Infra.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.General.Util;

namespace API.Modules.TimerSession;

[ApiController, Route("api/session")]
public class TimerSessionController(IDeleteTimerSessionUseCase deleteTimerSessionUseCase) : CustomController
{
    [HttpDelete, Authorize, Route("{id:int}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        return HandleResponse(await deleteTimerSessionUseCase.Handle(id, UserClaims.Id(User)));
    }
}