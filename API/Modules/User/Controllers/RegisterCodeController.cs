using API.Database;
using API.Modules.Shared.Controllers;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Shared.General.Util;
using Shared.User;

namespace API.Modules.User.Controllers;

[ApiController]
[Route("api/register-code")]
public class RegisterCodeController(ProjectContext dbContext) : CustomController
{
    [HttpGet, Authorize]
    public ActionResult<List<RegisterCode>> Index()
    {
        if (UserRole.Admin.ToString() == UserClaims.Role(User))
            return Ok(dbContext.RegisterCodes.Include((e) => e.User).ToList());

        return Forbid();
    }

    [HttpPost, Authorize]
    public async Task<ActionResult<RegisterCode>> Create(CreateRegisterCodeDto _)
    {
        if (UserRole.Admin.ToString() != UserClaims.Role(User))
            return Forbid();

        var registerCode = new RegisterCode();
        dbContext.RegisterCodes.Add(registerCode);
        await dbContext.SaveChangesAsync();
        return Ok(registerCode);
    }
}