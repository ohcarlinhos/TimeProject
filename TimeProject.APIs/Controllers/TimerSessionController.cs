using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.APIs.Controllers.Shared;
using TimeProject.Domain.UseCases.Sessions;
using TimeProject.Infrastructure.Utils;

namespace TimeProject.APIs.Controllers;

[ApiController]
[Route("api/sessions")]
[Authorize(Policy = "IsActive")]
public class TimerSessionController(IDeleteSessionUseCase deleteSessionUseCase) : CustomController
{
    [HttpDelete]
    [Route("{id:int}")]
    public ActionResult<bool> Delete(int id)
    {
        return HandleResponse(deleteSessionUseCase.Handle(id, UserClaimsUtil.Id(User)));
    }
}