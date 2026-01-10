using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.User;

public interface ICreateUserByGoogleUserUseCase
{
    Task<Result<UserEntity>> Handle(CreateUserOAtuhDto dto, string email);
}