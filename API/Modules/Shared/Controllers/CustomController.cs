using API.Infrastructure.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace API.Modules.Shared.Controllers;

public class CustomController : ControllerBase
{
    protected ActionResult<T> HandleResponse<T>(Result<T> result)
    {

        string?[] message  = result.Message.Split(":");
        
        if (string.IsNullOrEmpty(result.ActionName) && result.IsValid)
        {
            return CreatedAtAction(result.ActionName, result.Data);
        }

        if (result.IsValid) return Ok(result.Data);

        var errorResponse = new HttpErrorResponse() { Message = message[1] ?? message[0] };
        if (message[0]!.Contains("not_found")) return NotFound(errorResponse);
        if (message[0]!.Contains("unauthorized")) return Unauthorized();
        return BadRequest(errorResponse);
    }
}