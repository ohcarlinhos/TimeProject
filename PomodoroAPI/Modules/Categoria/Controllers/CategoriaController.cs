using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PomodoroAPI.Infrastructure.Http;
using PomodoroAPI.Infrastructure.Services;
using PomodoroAPI.Modules.Categoria.Entities;
using PomodoroAPI.Modules.Categoria.Models;
using PomodoroAPI.Modules.Categoria.Services;

namespace PomodoroAPI.Modules.Categoria.Controllers;

[ApiController, Route("api/categoria"), Authorize]
public class CategoriaController(ICategoriaServices categoriaServices)
    : ControllerBase
{
    [HttpGet]
    public ActionResult<List<CategoriaEntity>> Index(int page = 0, int perPage = 12)
    {
        var result = categoriaServices
            .Index(AuthorizeService.GetUsuarioId(User), page, perPage);

        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<ActionResult<CategoriaEntity>> Create([FromBody] CategoriaModel model)
    {
        var result = await categoriaServices
            .Create(model, AuthorizeService.GetUsuarioId(User));

        if (result.HasError)
            return BadRequest(new ErrorResponse { Message = result.Message });

        return Ok(result.Data);
    }

    [HttpPut, Route("{id}")]
    public async Task<ActionResult<CategoriaEntity>> Update(int id, [FromBody] CategoriaModel model)
    {
        var result = await categoriaServices
            .Update(id, model, AuthorizeService.GetUsuarioId(User));

        if (result.HasError)
        {
            var errorResponse = new ErrorResponse { Message = result.Message };
            if (result.Message!.Contains("not_found")) return NotFound(errorResponse);
            if (result.Message!.Contains("unauthorized")) return Unauthorized();
            return BadRequest(errorResponse);
        }

        return Ok(result.Data);
    }

    [HttpDelete, Route("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await categoriaServices
            .Delete(id, AuthorizeService.GetUsuarioId(User));

        if (result.HasError)
        {
            var errorResponse = new ErrorResponse { Message = result.Message };
            if (result.Message!.Contains("unauthorized")) return Unauthorized();
            return NotFound(errorResponse);
        }

        return Ok();
    }
}