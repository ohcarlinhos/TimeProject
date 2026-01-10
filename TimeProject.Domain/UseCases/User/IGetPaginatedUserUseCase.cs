using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.RemoveDependencies.General.Pagination;

namespace TimeProject.Domain.UseCases.User;

public interface IGetPaginatedUserUseCase
{
    CustomResult<Pagination<UserOutDto>> Handle(PaginationQuery paginationQuery);
}