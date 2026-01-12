using TimeProject.Domain.Dtos.Auths;
using TimeProject.Domain.Dtos.Users;
using TimeProject.Domain.ObjectValues;

namespace TimeProject.Infrastructure.ObjectValues.Pagination.Users;

public class CreateUserResult : ICreateUserResult
{
    public IUserOutDto User { get; set; } = null!;
    public IJwtResult Jwt { get; set; } = null!;
}