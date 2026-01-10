using TimeProject.Core.RemoveDependencies.Dtos.User;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.Domain.Utils;

namespace TimeProject.Core.Domain.UseCases.User;

public interface IUpdateUserUseCase
{
    Task<Result<UserOutDto>> Handle(int id, UpdateUserDto dto);
    Task<Result<UserOutDto>> Handle(int id, UpdateUserDto dto, IUpdateUserOptions config);
}