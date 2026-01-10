using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface IDisableUserUseCase
{
    Task<ICustomResult<bool>> Handle(int id, DisableUserDto dto);
}