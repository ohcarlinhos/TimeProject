using API.Infrastructure.Services;
using API.Modules.Shared;
using API.Modules.Shared.Controllers;
using API.Modules.TimeRecord.Dto;
using API.Modules.TimeRecord.Map;
using API.Modules.TimeRecord.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.TimeRecord.Controllers;

[ApiController]
[Route("api/time-record")]
public class TimeRecordController(ITimeRecordServices timeRecordServices) : CustomController
{
    [HttpGet, Authorize]
    public async Task<ActionResult<Pagination<TimeRecordMap>>> Index(int page = 1, int perPage = 4,
        string search = "", string orderBy = "", string sort = "desc")
    {
        var result = await timeRecordServices
            .Index(UserSession.Id(User), page, perPage, search, orderBy, sort);

        return HandleResponse(result);
    }

    [HttpPost, Authorize]
    public async Task<ActionResult<TimeRecordMap>> Create([FromBody] CreateTimeRecordDto dto)
    {
        var result = await timeRecordServices
            .Create(dto, UserSession.Id(User));

        return HandleResponse(result);
    }

    [HttpPut, Authorize, Route("{id}")]
    public async Task<ActionResult<TimeRecordMap>> Update(int id, [FromBody] UpdateTimeRecordDto dto)
    {
        var result = await timeRecordServices
            .Update(id, dto, UserSession.Id(User));

        return HandleResponse(result);
    }

    [HttpGet, Authorize, Route("{id}")]
    public async Task<ActionResult<TimeRecordMap>> Details(int id)
    {
        var result = await timeRecordServices
            .Details(id, UserSession.Id(User));

        return HandleResponse(result);
    }

    [HttpDelete, Authorize, Route("{id}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        var result = await timeRecordServices
            .Delete(id, UserSession.Id(User));

        return HandleResponse(result);
    }
}