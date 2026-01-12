using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Users;

public interface ICreateUserUseCase
{
    ICustomResult<ICreateUserResult> Handle(ICreateUserDto dto);
}