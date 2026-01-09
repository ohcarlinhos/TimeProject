using TimeProject.Core.Application.Dtos.User;
using TimeProject.Core.Application.General;

namespace TimeProject.Core.Domain.UseCases.User;

public interface IDisableUserUseCase
{
    Task<Result<bool>> Handle(int id, DisableUserDto dto);
}