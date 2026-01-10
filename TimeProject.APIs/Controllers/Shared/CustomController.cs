using Microsoft.AspNetCore.Mvc;
using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.RemoveDependencies.Util;
using TimeProject.Domain.Shared;

namespace TimeProject.APIs.Controllers.Shared;

public class CustomController : ControllerBase
{
    protected ActionResult<T> HandleResponse<T>(ICustomResult<T> customResult)
    {
        if (!string.IsNullOrEmpty(customResult.ActionName) && customResult.IsValid)
            return CreatedAtAction(customResult.ActionName, customResult.Data);

        if (customResult.IsValid) return Ok(customResult.Data);

        var messageSplit = customResult.Message?.Split(":") ?? ["generic_error"];
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