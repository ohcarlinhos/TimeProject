using TimeProject.Domain.RemoveDependencies.Dtos.Auth;
using TimeProject.Domain.RemoveDependencies.Dtos.User;

namespace TimeProject.Domain.ObjectValues;

public interface ICreateUserResult
{
    IUserOutDto User { get; set; }
    JwtResult Jwt { get; set; }
}