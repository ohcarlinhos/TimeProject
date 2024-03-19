using System.Security.Claims;

namespace API.Infrastructure.Services;

public static class AuthorizeService
{
    public static int GetUsuarioId(ClaimsPrincipal user)
    {
        return int.Parse(user.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value);
    }
}