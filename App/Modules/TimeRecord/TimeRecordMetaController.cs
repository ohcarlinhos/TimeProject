using Core.TimeRecord.UseCases;
using App.Infrastructure.Controllers;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.TimeRecord;

[ApiController]
[Route("api/records/meta"), Authorize(Policy = "IsAdmin")]
public class TimeRecordMetaController(
    ISyncAllTrMetaUseCase syncAllTrMetaUseCase
) : CustomController
{
    [HttpPost, Route("sync/all")]
    public async Task<ActionResult<IEnumerable<TimeRecordMetaEntity>>> SyncAll()
    {
        return HandleResponse(await syncAllTrMetaUseCase.Handle());
    }
}