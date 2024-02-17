using Microsoft.AspNetCore.Mvc;
using PomodoroAPI.Modules.Categoria.Models;
using PomodoroAPI.Modules.Categoria.Repositories;

namespace PomodoroAPI.Modules.Categoria.Controllers;

[ApiController]
[Route("api/categoria")]
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
        return Ok(_categoriaRepository.Index(page, perPage));
    }

    [HttpPost]
    public async Task<ActionResult<CategoriaModel>> Create([FromBody] CategoriaViewModel categoria)
    {
        return Ok(await _categoriaRepository.Create(
            new CategoriaModel()
                { Nome = categoria.Nome, UsuarioId = categoria.UsuarioId }
        ));
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<CategoriaModel>> Update(int id, [FromBody] CategoriaViewModel categoria)
    {
        return Ok(await _categoriaRepository.Update(id,
            new CategoriaModel()
                { Nome = categoria.Nome }
        ));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _categoriaRepository.Delete(id);
        return NoContent();
    }
}