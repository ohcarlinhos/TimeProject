using Shared.Auth;
using Shared.General;

namespace API.Core.Auth.UseCases;

public interface ISendRecoveryEmailUseCase
{
    Task<Result<bool>> Handle(string email);
}