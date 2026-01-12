using TimeProject.Domain.Dtos.Users;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Users;

public interface IRecoveryPasswordUseCase
{
    ICustomResult<bool> Handle(IRecoveryPasswordDto dto);
}