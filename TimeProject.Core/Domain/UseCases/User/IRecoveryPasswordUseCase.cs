using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.RemoveDependencies.Dtos.User;

namespace TimeProject.Core.Domain.UseCases.User;

public interface IRecoveryPasswordUseCase
{
    Task<Result<bool>> Handle(RecoveryPasswordDto dto);
}