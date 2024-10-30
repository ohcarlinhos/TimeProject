using Core.User;
using Core.User.UseCases;
using API.Infra.Controllers;
using API.Modules.User.Utils;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.General.Pagination;
using Shared.General.Util;
using Shared.User;

namespace API.Modules.User;

[ApiController]
[Route("api/user")]
public class UserController(
    ICreateUserUseCase createUserUseCase,
    IUpdateUserUseCase updateUserUseCase,
    IUpdateUserRoleUseCase updateUserRoleUseCase,
    IDisableUserUseCase disableUserUseCase,
    IGetUserUseCase getUserUseCase,
    IDeleteUserUseCase deleteUserUseCase,
    IGetPaginatedUserUseCase getPaginatedUserUseCase
) : CustomController
{
    [HttpGet, Authorize]
    public ActionResult<Pagination<UserMap>> Index([FromQuery] PaginationQuery paginationQuery)
    {
        if (UserRole.Admin.ToString() == UserClaims.Role(User))
            return HandleResponse(getPaginatedUserUseCase.Handle(paginationQuery));
        return Forbid();
    }

    [HttpPost]
    public async Task<ActionResult<UserMap>> Create([FromBody] CreateUserDto dto)
    {
        var result = await createUserUseCase.Handle(dto);
        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPut("{id:int}"), Authorize]
    public async Task<ActionResult<UserMap>> Update([FromRoute] int id, [FromBody] UpdateUserDto dto)
    {
        return HasAuthorization(id) ? HandleResponse(await updateUserUseCase.Handle(id, dto)) : Forbid();
    }

    [HttpPut("password/{id:int}"), Authorize]
    public async Task<ActionResult<UserMap>> UpdatePassword([FromRoute] int id, [FromBody] UpdatePasswordDto dto)
    {
        return IsAdmin()
            ? HandleResponse(await updateUserUseCase.Handle(
                id,
                new UpdateUserDto { Password = dto.Password },
                new UpdateUserOptions { SkipOldPasswordCompare = true })
            )
            : Forbid();
    }

    [HttpPut("role/{id:int}"), Authorize]
    public async Task<ActionResult<UserMap>> UpdateRole([FromRoute] int id, [FromBody] UpdateRoleDto dto)
    {
        return IsAdmin() ? HandleResponse(await updateUserRoleUseCase.Handle(id, dto)) : Forbid();
    }

    [HttpPost("disable/{id:int}"), Authorize]
    public async Task<ActionResult<bool>> Disable([FromRoute] int id, [FromBody] DisableUserDto dto)
    {
        return HasAuthorization(id) ? HandleResponse(await disableUserUseCase.Handle(id, dto)) : Forbid();
    }

    [HttpDelete("{id:int}"), Authorize]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
        return HasAuthorization(id) ? HandleResponse(await deleteUserUseCase.Handle(id)) : Forbid();
    }

    [HttpGet, Authorize, Route("{id:int}")]
    public async Task<ActionResult<UserMap>> Get(int id)
    {
        return HasAuthorization(id) ? HandleResponse(await getUserUseCase.Handle(id)) : Forbid();
    }

    [HttpGet, Authorize, Route("myself")]
    public async Task<ActionResult<UserMap>> Myself()
    {
        return HandleResponse(await getUserUseCase.Handle(UserClaims.Id(User)));
    }

    private bool HasAuthorization(int id)
    {
        return UserClaims.Id(User) == id || IsAdmin();
    }
}