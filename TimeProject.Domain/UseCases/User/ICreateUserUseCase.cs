using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface ICreateUserUseCase
{
    Task<ICustomResult<ICreateUserResult>> Handle(CreateUserDto dto);
}