using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface IRecoveryPasswordUseCase
{
    ICustomResult<bool> Handle(IRecoveryPasswordDto dto);
}