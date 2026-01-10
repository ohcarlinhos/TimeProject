using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.User;

public class DeleteUserUseCase(IUserRepository repo) : IDeleteUserUseCase
{
    public async Task<ICustomResult<bool>> Handle(int id)
    {
        return new CustomResult<bool> { Data = await repo.Delete(id) };
    }
}