using Core.User;
using Core.User.UseCases;
using Shared.General;

namespace App.Modules.User.UseCases;

public class DeleteUserUseCase(IUserRepository repo) : IDeleteUserUseCase
{
    public async Task<Result<bool>> Handle(int id)
    {
        return new Result<bool> { Data = await repo.Delete(id) };
    }
}