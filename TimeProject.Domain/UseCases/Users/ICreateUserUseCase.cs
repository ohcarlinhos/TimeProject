using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.Dtos.Users;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Users;

public interface ICreateUserUseCase
{
    ICustomResult<ICreateUserResult> Handle(ICreateUserDto dto);
}