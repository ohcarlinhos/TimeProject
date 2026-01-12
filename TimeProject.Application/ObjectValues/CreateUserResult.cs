using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.Dtos.Auths;
using TimeProject.Domain.Dtos.Users;

namespace TimeProject.Application.ObjectValues;

public class CreateUserResult : ICreateUserResult
{
    public IUserOutDto User { get; set; } = null!;
    public IJwtResult Jwt { get; set; } = null!;
}