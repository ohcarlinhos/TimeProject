using Core.Statistic.UseCases;
using App.Infrastructure.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.General.Util;
using Shared.Statistic;

namespace App.Modules.Statistic;

[ApiController, Route("api/statistics")]
[Authorize(Policy = "IsActive")]
public class StatisticController(IGetDayStatisticUseCase getDayStatisticUseCase) : CustomController
{
    [HttpGet, Route("day")]
    public async Task<ActionResult<DayStatistic>> Day([FromQuery] DateTime? date)
    {
        return HandleResponse(await getDayStatisticUseCase.Handle(UserClaims.Id(User), date));
    }

    [HttpGet, Route("{timeRecordId:int}/day")]
    public async Task<ActionResult<DayStatistic>> Day(int timeRecordId, [FromQuery] DateTime? date)
    {
        return HandleResponse(await getDayStatisticUseCase.Handle(UserClaims.Id(User), date, 0, timeRecordId));
    }
}