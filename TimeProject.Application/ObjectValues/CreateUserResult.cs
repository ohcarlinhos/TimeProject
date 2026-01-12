using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.RemoveDependencies.Dtos.Auth;
using TimeProject.Domain.RemoveDependencies.Dtos.User;

namespace TimeProject.Application.ObjectValues;

public class CreateUserResult : ICreateUserResult
{
    public IUserOutDto User { get; set; } = null!;
    public IJwtResult Jwt { get; set; } = null!;
}