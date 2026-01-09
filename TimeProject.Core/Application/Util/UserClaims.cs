using System.Security.Claims;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Application.General.Util;

public static class UserClaims
{
    public static int Id(ClaimsPrincipal p)
    {
        return int.Parse(GetValue(p, "id") ?? "-1");
    }

    public static string Name(ClaimsPrincipal p)
    {
        return GetValue(p, ClaimTypes.Name) ?? "";
    }

    public static string Email(ClaimsPrincipal p)
    {
        return GetValue(p, ClaimTypes.Email) ?? "";
    }

    public static bool IsVerified(ClaimsPrincipal p)
    {
        return bool.Parse(GetValue(p, "isVerified") ?? "False");
    }

    public static string Role(ClaimsPrincipal p)
    {
        return GetValue(p, ClaimTypes.Role) ?? UserRole.Normal.ToString();
    }

    private static string? GetValue(ClaimsPrincipal p, string type)
    {
        return p.Claims.FirstOrDefault(claim => claim.Type == type)?.Value ?? null;
    }
}