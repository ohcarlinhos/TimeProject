using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Users;

public class DeleteUserUseCase(IUserRepository repo) : IDeleteUserUseCase
{
    public ICustomResult<bool> Handle(int id)
    {
        return new CustomResult<bool> { Data = repo.Delete(id) };
    }
}