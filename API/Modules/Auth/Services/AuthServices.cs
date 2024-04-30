using API.Infrastructure.Services;
using API.Modules.Auth.Models;
using API.Modules.Shared;
using API.Modules.Usuario.Repositories;

namespace API.Modules.Auth.Services;

public class AuthServices(IUsuarioRepository usuarioRepository) : IAuthService
{
    public async Task<Result<object>> Login(LoginModel model)
    {
        var result = new Result<object>();
        var usuario = await usuarioRepository.FindByEmail(model.Email);

        if (usuario == null || usuario.Senha != model.Password)
        {
            result.Message = "Email ou senha incorretos.";
            result.HasError = true;
            return result;
        }

        result.Data = TokenService.GenerateBearerJwt(usuario);
        return result;
    }
}