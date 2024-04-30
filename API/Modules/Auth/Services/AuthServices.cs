using API.Infrastructure.Services;
using API.Modules.Auth.Models;
using API.Modules.Shared;
using API.Modules.Usuario.Repositories;

namespace API.Modules.Auth.Services;

public class AuthServices(IUsuarioRepository userRepository) : IAuthService
{
    public async Task<Result<object>> Login(LoginModel model)
    {
        var result = new Result<object>();
        var user = await userRepository.FindByEmail(model.Email);

        if (user == null || user.Senha != model.Password)
        {
            result.Message = "Email ou senha incorretos.";
            result.HasError = true;
            return result;
        }

        result.Data = TokenService.GenerateBearerJwt(user);
        return result;
    }
}