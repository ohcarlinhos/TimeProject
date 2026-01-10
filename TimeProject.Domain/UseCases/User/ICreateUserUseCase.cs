using TimeProject.Domain.RemoveDependencies.Dtos.Auth;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.User;

public class CreateUserResult
{
    public UserOutDto User { get; set; } = null!;
    public JwtResult Jwt { get; set; } = null!;
}

public interface ICreateUserUseCase
{
    Task<Result<CreateUserResult>> Handle(CreateUserDto dto);
}