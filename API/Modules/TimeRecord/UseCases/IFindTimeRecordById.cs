using System.Security.Claims;
using Entities;
using Shared.General;

namespace API.Modules.TimeRecord.UseCases;

public interface IFindTimeRecordById
{
    Task<Result<TimeRecordEntity>> Handle(int id, ClaimsPrincipal user);
}