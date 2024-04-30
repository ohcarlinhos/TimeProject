using API.Infrastructure.Services;
using API.Modules.Shared.Controllers;
using API.Modules.TimeRecord.DTO;
using API.Modules.TimeRecord.Models;
using API.Modules.TimeRecord.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.TimeRecord.Controllers;

[ApiController]
[Route("api/time-record")]
public class TimeRecordController(ITimeRecordServices timeRecordServices) : CustomController
{
    [HttpGet, Authorize]
    public ActionResult<List<TimeRecordDto>> Index(int page = 1, int perPage = 12)
    {
        var result = timeRecordServices
            .Index(AuthorizeService.GetUserId(User), page, perPage);

        return HandleResponse(result);
    }

    [HttpPost, Authorize]
    public async Task<ActionResult<TimeRecordDto>> Create([FromBody] CreateTimeRecordModel model)
    {
        var result = await timeRecordServices
            .Create(model, AuthorizeService.GetUserId(User));

        return HandleResponse(result);
    }

    [HttpPut, Authorize, Route("{id}")]
    public async Task<ActionResult<TimeRecordDto>> Update(int id, [FromBody] UpdateTimeRecordModel model)
    {
        var result = await timeRecordServices
            .Update(id, model, AuthorizeService.GetUserId(User));

        return HandleResponse(result);
    }
    
    [HttpGet, Authorize, Route("{id}")]
    public async Task<ActionResult<TimeRecordDto>> Details(int id)
    {
        
        var result = await timeRecordServices
            .Details(id, AuthorizeService.GetUserId(User));

        return HandleResponse(result);
    }

    [HttpDelete, Authorize, Route("{id}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        var result = await timeRecordServices
            .Delete(id, AuthorizeService.GetUserId(User));

        return HandleResponse(result);
    }
}