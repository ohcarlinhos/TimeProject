using API.Infrastructure.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace API.Modules.Shared.Controllers;

public class CustomController : ControllerBase
{
    protected ActionResult<T> HandleResponse<T>(Result<T> result)
    {
        if (string.IsNullOrEmpty(result.ActionName) && result.IsValid)
        {
            return CreatedAtAction(result.ActionName, result.Data);
        }

        if (result.IsValid) return Ok(result.Data);

        var errorResponse = new HttpErrorResponse() { Message = result.Message };
        if (result.Message!.Contains("not_found")) return NotFound(errorResponse);
        if (result.Message!.Contains("unauthorized")) return Unauthorized();
        return BadRequest(errorResponse);
    }
}