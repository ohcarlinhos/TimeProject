using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface IUpdateUserUseCase
{
    ICustomResult<IUserOutDto> Handle(int id, IUpdateUserDto dto);
    ICustomResult<IUserOutDto> Handle(int id, IUpdateUserDto dto, IUpdateUserOptions config);
}