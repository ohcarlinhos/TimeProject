using TimeProject.Core.Application.Dtos.Auth;
using TimeProject.Core.Application.Dtos.User;
using TimeProject.Core.Application.General;

namespace TimeProject.Core.Domain.UseCases.User;

public class CreateUserResult
{
    public UserOutDto User { get; set; } = null!;
    public JwtDto Jwt { get; set; } = null!;
}

public interface ICreateUserUseCase
{
    Task<Result<CreateUserResult>> Handle(CreateUserDto dto);
}