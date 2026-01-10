using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.Api.Controllers.Shared;
using TimeProject.Domain.Entities;
using TimeProject.Domain.UseCases.TimeRecord;

namespace TimeProject.Api.Controllers;

[ApiController]
[Route("api/records/meta")]
[Authorize(Policy = "IsAdmin")]
public class TimeRecordMetaController(
    ISyncAllTrMetaUseCase syncAllTrMetaUseCase
) : CustomController
{
    [HttpPost]
    [Route("sync/all")]
    public async Task<ActionResult<IEnumerable<TimeRecordMetaEntity>>> SyncAll()
    {
        return HandleResponse(await syncAllTrMetaUseCase.Handle());
    }
}