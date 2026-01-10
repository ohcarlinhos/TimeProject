using TimeProject.Core.RemoveDependencies.Dtos.User;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.User;

public interface IRecoveryPasswordUseCase
{
    Task<Result<bool>> Handle(RecoveryPasswordDto dto);
}