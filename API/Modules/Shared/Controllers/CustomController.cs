using API.Infrastructure.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Shared.Controllers;

public class CustomController : ControllerBase
{
    protected ActionResult<T> HandleResponse<T>(Result<T> result)
    {
        if (result.IsValid)
            return Ok(result.Data);

        var errorResponse = new HttpErrorResponse() { Message = result.Message };
        if (result.Message!.Contains("not_found")) return NotFound(errorResponse);
        if (result.Message!.Contains("unauthorized")) return Unauthorized();
        return BadRequest(errorResponse);
    }
}