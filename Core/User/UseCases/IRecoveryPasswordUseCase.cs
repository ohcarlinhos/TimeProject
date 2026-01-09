using Shared.General;
using Shared.User;

namespace Core.User.UseCases;

public interface IRecoveryPasswordUseCase
{
    Task<Result<bool>> Handle(RecoveryPasswordDto dto);
}