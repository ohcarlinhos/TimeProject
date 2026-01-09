using Core.TimerSession.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.General.Util;
using TimeProject.Api.Infrastructure.Controllers;

namespace TimeProject.Api.Modules.TimerSession;

[ApiController]
[Route("api/sessions")]
[Authorize(Policy = "IsActive")]
public class TimerSessionController(IDeleteTimerSessionUseCase deleteTimerSessionUseCase) : CustomController
{
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        return HandleResponse(await deleteTimerSessionUseCase.Handle(id, UserClaims.Id(User)));
    }
}