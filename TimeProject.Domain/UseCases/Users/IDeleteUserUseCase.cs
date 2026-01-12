using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Users;

public interface IDeleteUserUseCase
{
    ICustomResult<bool> Handle(int id);
}