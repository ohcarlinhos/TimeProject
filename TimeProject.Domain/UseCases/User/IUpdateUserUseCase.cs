using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;
using TimeProject.Domain.Utils;

namespace TimeProject.Domain.UseCases.User;

public interface IUpdateUserUseCase
{
    Task<ICustomResult<UserOutDto>> Handle(int id, UpdateUserDto dto);
    Task<ICustomResult<UserOutDto>> Handle(int id, UpdateUserDto dto, IUpdateUserOptions config);
}