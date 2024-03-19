using PomodoroAPI.Infrastructure.Services;
using PomodoroAPI.Modules.Auth.Models;
using PomodoroAPI.Modules.Shared;
using PomodoroAPI.Modules.Usuario.Repositories;

namespace PomodoroAPI.Modules.Auth.Services;

public class AuthServices(IUsuarioRepository usuarioRepository) : IAuthService
{
    public async Task<Result<object>> Login(LoginModel model)
    {
        var result = new Result<object>();
        var usuario = await usuarioRepository.FindByEmail(model.Email);

        if (usuario == null || usuario.Senha != model.Senha)
        {
            result.Message = "Email ou senha incorretos.";
            result.HasError = true;
            return result;
        }

        result.Data = TokenService.GenerateBearerJwt(usuario);
        return result;
    }
}