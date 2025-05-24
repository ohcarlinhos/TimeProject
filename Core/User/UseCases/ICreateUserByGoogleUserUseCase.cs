using Entities;
using Shared.General;
using Shared.User;

namespace Core.User.UseCases;

public interface ICreateUserByGoogleUserUseCase
{
    Task<Result<UserEntity>> Handle(CreateUserOAtuhDto dto, string email);
}