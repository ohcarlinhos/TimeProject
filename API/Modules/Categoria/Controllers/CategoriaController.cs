using API.Infrastructure.Services;
using API.Modules.Categoria.Entities;
using API.Modules.Categoria.Models;
using API.Modules.Categoria.Services;
using API.Modules.Shared.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Categoria.Controllers;

[ApiController, Route("api/categoria"), Authorize]
public class CategoriaController(ICategoriaServices categoriaServices)
    : CustomController
{
    [HttpGet]
    public ActionResult<List<CategoriaEntity>> Index(int page = 0, int perPage = 12)
    {
        return HandleResponse(categoriaServices
            .Index(AuthorizeService.GetUserId(User), page, perPage));
    }

    [HttpPost]
    public async Task<ActionResult<CategoriaEntity>> Create([FromBody] CategoriaModel model)
    {
        return HandleResponse(await categoriaServices
            .Create(model, AuthorizeService.GetUserId(User)));
    }

    [HttpPut, Route("{id}")]
    public async Task<ActionResult<CategoriaEntity>> Update(int id, [FromBody] CategoriaModel model)
    {
        return HandleResponse(await categoriaServices
            .Update(id, model, AuthorizeService.GetUserId(User)));
    }

    [HttpDelete, Route("{id}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        return HandleResponse(await categoriaServices
            .Delete(id, AuthorizeService.GetUserId(User)));
    }
}