using API.Database;
using API.Infrastructure.Util;
using API.Modules.Shared.Controllers;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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
}