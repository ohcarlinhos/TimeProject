using API.Modules.Category.Services;
using API.Modules.Shared.Controllers;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.Category;
using Shared.General;

namespace API.Modules.Category.Controllers;

[ApiController, Route("api/category"), Authorize]
public class CategoryController(ICategoryServices categoryServices)
    : CustomController
{
    [HttpGet]
    public async Task<ActionResult<Pagination<CategoryMap>>> Index([FromQuery] PaginationQuery paginationQuery)
    {
        return HandleResponse(await categoryServices.Index(paginationQuery, User));
    }

    [HttpGet, Route("all")]
    public ActionResult<List<CategoryMap>> Index()
    {
        return HandleResponse(categoryServices.Index(User));
    }

    [HttpPost]
    public async Task<ActionResult<CategoryEntity>> Create([FromBody] CategoryDto dto)
    {
        var result = await categoryServices.Create(dto, User);
        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPut, Route("{id:int}")]
    public async Task<ActionResult<CategoryEntity>> Update(int id, [FromBody] CategoryDto dto)
    {
        return HandleResponse(await categoryServices.Update(id, dto, User));
    }

    [HttpDelete, Route("{id:int}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        return HandleResponse(await categoryServices.Delete(id, User));
    }
}