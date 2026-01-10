using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.User;

public interface ISendRecoveryEmailUseCase
{
    Task<Result<bool>> Handle(string email, string recoveryUrl);
}