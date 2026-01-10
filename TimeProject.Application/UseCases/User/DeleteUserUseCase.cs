using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.User;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Application.UseCases.User;

public class DeleteUserUseCase(IUserRepository repo) : IDeleteUserUseCase
{
    public async Task<Result<bool>> Handle(int id)
    {
        return new Result<bool> { Data = await repo.Delete(id) };
    }
}