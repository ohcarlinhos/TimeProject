using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface ICreateUserByGoogleUserUseCase
{
    Task<ICustomResult<IUser>> Handle(CreateUserOAtuhDto dto, string email);
}