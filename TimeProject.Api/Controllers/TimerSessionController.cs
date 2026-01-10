using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.Api.Controllers.Shared;
using TimeProject.Core.Application.General.Util;
using TimeProject.Core.Domain.UseCases.TimerSession;

namespace TimeProject.Api.Controllers;

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