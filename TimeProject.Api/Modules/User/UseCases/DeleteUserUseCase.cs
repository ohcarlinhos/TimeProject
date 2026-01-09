using TimeProject.Core.Application.General;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.User;

namespace TimeProject.Api.Modules.User.UseCases;

public class DeleteUserUseCase(IUserRepository repo) : IDeleteUserUseCase
{
    public async Task<Result<bool>> Handle(int id)
    {
        return new Result<bool> { Data = await repo.Delete(id) };
    }
}