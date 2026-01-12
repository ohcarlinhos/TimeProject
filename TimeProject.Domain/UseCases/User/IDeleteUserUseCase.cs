using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface IDeleteUserUseCase
{
    ICustomResult<bool> Handle(int id);
}