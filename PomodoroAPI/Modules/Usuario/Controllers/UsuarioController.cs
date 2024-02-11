using Microsoft.AspNetCore.Mvc;
using PomodoroAPI.Modules.Usuario.Repositories;

namespace PomodoroAPI.Modules.Usuario.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;
    
    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }
    
    [HttpPost]
    public async Task<ActionResult<Models.Usuario>> Adicionar([FromBody] Models.Usuario usuario)
    {
        await _usuarioRepository.Adicionar(usuario);
        return Ok(usuario);
    }
}