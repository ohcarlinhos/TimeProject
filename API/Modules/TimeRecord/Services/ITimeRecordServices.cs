using System.Security.Claims;
using Shared.General;
using Shared.TimeRecord;

namespace API.Modules.TimeRecord.Services;

public interface ITimeRecordServices
{
    Task<Result<Pagination<TimeRecordMap>>> Index(PaginationQuery paginationQuery, ClaimsPrincipal user);
    Task<Result<TimeRecordMap>> Create(CreateTimeRecordDto dto, ClaimsPrincipal user);
    Task<Result<TimeRecordMap>> Update(int id, UpdateTimeRecordDto dto, ClaimsPrincipal user);
    Task<Result<TimeRecordMap>> Details(string code, ClaimsPrincipal user);
    Task<Result<bool>> Delete(int id, ClaimsPrincipal user); 
}