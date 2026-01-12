using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.APIs.Controllers.Shared;
using TimeProject.Domain.UseCases.Sessions;
using TimeProject.Domain.RemoveDependencies.Util;

namespace TimeProject.APIs.Controllers;

[ApiController]
[Route("api/sessions")]
[Authorize(Policy = "IsActive")]
public class TimerSessionController(IDeleteTimerSessionUseCase deleteTimerSessionUseCase) : CustomController
{
    [HttpDelete]
    [Route("{id:int}")]
    public ActionResult<bool> Delete(int id)
    {
        return HandleResponse(deleteTimerSessionUseCase.Handle(id, UserClaims.Id(User)));
    }
}