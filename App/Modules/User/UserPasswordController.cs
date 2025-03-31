using App.Database;
using App.Infrastructure.Attributes;
using Core.User.UseCases;
using App.Infrastructure.Controllers;
using App.Modules.User.Utils;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.User;

namespace App.Modules.User;

[ApiController]
[Route("api/user/password")]
public class UserPasswordController(
    IUpdateUserUseCase updateUserUseCase,
    ICreateOrUpdateUserPasswordUseCase createOrUpdateUserPasswordUseCase,
    IRecoveryPasswordUseCase recoveryPasswordUseCase,
    ProjectContext db
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

    [HttpPut("panel/{id:int}")]
    [Authorize(Policy = "IsAdmin")]
    public async Task<ActionResult<UserMap>> UpdateFromPanel([FromRoute] int id,
        [FromBody] UpdatePasswordPanelDto panelDto)
    {
        return HandleResponse(await updateUserUseCase.Handle(
            id,
            new UpdateUserDto { Password = panelDto.Password },
            new UpdateUserOptions { SkipOldPasswordCompare = true })
        );
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