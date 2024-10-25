using System.Security.Claims;
using Entities;

namespace Shared.General.Util;

public static class UserClaims
{
    public static int Id(ClaimsPrincipal userClaimsPrincipal)
    {
        return int.Parse(userClaimsPrincipal
            .Claims.FirstOrDefault(claim => claim.Type == "id")?.Value ?? "-1");
    }

    public static string Email(ClaimsPrincipal userClaimsPrincipal)
    {
        return userClaimsPrincipal.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value ?? "";
    }

    public static string Role(ClaimsPrincipal userClaimsPrincipal)
    {
        return userClaimsPrincipal
            .Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role)?.Value ?? UserRole.Normal.ToString();
    }
}