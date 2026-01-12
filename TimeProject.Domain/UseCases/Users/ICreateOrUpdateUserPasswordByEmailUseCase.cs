using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Users;

public interface ICreateOrUpdateUserPasswordByEmailUseCase
{
    ICustomResult<bool> Handle(string email, string password);
}