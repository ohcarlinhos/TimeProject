using TimeProject.Core.RemoveDependencies.Dtos.User;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.User;

public interface IGetUserUseCase
{
    Task<Result<UserOutDto>> Handle(int id);
}