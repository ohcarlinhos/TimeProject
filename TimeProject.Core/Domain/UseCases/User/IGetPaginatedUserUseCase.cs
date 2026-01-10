using TimeProject.Core.RemoveDependencies.Dtos.User;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.RemoveDependencies.General.Pagination;

namespace TimeProject.Core.Domain.UseCases.User;

public interface IGetPaginatedUserUseCase
{
    Result<Pagination<UserOutDto>> Handle(PaginationQuery paginationQuery);
}