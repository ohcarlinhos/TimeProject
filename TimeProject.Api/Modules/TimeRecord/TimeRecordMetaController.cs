using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.Api.Infrastructure.Controllers;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.UseCases.TimeRecord;

namespace TimeProject.Api.Modules.TimeRecord;

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