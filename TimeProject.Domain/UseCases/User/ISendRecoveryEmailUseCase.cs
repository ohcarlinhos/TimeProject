using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface ISendRecoveryEmailUseCase
{
    ICustomResult<bool> Handle(string email, string recoveryUrl);
}