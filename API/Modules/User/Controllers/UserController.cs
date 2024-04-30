using API.Infrastructure.Services;
using API.Modules.Shared.Controllers;
using API.Modules.User.DTO;
using API.Modules.User.Models;
using API.Modules.User.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.User.Controllers;

[ApiController]
[Route("api/user")]
public class UserController(IUserServices userServices) : CustomController
{
    [HttpPost]
    public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserModel model)
    {
        return HandleResponse(await userServices.Create(model));
    }

    [HttpPut("{id}"), Authorize]
    public async Task<ActionResult<UserDto>> Update([FromRoute] int id, [FromBody] UpdateUserModel model)
    {
        if (AuthorizeService.GetUserId(User) != id) return Unauthorized();
        return HandleResponse(await userServices.Update(id, model));
    }

    [HttpDelete("{id}"), Authorize]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
        if (AuthorizeService.GetUserId(User) != id) return Unauthorized();
        return HandleResponse(await userServices.Delete(id));
    }

    [HttpGet, Authorize, Route("{id}")]
    public async Task<ActionResult<UserDto>> Get(int id)
    {
        return HandleResponse(await userServices.Get(id));
    }

    [HttpGet, Authorize, Route("myself")]
    public async Task<ActionResult<UserDto>> Myself()
    {
        return HandleResponse(await userServices
            .Get(AuthorizeService.GetUserId(User)));
    }
}