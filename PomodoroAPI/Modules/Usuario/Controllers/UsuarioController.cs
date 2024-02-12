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
    public async Task<ActionResult<Models.Usuario>> Adicionar([FromBody] Models.Usuario usuarioBody)
    {
        return Ok(await _usuarioRepository.Adicionar(usuarioBody));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Models.Usuario>> Atualizar(int id, [FromBody] Models.Usuario usuarioBody)
    {
        return Ok(await _usuarioRepository.Atualizar(id, usuarioBody));
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Apagar(int id)
    {
        await _usuarioRepository.Apagar(id);
        return NoContent();
    }
}