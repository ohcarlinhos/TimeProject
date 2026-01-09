using Core.User.Repositories;
using Core.User.UseCases;
using Shared.General;

namespace TimeProject.Api.Modules.User.UseCases;

public class DeleteUserUseCase(IUserRepository repo) : IDeleteUserUseCase
{
    public async Task<Result<bool>> Handle(int id)
    {
        return new Result<bool> { Data = await repo.Delete(id) };
    }
}