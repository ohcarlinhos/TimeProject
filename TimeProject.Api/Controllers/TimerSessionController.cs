using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.Api.Controllers.Shared;
using TimeProject.Domain.UseCases.TimerSession;
using TimeProject.Domain.RemoveDependencies.Util;

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