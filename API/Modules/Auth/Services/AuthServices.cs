using API.Infrastructure.Services;
using API.Modules.Auth.Models;
using API.Modules.Shared;
using API.Modules.User.Repositories;

namespace API.Modules.Auth.Services;

public class AuthServices(IUserRepository userRepository, TokenService tokenService) : IAuthService
{
    public async Task<Result<object>> Login(LoginDto dto)
    {
        var result = new Result<object>();
        var user = await userRepository.FindByEmail(dto.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
        {
            result.Message = "Email ou senha incorretos.";
            result.HasError = true;
            return result;
        }

        result.Data = tokenService.GenerateBearerJwt(user);
        return result;
    }
}