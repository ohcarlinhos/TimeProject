using API.Core.User;
using API.Core.User.UseCases;
using API.Core.User.Utils;
using Shared.General;
using Shared.General.Pagination;
using Shared.User;

namespace API.Modules.User.UseCases;

public class GetPaginatedUserUseCase(IUserRepository repo, IUserMapDataUtil mapper) : IGetPaginatedUserUseCase
{
    public Result<Pagination<UserMap>> Handle(PaginationQuery paginationQuery)
    {
        var data = mapper.Handle(repo.Index(paginationQuery));
        var totalItems = repo.GetTotalItems(paginationQuery);

        return new Result<Pagination<UserMap>>
            { Data = Pagination<UserMap>.Handle(data, paginationQuery, totalItems) };
    }
}