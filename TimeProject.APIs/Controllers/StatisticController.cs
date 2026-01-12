using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.APIs.Controllers.Shared;
using TimeProject.Domain.UseCases.Statistics;
using TimeProject.Domain.RemoveDependencies.Dtos.Statistic;
using TimeProject.Domain.RemoveDependencies.Util;

namespace TimeProject.APIs.Controllers;

[ApiController]
[Route("api/statistics")]
[Authorize(Policy = "IsActive")]
public class StatisticController(IGetRangeDaysStatisticUseCase getRangeDaysStatisticUseCase) : CustomController
{
    [HttpGet]
    [Route("day")]
    public ActionResult<IRangeStatistic> Day([FromQuery] DateTime? date)
    {
        return HandleResponse(getRangeDaysStatisticUseCase.Handle(UserClaims.Id(User), date));
    }

    [HttpGet]
    [Route("{timeRecordId:int}/day")]
    public ActionResult<IRangeStatistic> Day(int timeRecordId, [FromQuery] DateTime? date)
    {
        return HandleResponse(getRangeDaysStatisticUseCase.Handle(UserClaims.Id(User), date, null, timeRecordId));
    }

    [HttpGet]
    [Route("range")]
    public ActionResult<IRangeStatisticsWithDays> Range([FromQuery] DateTime start, [FromQuery] DateTime end)
    {
        return HandleResponse(getRangeDaysStatisticUseCase.Handle(UserClaims.Id(User), start, end));
    }
}