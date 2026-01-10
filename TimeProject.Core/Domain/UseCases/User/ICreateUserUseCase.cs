using TimeProject.Core.RemoveDependencies.Dtos.Auth;
using TimeProject.Core.RemoveDependencies.Dtos.User;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.User;

public class CreateUserResult
{
    public UserOutDto User { get; set; } = null!;
    public JwtResult Jwt { get; set; } = null!;
}

public interface ICreateUserUseCase
{
    Task<Result<CreateUserResult>> Handle(CreateUserDto dto);
}