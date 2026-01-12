using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;
using TimeProject.Domain.Utils;

namespace TimeProject.Domain.UseCases.User;

public interface IUpdateUserUseCase
{
    ICustomResult<IUserOutDto> Handle(int id, IUpdateUserDto dto);
    ICustomResult<IUserOutDto> Handle(int id, IUpdateUserDto dto, IUpdateUserOptions config);
}