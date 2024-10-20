using Shared.Auth;
using Shared.General;

namespace API.Core.Auth.UseCases;

public interface IRecoveryPasswordUseCase
{
    Task<Result<bool>> Handle(RecoveryPasswordDto dto);
}