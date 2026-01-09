using TimeProject.Core.Application.Dtos.User;
using TimeProject.Core.Application.General;
using TimeProject.Core.Application.General.Pagination;

namespace TimeProject.Core.Domain.UseCases.User;

public interface IGetPaginatedUserUseCase
{
    Result<Pagination<UserOutDto>> Handle(PaginationQuery paginationQuery);
}