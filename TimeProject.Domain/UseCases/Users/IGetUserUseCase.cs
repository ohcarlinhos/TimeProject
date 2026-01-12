using TimeProject.Domain.Dtos.Users;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Users;

public interface IGetUserUseCase
{
    ICustomResult<IUserOutDto> Handle(int id);
}