using Entities;
using Shared.General.Util;

namespace App.Infrastructure.Middlewares;

public class IsAdminOrTheUserMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var controller = context.GetRouteData();
        var value = controller.Values.FirstOrDefault(e => e.Key == "id").Value?.ToString();
        int? id = value != null ? int.Parse(value) : null;

        if (id != null && (UserRole.Admin.ToString() == UserClaims.Role(context.User) ||
                           UserClaims.Id(context.User) == id))
        {
            await next(context);
            return;
        }
        
        SetError(context);
    }

    private static void SetError(HttpContext context)
    {
        context.Response.StatusCode = StatusCodes.Status403Forbidden;
    }
}