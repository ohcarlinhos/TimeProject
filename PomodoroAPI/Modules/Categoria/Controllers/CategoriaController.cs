using Microsoft.AspNetCore.Mvc;
using PomodoroAPI.Modules.Categoria.Models;
using PomodoroAPI.Modules.Categoria.Repositories;

namespace PomodoroAPI.Modules.Categoria.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaController(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    [HttpGet]
    public ActionResult<List<CategoriaModel>> Index(int page = 0, int perPage = 12)
    {
        return Ok(_categoriaRepository.Listar(page, perPage));
    }

    [HttpPost]
    public async Task<ActionResult<CategoriaModel>> Adicionar([FromBody] CategoriaViewModel categoria)
    {
        return Ok(await _categoriaRepository.Adicionar(
            new CategoriaModel()
                { Nome = categoria.Nome, UsuarioId = categoria.UsuarioId }
        ));
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<CategoriaModel>> Atualizar(int id, [FromBody] CategoriaViewModel categoria)
    {
        return Ok(await _categoriaRepository.Atualizar(id,
            new CategoriaModel()
                { Nome = categoria.Nome }
        ));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> Apagar(int id)
    {
        await _categoriaRepository.Apagar(id);
        return NoContent();
    }
}