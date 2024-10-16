using API.Core.Statistic.UseCases;
using API.Infra.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.General.Util;
using Shared.Statistic;

namespace API.Modules.Statistic;

[ApiController, Route("api/statistic"), Authorize]
public class StatisticController(IGetDayStatisticsUseCase getDayStatisticsUseCase) : CustomController
{
    [HttpGet, Route("day")]
    public async Task<ActionResult<DayStatistic>> Day([FromQuery] DateTime? date)
    {
        return HandleResponse(await getDayStatisticsUseCase.Handle(UserClaims.Id(User), date, 3));
    }
}