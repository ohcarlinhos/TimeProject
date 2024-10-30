using Shared.General;
using Shared.User;

namespace Core.User.UseCases;

public interface IDisableUserUseCase
{
    Task<Result<bool>> Handle(int id, DisableUserDto dto);
}