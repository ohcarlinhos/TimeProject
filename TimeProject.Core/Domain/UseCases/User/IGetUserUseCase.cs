using TimeProject.Core.Application.Dtos.User;
using TimeProject.Core.Application.General;

namespace TimeProject.Core.Domain.UseCases.User;

public interface IGetUserUseCase
{
    Task<Result<UserOutDto>> Handle(int id);
}