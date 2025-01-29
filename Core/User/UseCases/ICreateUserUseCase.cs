using Shared.Auth;
using Shared.General;
using Shared.User;

namespace Core.User.UseCases;

public class CreateUserResult
{
    public UserMap User { get; set; }
    public JwtData Jwt { get; set; }
}

public interface ICreateUserUseCase
{
    Task<Result<CreateUserResult>> Handle(CreateUserDto dto);
}