using API.Infrastructure.Services;
using API.Modules.Category.DTO;
using API.Modules.Category.Entities;
using API.Modules.Category.Models;
using API.Modules.Category.Services;
using API.Modules.Shared;
using API.Modules.Shared.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Category.Controllers;

[ApiController, Route("api/category"), Authorize]
public class CategoryController(ICategoryServices categoryServices)
    : CustomController
{
    [HttpGet]
    public async Task<ActionResult<Pagination<CategoryDto>>> Index(int page = 0, int perPage = 12)
    {
        return HandleResponse(await categoryServices
            .Index(AuthorizeService.GetUserId(User), page, perPage));
    }

    [HttpGet, Route("all")]
    public ActionResult<List<CategoryDto>> Index()
    {
        return HandleResponse(categoryServices
            .Index(AuthorizeService.GetUserId(User)));
    }

    [HttpPost]
    public async Task<ActionResult<CategoryEntity>> Create([FromBody] CategoryModel model)
    {
        return HandleResponse(await categoryServices
            .Create(model, AuthorizeService.GetUserId(User)));
    }

    [HttpPut, Route("{id}")]
    public async Task<ActionResult<CategoryEntity>> Update(int id, [FromBody] CategoryModel model)
    {
        return HandleResponse(await categoryServices
            .Update(id, model, AuthorizeService.GetUserId(User)));
    }

    [HttpDelete, Route("{id}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        return HandleResponse(await categoryServices
            .Delete(id, AuthorizeService.GetUserId(User)));
    }
}