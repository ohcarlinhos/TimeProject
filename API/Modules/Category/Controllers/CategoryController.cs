using API.Infrastructure.Services;
using API.Modules.Category.Dto;
using API.Modules.Category.Map;
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
    public async Task<ActionResult<Pagination<CategoryMap>>> Index(int page = 1, int perPage = 10, string search = "",
        string sort = "asc")
    {
        return HandleResponse(await categoryServices
            .Index(UserSession.Id(User), page, perPage, search, sort));
    }

    [HttpGet, Route("all")]
    public ActionResult<List<CategoryMap>> Index()
    {
        return HandleResponse(categoryServices
            .Index(UserSession.Id(User)));
    }

    [HttpPost]
    public async Task<ActionResult<Entities.Category>> Create([FromBody] CategoryDto dto)
    {
        return HandleResponse(await categoryServices
            .Create(dto, UserSession.Id(User)));
    }

    [HttpPut, Route("{id}")]
    public async Task<ActionResult<Entities.Category>> Update(int id, [FromBody] CategoryDto dto)
    {
        return HandleResponse(await categoryServices
            .Update(id, dto, UserSession.Id(User)));
    }

    [HttpDelete, Route("{id}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        return HandleResponse(await categoryServices
            .Delete(id, UserSession.Id(User)));
    }
}