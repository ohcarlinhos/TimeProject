using TimeProject.Core.Application.General;
using TimeProject.Core.Application.Dtos.User;

namespace TimeProject.Core.Domain.UseCases.User;

public interface IRecoveryPasswordUseCase
{
    Task<Result<bool>> Handle(RecoveryPasswordDto dto);
}