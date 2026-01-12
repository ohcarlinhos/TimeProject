using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface IGetPaginatedUserUseCase
{
    ICustomResult<IPagination<IUserOutDto>> Handle(IPaginationQuery paginationQuery);
}