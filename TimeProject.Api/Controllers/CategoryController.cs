using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.Api.Controllers.Shared;
using TimeProject.Core.RemoveDependencies.Dtos.Category;
using TimeProject.Core.RemoveDependencies.General.Pagination;
using TimeProject.Core.RemoveDependencies.General.Util;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.UseCases.Category;

namespace TimeProject.Api.Controllers;

[ApiController]
[Route("api/categories")]
[Authorize(Policy = "IsActive")]
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
    public async Task<ActionResult<Pagination<CategoryOutDto>>> Index([FromQuery] PaginationQuery paginationQuery)
    {
        return HandleResponse(await getPaginatedCategoryUseCase.Handle(paginationQuery, UserClaims.Id(User)));
    }

    [HttpGet]
    [Route("all")]
    public ActionResult<List<CategoryOutDto>> Index([FromQuery] bool onlyWithData)
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

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<CategoryEntity>> Update(int id, [FromBody] CategoryDto dto)
    {
        return HandleResponse(await updateCategoryUseCase.Handle(id, dto, UserClaims.Id(User)));
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        return HandleResponse(await deleteCategoryUseCase.Handle(id, UserClaims.Id(User)));
    }
}