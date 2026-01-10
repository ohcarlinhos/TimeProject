using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Controllers;
using TimeProject.Api.Infrastructure.Interfaces;
using TimeProject.APIs.Controllers.Attributes;
using TimeProject.Infrastructure.Interfaces;

namespace TimeProject.APIs.Controllers.Middlewares;

public class UserChallengeMiddleware(IUserChallenge userChallenge) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
        {
            await next(context);
            return;
        }

        var controllerAction = context.GetEndpoint()?.Metadata.GetMetadata<ControllerActionDescriptor>();

        if (controllerAction?.MethodInfo
                .GetCustomAttributes(typeof(UserChallengeAttribute), false)
                .FirstOrDefault() is UserChallengeAttribute { IgnoreAdmin: false } userChallengeAttrubute
           )
        {
            context.Request.Headers.TryGetValue("UserChallengeToken", out var token);

            if (string.IsNullOrEmpty(token) || (
                    string.IsNullOrEmpty(token) && await userChallenge.Test(token.ToString()) == false)
               )
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