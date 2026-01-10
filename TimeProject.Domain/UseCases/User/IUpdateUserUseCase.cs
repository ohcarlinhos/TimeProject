using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Utils;

namespace TimeProject.Domain.UseCases.User;

public interface IUpdateUserUseCase
{
    Task<Result<UserOutDto>> Handle(int id, UpdateUserDto dto);
    Task<Result<UserOutDto>> Handle(int id, UpdateUserDto dto, IUpdateUserOptions config);
}