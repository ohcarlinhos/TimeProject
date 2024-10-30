using Shared.Auth;
using Shared.General;

namespace Core.Auth.UseCases;

public interface IRecoveryPasswordUseCase
{
    Task<Result<bool>> Handle(RecoveryPasswordDto dto);
}