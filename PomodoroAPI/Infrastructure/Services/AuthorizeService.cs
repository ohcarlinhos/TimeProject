using System.Security.Claims;

namespace PomodoroAPI.Infrastructure.Services;

public static class AuthorizeService
{
    public static int GetUserId(ClaimsPrincipal user)
    {
        return int.Parse(user.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value);
    }
}