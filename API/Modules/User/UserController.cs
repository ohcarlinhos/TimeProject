using API.Core.User;
using API.Infra.Controllers;
using API.Modules.User.Services.Config;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.General.Pagination;
using Shared.General.Util;
using Shared.User;

namespace API.Modules.User;

[ApiController]
[Route("api/user")]
public class UserController(IUserServices userServices) : CustomController
{
    [HttpGet, Authorize]
    public ActionResult<Pagination<UserMap>> Index([FromQuery] PaginationQuery paginationQuery)
    {
        if (UserRole.Admin.ToString() == UserClaims.Role(User))
            return HandleResponse(userServices.Index(paginationQuery));
        return Forbid();
    }

    [HttpPost]
    public async Task<ActionResult<UserMap>> Create([FromBody] CreateUserDto dto)
    {
        var result = await userServices.Create(dto);
        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPut("{id:int}"), Authorize]
    public async Task<ActionResult<UserMap>> Update([FromRoute] int id, [FromBody] UpdateUserDto dto)
    {
        return HasAuthorization(id)
            ? HandleResponse(await userServices.Update(id, dto))
            : Forbid();
    }

    [HttpPut("password/{id:int}"), Authorize]
    public async Task<ActionResult<UserMap>> UpdatePassword([FromRoute] int id, [FromBody] UpdatePasswordDto dto)
    {
        return IsAdmin()
            ? HandleResponse(await userServices.Update(id, new UpdateUserDto
                {
                    Password = dto.Password
                },
                new UpdateUserMethodConfig { SkipOldPasswordCompare = true }))
            : Forbid();
    }

    [HttpPut("role/{id:int}"), Authorize]
    public async Task<ActionResult<UserMap>> UpdateRole([FromRoute] int id, [FromBody] UpdateRoleDto dto)
    {
        return IsAdmin()
            ? HandleResponse(await userServices.UpdateRole(id, dto))
            : Forbid();
    }

    [HttpPost("disable/{id:int}"), Authorize]
    public async Task<ActionResult<bool>> Disable([FromRoute] int id, [FromBody] DisableUserDto dto)
    {
        return HasAuthorization(id)
            ? HandleResponse(await userServices.Disable(id, dto))
            : Forbid();
    }

    [HttpDelete("{id:int}"), Authorize]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
        return HasAuthorization(id)
            ? HandleResponse(await userServices.Delete(id))
            : Forbid();
    }

    [HttpGet, Authorize, Route("{id:int}")]
    public async Task<ActionResult<UserMap>> Details(int id)
    {
        return HasAuthorization(id)
            ? HandleResponse(await userServices.Details(id))
            : Forbid();
    }

    [HttpGet, Authorize, Route("myself")]
    public async Task<ActionResult<UserMap>> Myself()
    {
        return HandleResponse(await userServices
            .Details(UserClaims.Id(User)));
    }

    private bool HasAuthorization(int id)
    {
        return UserClaims.Id(User) == id || IsAdmin();
    }
}