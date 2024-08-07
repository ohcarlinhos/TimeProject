using System.Security.Claims;

namespace API.Infrastructure.Util;

public static class UserClaims
{
    public static int Id(ClaimsPrincipal userClaimsPrincipal)
    {
        return int.Parse(userClaimsPrincipal.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
    }
    
    public static string Role(ClaimsPrincipal userClaimsPrincipal)
    {
        return userClaimsPrincipal.Claims.First(claim => claim.Type == ClaimTypes.Role).Value;
    }
}