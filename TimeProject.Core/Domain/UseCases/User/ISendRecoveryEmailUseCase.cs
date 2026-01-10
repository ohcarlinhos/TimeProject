using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.User;

public interface ISendRecoveryEmailUseCase
{
    Task<Result<bool>> Handle(string email, string recoveryUrl);
}