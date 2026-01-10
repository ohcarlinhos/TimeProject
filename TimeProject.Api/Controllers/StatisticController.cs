using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.Api.Controllers.Shared;
using TimeProject.Core.Domain.UseCases.Statistic;
using TimeProject.Core.RemoveDependencies.Dtos.Statistic;
using TimeProject.Core.RemoveDependencies.General.Util;

namespace TimeProject.Api.Controllers;

[ApiController]
[Route("api/statistics")]
[Authorize(Policy = "IsActive")]
public class StatisticController(IGetRangeDaysStatisticUseCase getRangeDaysStatisticUseCase) : CustomController
{
    [HttpGet]
    [Route("day")]
    public async Task<ActionResult<RangeStatistic>> Day([FromQuery] DateTime? date)
    {
        return HandleResponse(await getRangeDaysStatisticUseCase.Handle(UserClaims.Id(User), date));
    }

    [HttpGet]
    [Route("{timeRecordId:int}/day")]
    public async Task<ActionResult<RangeStatistic>> Day(int timeRecordId, [FromQuery] DateTime? date)
    {
        return HandleResponse(await getRangeDaysStatisticUseCase.Handle(UserClaims.Id(User), date, null, timeRecordId));
    }

    [HttpGet]
    [Route("range")]
    public async Task<ActionResult<RangeStatisticsWithDays>> Range([FromQuery] DateTime start, [FromQuery] DateTime end)
    {
        return HandleResponse(await getRangeDaysStatisticUseCase.Handle(UserClaims.Id(User), start, end));
    }
}