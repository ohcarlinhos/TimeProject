using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Users;

public interface ISendRecoveryEmailUseCase
{
    ICustomResult<bool> Handle(string email, string recoveryUrl);
}