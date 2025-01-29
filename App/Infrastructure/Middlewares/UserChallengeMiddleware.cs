using System.Text.Json;
using App.Infrastructure.Attributes;
using App.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.IdentityModel.Tokens;

namespace App.Infrastructure.Middlewares;

public class UserChallengeMiddleware(IUserChallenge userChallenge) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var controllerAction = context.GetEndpoint()?.Metadata.GetMetadata<ControllerActionDescriptor>();

        if (controllerAction?.MethodInfo
                .GetCustomAttributes(typeof(UserChallengeAttribute), false)
                .FirstOrDefault() is UserChallengeAttribute { IgnoreAdmin: false } userChallengeAttrubute
           )
        {
            context.Request.Headers.TryGetValue("UserChallengeToken", out var token);

            if (token.IsNullOrEmpty() ||
                (token.IsNullOrEmpty() && await userChallenge.Test(token.ToString()) == false))
            {
                SetTokenError(context);
                return;
            }
        }

        await next(context);
    }

    private static void SetTokenError(HttpContext context)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        context.Response.WriteAsync(JsonSerializer.Serialize(new { message = "need_user_challenge_token" }));
    }
}