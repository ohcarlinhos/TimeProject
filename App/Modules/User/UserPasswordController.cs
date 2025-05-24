using Core.User.UseCases;
using App.Infrastructure.Controllers;
using App.Modules.User.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.User;

namespace App.Modules.User;

[ApiController]
[Route("api/user/password")]
public class UserPasswordController(
    IUpdateUserUseCase updateUserUseCase,
    ICreateOrUpdateUserPasswordUseCase createOrUpdateUserPasswordUseCase,
    IRecoveryPasswordUseCase recoveryPasswordUseCase
) : CustomController
{
    [HttpPut("{id:int}")]
    [Authorize(Policy = "IsActive")]
    public async Task<ActionResult<bool>> Update([FromRoute] int id, [FromBody] UpdatePasswordDto dto)
    {
        return HasAuthorization(id)
            ? HandleResponse(await createOrUpdateUserPasswordUseCase.Handle(id, dto))
            : Forbid();
    }

    [HttpPut("admin/{id:int}")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<ActionResult<bool>> UpdateByAdmin(
        [FromRoute] int id,
        [FromBody] UpdateByAdminPasswordDto dto
    )
    {
        return HandleResponse(await createOrUpdateUserPasswordUseCase.Handle(id, dto));
    }

    [HttpPost, Route("recovery")]
    public async Task<ActionResult<bool>> Recovery([FromBody] RecoveryPasswordDto dto)
    {
        return HandleResponse(await recoveryPasswordUseCase.Handle(dto));
    }

    // [HttpPost, Route("copy/to/new/table")]
    // [Authorize(Policy = "IsAdmin")]
    // public async Task<ActionResult<bool>> CopyToNewTable()
    // {
    //     var now = DateTime.Now.ToUniversalTime();
    //     
    //     var users = await db.Users
    //         .Select(e => new UserPasswordEntity { UserId = e.Id, Password = e.Password!, CreatedAt = now, UpdatedAt = now})
    //         .ToListAsync();
    //
    //     var migratedPasswords = await db.UserPasswords.Select(e => e.UserId).ToListAsync();
    //
    //     users.RemoveAll(e => migratedPasswords.Contains(e.UserId));
    //
    //     await db.UserPasswords.AddRangeAsync(users);
    //     await db.SaveChangesAsync();
    //     return Ok();
    // }
}