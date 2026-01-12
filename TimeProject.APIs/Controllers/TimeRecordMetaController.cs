using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.APIs.Controllers.Shared;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.UseCases.TimeRecord;

namespace TimeProject.APIs.Controllers;

[ApiController]
[Route("api/records/meta")]
[Authorize(Policy = "IsAdmin")]
public class TimeRecordMetaController(
    ISyncAllTrMetaUseCase syncAllTrMetaUseCase
) : CustomController
{
    [HttpPost]
    [Route("sync/all")]
    public ActionResult<IEnumerable<IRecordMeta>> SyncAll()
    {
        return HandleResponse(syncAllTrMetaUseCase.Handle());
    }
}