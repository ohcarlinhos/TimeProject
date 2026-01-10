using TimeProject.Core.Domain.Entities;
using TimeProject.Core.RemoveDependencies.Dtos.User;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.User;

public interface ICreateUserByGoogleUserUseCase
{
    Task<Result<UserEntity>> Handle(CreateUserOAtuhDto dto, string email);
}