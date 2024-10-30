using Shared.General;
using Shared.General.Pagination;
using Shared.User;

namespace Core.User.UseCases;

public interface IGetPaginatedUserUseCase
{
    Result<Pagination<UserMap>> Handle(PaginationQuery paginationQuery);
}