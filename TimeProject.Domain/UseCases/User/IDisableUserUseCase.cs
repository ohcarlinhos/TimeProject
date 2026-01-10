using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.User;

public interface IDisableUserUseCase
{
    Task<Result<bool>> Handle(int id, DisableUserDto dto);
}