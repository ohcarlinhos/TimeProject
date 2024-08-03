using API.Database;
using API.Modules.Shared;
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
        if (UserRole.Admin.ToString() == UserSession.Role(User))
            return Ok(dbContext.RegisterCodes.Include((e) => e.User).ToList());

        return Unauthorized();
    }
}