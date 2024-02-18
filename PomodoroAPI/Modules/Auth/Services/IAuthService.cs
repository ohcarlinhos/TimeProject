using PomodoroAPI.Modules.Shared;
using PomodoroAPI.Modules.Auth.Models;

namespace PomodoroAPI.Modules.Auth.Services;

public interface IAuthService
{
    Task<Result<object>> Login(LoginRequest request);
}