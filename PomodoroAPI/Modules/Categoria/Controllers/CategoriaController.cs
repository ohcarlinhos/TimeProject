using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PomodoroAPI.Infrastructure.Services;
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

    [HttpGet, Authorize]
    public ActionResult<List<CategoriaModel>> Index(int page = 0, int perPage = 12)
    {
        return Ok(_categoriaRepository.Index(AuthorizeService.GetUsuarioId(User), page, perPage));
    }

    [HttpPost, Authorize]
    public async Task<ActionResult<CategoriaModel>> Create([FromBody] CategoriaViewModel categoria)
    {
        return Ok(await _categoriaRepository
            .Create(categoria, AuthorizeService.GetUsuarioId(User))
        );
    }

    [HttpPut, Route("{id}"), Authorize]
    public async Task<ActionResult<CategoriaModel>> Update(int id, [FromBody] CategoriaViewModel categoria)
    {
        return Ok(
            await _categoriaRepository.Update(id, categoria, AuthorizeService.GetUsuarioId(User))
        );
    }

    [HttpDelete, Route("{id}"), Authorize]
    public async Task<ActionResult> Delete(int id)
    {
        await _categoriaRepository.Delete(id, AuthorizeService.GetUsuarioId(User));
        return NoContent();
    }
}