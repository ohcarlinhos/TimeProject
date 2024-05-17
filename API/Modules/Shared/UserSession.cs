using System.Security.Claims;

namespace API.Modules.Shared;

public static class UserSession
{
    public static int Id(ClaimsPrincipal userClaimsPrincipal)
    {
        return int.Parse(userClaimsPrincipal.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
    }
}