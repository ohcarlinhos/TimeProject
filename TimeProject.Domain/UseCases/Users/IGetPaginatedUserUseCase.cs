using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.Dtos.Users;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Users;

public interface IGetPaginatedUserUseCase
{
    ICustomResult<IPagination<IUserOutDto>> Handle(IPaginationQuery paginationQuery);
}