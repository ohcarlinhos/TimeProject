using System.Security.Claims;

namespace API.Infrastructure.Services;

public static class AuthorizeService
{
    public static int GetUserId(ClaimsPrincipal userClaimsPrincipal)
    {
        return int.Parse(userClaimsPrincipal.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value);
    }
}