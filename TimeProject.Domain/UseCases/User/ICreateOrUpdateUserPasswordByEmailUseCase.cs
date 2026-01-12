using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface ICreateOrUpdateUserPasswordByEmailUseCase
{
    ICustomResult<bool> Handle(string email, string password);
}