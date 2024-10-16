using Shared.General;
using Shared.User;

namespace API.Core.User.UseCases;

public interface ICreateUserUseCase
{
    Task<Result<UserMap>> Handle(CreateUserDto dto);
}