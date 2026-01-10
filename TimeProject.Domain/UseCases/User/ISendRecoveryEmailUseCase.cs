using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface ISendRecoveryEmailUseCase
{
    Task<ICustomResult<bool>> Handle(string email, string recoveryUrl);
}