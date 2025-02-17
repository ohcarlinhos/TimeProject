using Shared.Auth;
using Shared.General;
using Shared.User;

namespace Core.User.UseCases;

public class CreateUserResult
{
    public UserMap User { get; set; } = null!;
    public JwtData Jwt { get; set; } = null!;
}

public interface ICreateUserUseCase
{
    Task<Result<CreateUserResult>> Handle(CreateUserDto dto);
}