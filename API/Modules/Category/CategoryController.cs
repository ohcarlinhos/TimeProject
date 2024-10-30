using API.Infra.Controllers;
using Core.Category.UseCases;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Category;
using Shared.General.Pagination;
using Shared.General.Util;

namespace API.Modules.Category;

[ApiController, Route("api/category"), Authorize]
public class CategoryController(
    IGetAllCategoryUseCase getAllCategoryUseCase,
    IGetPaginatedCategoryUseCase getPaginatedCategoryUseCase,
    ICreateCategoryUseCase createCategoryUseCase,
    IDeleteCategoryUseCase deleteCategoryUseCase,
    IUpdateCategoryUseCase updateCategoryUseCase
)
    : CustomController
{
    [HttpGet]
    public async Task<ActionResult<Pagination<CategoryMap>>> Index([FromQuery] PaginationQuery paginationQuery)
    {
        return HandleResponse(await getPaginatedCategoryUseCase.Handle(paginationQuery, UserClaims.Id(User)));
    }

    [HttpGet, Route("all")]
    public ActionResult<List<CategoryMap>> Index([FromQuery] bool onlyWithData)
    {
        return HandleResponse(getAllCategoryUseCase.Handle(UserClaims.Id(User), onlyWithData));
    }

    [HttpPost]
    public async Task<ActionResult<CategoryEntity>> Create([FromBody] CategoryDto dto)
    {
        var result = await createCategoryUseCase.Handle(dto, UserClaims.Id(User));
        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPut, Route("{id:int}")]
    public async Task<ActionResult<CategoryEntity>> Update(int id, [FromBody] CategoryDto dto)
    {
        return HandleResponse(await updateCategoryUseCase.Handle(id, dto, UserClaims.Id(User)));
    }

    [HttpDelete, Route("{id:int}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        return HandleResponse(await deleteCategoryUseCase.Handle(id, UserClaims.Id(User)));
    }
}