using Shared.General;

namespace Core.User.UseCases;

public interface ISendRecoveryEmailUseCase
{
    Task<Result<bool>> Handle(string email);
}