using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PomodoroAPI.Infrastructure.Services;
using PomodoroAPI.Modules.Categoria.Entities;
using PomodoroAPI.Modules.Categoria.Models;
using PomodoroAPI.Modules.Categoria.Services;
using PomodoroAPI.Modules.Shared.Controllers;

namespace PomodoroAPI.Modules.Categoria.Controllers;

[ApiController, Route("api/categoria"), Authorize]
public class CategoriaController(ICategoriaServices categoriaServices)
    : CustomController
{
    [HttpGet]
    public ActionResult<List<CategoriaEntity>> Index(int page = 0, int perPage = 12)
    {
        return HandleResponse(categoriaServices
            .Index(AuthorizeService.GetUsuarioId(User), page, perPage));
    }

    [HttpPost]
    public async Task<ActionResult<CategoriaEntity>> Create([FromBody] CategoriaModel model)
    {
        return HandleResponse(await categoriaServices
            .Create(model, AuthorizeService.GetUsuarioId(User)));
    }

    [HttpPut, Route("{id}")]
    public async Task<ActionResult<CategoriaEntity>> Update(int id, [FromBody] CategoriaModel model)
    {
        return HandleResponse(await categoriaServices
            .Update(id, model, AuthorizeService.GetUsuarioId(User)));
    }

    [HttpDelete, Route("{id}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        return HandleResponse(await categoriaServices
            .Delete(id, AuthorizeService.GetUsuarioId(User)));
    }
}