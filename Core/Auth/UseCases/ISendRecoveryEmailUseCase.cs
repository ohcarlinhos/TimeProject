using Shared.General;

namespace Core.Auth.UseCases;

public interface ISendRecoveryEmailUseCase
{
    Task<Result<bool>> Handle(string email);
}