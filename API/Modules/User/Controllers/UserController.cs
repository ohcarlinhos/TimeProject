using API.Infrastructure.Util;
using API.Modules.Shared.Controllers;
using API.Modules.User.Services;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.User;
using Shared;
using Shared.General;

namespace API.Modules.User.Controllers;

[ApiController]
[Route("api/user")]
public class UserController(IUserServices userServices) : CustomController
{
    [HttpGet, Authorize]
    public ActionResult<Pagination<UserMap>> Index(
        int page = 1,
        int perPage = 4,
        string search = "",
        string orderBy = "",
        string sort = "desc"
    )
    {
        if (UserRole.Admin.ToString() == UserClaims.Role(User))
            return HandleResponse(userServices.Index(page, perPage, search, orderBy, sort));
        return Forbid();
    }

    [HttpPost]
    public async Task<ActionResult<UserMap>> Create([FromBody] CreateUserDto dto)
    {
        return HandleResponse(await userServices.Create(dto));
    }

    [HttpPut("{id:int}"), Authorize]
    public async Task<ActionResult<UserMap>> Update([FromRoute] int id, [FromBody] UpdateUserDto dto)
    {
        return UserClaims.Id(User) == id
            ? HandleResponse(await userServices.Update(id, dto))
            : Forbid();
    }

    [HttpDelete("{id:int}"), Authorize]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
        return UserClaims.Id(User) == id
            ? HandleResponse(await userServices.Delete(id))
            : Forbid();
    }

    [HttpGet, Authorize, Route("{id:int}")]
    public async Task<ActionResult<UserMap>> Get(int id)
    {
        return HandleResponse(await userServices.Get(id));
    }

    [HttpGet, Authorize, Route("myself")]
    public async Task<ActionResult<UserMap>> Myself()
    {
        return HandleResponse(await userServices
            .Get(UserClaims.Id(User)));
    }
}