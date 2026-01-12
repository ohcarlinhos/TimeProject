using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.APIs.Controllers.Shared;
using TimeProject.Domain.Entities;
using TimeProject.Domain.UseCases.Categories;
using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Domain.RemoveDependencies.Util;
using TimeProject.Infrastructure.Entities;
using TimeProject.Infrastructure.ObjectValues.Categories;

namespace TimeProject.APIs.Controllers;

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
    public ActionResult<IPagination<ICategoryOutDto>> Index([FromQuery] PaginationQuery paginationQuery)
    {
        return HandleResponse( getPaginatedCategoryUseCase.Handle(paginationQuery, UserClaims.Id(User)));
    }

    [HttpGet]
    [Route("all")]
    public ActionResult<IList<ICategoryOutDto>> Index([FromQuery] bool onlyWithData)
    {
        return HandleResponse(getAllCategoryUseCase.Handle(UserClaims.Id(User), onlyWithData));
    }

    [HttpPost]
    public ActionResult<ICategory> Create([FromBody] CategoryDto dto)
    {
        var result =  createCategoryUseCase.Handle(dto, UserClaims.Id(User));
        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPut]
    [Route("{id:int}")]
    public ActionResult<ICategory> Update(int id, [FromBody] CategoryDto dto)
    {
        return HandleResponse( updateCategoryUseCase.Handle(id, dto, UserClaims.Id(User)));
    }

    [HttpDelete]
    [Route("{id:int}")]
    public ActionResult<bool> Delete(int id)
    {
        return HandleResponse( deleteCategoryUseCase.Handle(id, UserClaims.Id(User)));
    }
}