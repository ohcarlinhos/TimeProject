using App.Infrastructure.Attributes;
using Core.User.UseCases;
using App.Infrastructure.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.General.Pagination;
using Shared.General.Util;
using Shared.User;

namespace App.Modules.User;

[ApiController]
[Route("api/user")]
public class UserController(
    ICreateUserUseCase createUserUseCase,
    IUpdateUserUseCase updateUserUseCase,
    IUpdateUserRoleUseCase updateUserRoleUseCase,
    IDisableUserUseCase disableUserUseCase,
    IGetUserUseCase getUserUseCase,
    IDeleteUserUseCase deleteUserUseCase,
    IGetPaginatedUserUseCase getPaginatedUserUseCase,
    ISendRecoveryEmailUseCase sendRecoveryEmailUseCase,
    ISendRegisterEmailUseCase sendRegisterEmailUseCase
) : CustomController
{
    [HttpGet]
    [Authorize(Policy = "IsAdmin")]
    public ActionResult<Pagination<UserMap>> Index([FromQuery] PaginationQuery paginationQuery)
    {
        return HandleResponse(getPaginatedUserUseCase.Handle(paginationQuery));
    }

    [HttpPost, UserChallenge]
    public async Task<ActionResult<CreateUserResult>> Create([FromBody] CreateUserDto dto)
    {
        var result = await createUserUseCase.Handle(dto);
        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPut("{id:int}")]
    [Authorize(Policy = "IsActive")]
    public async Task<ActionResult<UserMap>> Update([FromRoute] int id, [FromBody] UpdateUserDto dto)
    {
        return HasAuthorization(id) ? HandleResponse(await updateUserUseCase.Handle(id, dto)) : Forbid();
    }

    [HttpPut("role/{id:int}")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<ActionResult<UserMap>> UpdateRole([FromRoute] int id, [FromBody] UpdateRoleDto dto)
    {
        return HandleResponse(await updateUserRoleUseCase.Handle(id, dto));
    }

    [Authorize(Policy = "IsActive")]
    [HttpPost("disable/{id:int}")]
    public async Task<ActionResult<bool>> Disable([FromRoute] int id, [FromBody] DisableUserDto dto)
    {
        return HasAuthorization(id) ? HandleResponse(await disableUserUseCase.Handle(id, dto)) : Forbid();
    }

    [HttpDelete("{id:int}")]
    [Authorize(Policy = "IsActive")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
        return HasAuthorization(id) ? HandleResponse(await deleteUserUseCase.Handle(id)) : Forbid();
    }

    [HttpGet, Route("{id:int}")]
    [Authorize(Policy = "IsActive")]
    public async Task<ActionResult<UserMap>> Get(int id)
    {
        return HasAuthorization(id) ? HandleResponse(await getUserUseCase.Handle(id)) : Forbid();
    }

    [HttpGet, Authorize(Policy = "IsActive"), Route("myself")]
    public async Task<ActionResult<UserMap>> Myself()
    {
        return HandleResponse(await getUserUseCase.Handle(UserClaims.Id(User)));
    }
    
    [HttpPost, Route("recovery")]
    public async Task<ActionResult<bool>> Recovery([FromBody] RecoveryDto dto)
    {
        return HandleResponse(await sendRecoveryEmailUseCase.Handle(dto.Email));
    }

    [HttpPost, Route("verify")]
    [Authorize(Policy = "IsActive")]
    public async Task<ActionResult<bool>> Verify()
    {
        return HandleResponse(await sendRegisterEmailUseCase.Handle(UserClaims.Email(User)));
    }

    // [HttpPost, Route("verify/{code}")]
    // [Authorize(Policy = "IsActive")]
    // public async Task<ActionResult<bool>> VerifyUser(string code)
    // {
    //     return HandleResponse(await verifyUserUseCase.Handle(UserClaims.Id(User), UserClaims.Email(User), code));
    // }
}