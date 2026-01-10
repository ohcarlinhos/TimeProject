using Microsoft.AspNetCore.Mvc;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.RemoveDependencies.General.Util;

namespace TimeProject.Api.Controllers.Shared;

public class CustomController : ControllerBase
{
    protected ActionResult<T> HandleResponse<T>(Result<T> result)
    {
        if (!string.IsNullOrEmpty(result.ActionName) && result.IsValid)
            return CreatedAtAction(result.ActionName, result.Data);

        if (result.IsValid) return Ok(result.Data);

        var messageSplit = result.Message?.Split(":") ?? ["generic_error"];
        var errorResponse = new ErrorResult { Message = messageSplit[^1] };

        var code = messageSplit[0];

        if (code.Contains("forbidden")) return Forbid();
        if (code.Contains("bad_request")) return BadRequest(errorResponse);
        if (code.Contains("not_found")) return NotFound(errorResponse);
        if (code.Contains("unauthorized")) return Unauthorized();
        if (code.Contains("server_error")) return StatusCode(500, errorResponse);
        return BadRequest(errorResponse);
    }

    protected bool IsAdmin()
    {
        return UserRole.Admin.ToString() == UserClaims.Role(User);
    }

    protected bool HasAuthorization(int id)
    {
        return UserClaims.Id(User) == id || IsAdmin();
    }

    public string? GetClientIpAddress(HttpContext context)
    {
        var headers = new[] { "X-Forwarded-For", "X-Real-IP", "CF-Connecting-IP" };

        foreach (var header in headers)
            if (context.Request.Headers.TryGetValue(header, out var headerValue))
                return headerValue.FirstOrDefault()?.Split(',').FirstOrDefault()?.Trim();

        return context.Connection.RemoteIpAddress?.ToString();
    }
}