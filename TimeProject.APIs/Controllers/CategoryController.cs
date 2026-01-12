using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.APIs.Controllers.Shared;
using TimeProject.Domain.Entities;
using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.UseCases.Categories;
using TimeProject.Domain.Dtos.Categories;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Infrastructure.ObjectValues.Categories;
using TimeProject.Infrastructure.Utils;

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
        return HandleResponse( getPaginatedCategoryUseCase.Handle(paginationQuery, UserClaimsUtil.Id(User)));
    }

    [HttpGet]
    [Route("all")]
    public ActionResult<IList<ICategoryOutDto>> Index([FromQuery] bool onlyWithData)
    {
        return HandleResponse(getAllCategoryUseCase.Handle(UserClaimsUtil.Id(User), onlyWithData));
    }

    [HttpPost]
    public ActionResult<ICategory> Create([FromBody] CategoryDto dto)
    {
        var result =  createCategoryUseCase.Handle(dto, UserClaimsUtil.Id(User));
        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPut]
    [Route("{id:int}")]
    public ActionResult<ICategory> Update(int id, [FromBody] CategoryDto dto)
    {
        return HandleResponse( updateCategoryUseCase.Handle(id, dto, UserClaimsUtil.Id(User)));
    }

    [HttpDelete]
    [Route("{id:int}")]
    public ActionResult<bool> Delete(int id)
    {
        return HandleResponse( deleteCategoryUseCase.Handle(id, UserClaimsUtil.Id(User)));
    }
}