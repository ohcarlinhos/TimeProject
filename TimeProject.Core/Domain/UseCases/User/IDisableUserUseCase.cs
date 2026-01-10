using TimeProject.Core.RemoveDependencies.Dtos.User;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.User;

public interface IDisableUserUseCase
{
    Task<Result<bool>> Handle(int id, DisableUserDto dto);
}