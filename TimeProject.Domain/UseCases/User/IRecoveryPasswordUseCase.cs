using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.User;

public interface IRecoveryPasswordUseCase
{
    Task<Result<bool>> Handle(RecoveryPasswordDto dto);
}