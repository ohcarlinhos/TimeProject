using API.Database;
using API.Modules.Core.Controllers;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.General;
using Shared.General.Pagination;
using Shared.General.Util;
using Shared.User;

namespace API.Modules.Codes.Controllers;

[ApiController]
[Route("api/register-code")]
public class RegisterCodeController(ProjectContext dbContext) : CustomController
{
    [HttpGet, Authorize]
    public ActionResult<List<RegisterCodeEntity>> Index([FromQuery] PaginationQuery paginationQuery)
    {
        if (UserRole.Admin.ToString() != UserClaims.Role(User))
            return Forbid();

        var query = dbContext.RegisterCodes.AsQueryable();

        var data = query
            .Skip((paginationQuery.Page - 1) * paginationQuery.PerPage)
            .Take(paginationQuery.PerPage)
            .Include((e) => e.User)
            .ToList();

        return Ok(Pagination<RegisterCodeEntity>.Handle(data, paginationQuery, query.Count()));
    }

    [HttpPost, Authorize]
    public async Task<ActionResult<RegisterCodeEntity>> Create(CreateRegisterCodeDto _)
    {
        if (UserRole.Admin.ToString() != UserClaims.Role(User))
            return Forbid();

        var registerCode = new RegisterCodeEntity();
        dbContext.RegisterCodes.Add(registerCode);
        await dbContext.SaveChangesAsync();
        return Ok(registerCode);
    }

    [HttpDelete, Authorize, Route("{id}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] string id)
    {
        if (UserRole.Admin.ToString() != UserClaims.Role(User))
            return Forbid();

        var registerCode = new RegisterCodeEntity { Id = id };

        dbContext.RegisterCodes.Remove(registerCode);
        await dbContext.SaveChangesAsync();

        return NoContent();
    }
}