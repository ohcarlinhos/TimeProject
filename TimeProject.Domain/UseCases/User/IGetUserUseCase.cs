using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface IGetUserUseCase
{
    Task<ICustomResult<UserOutDto>> Handle(int id);
}