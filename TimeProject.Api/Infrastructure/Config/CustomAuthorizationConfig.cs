using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TimeProject.Infrastructure.Settings;

namespace TimeProject.Api.Infrastructure.Config;

public static class CustomAuthorizationConfig
{
    public static void AddCustomAuthorizationConfig(this WebApplicationBuilder builder)
    {
        var settings = builder.Configuration.GetRequiredSection("Jwt").Get<JwtSettings>();

        builder.Services
            .AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(bearerOptions =>
            {
                bearerOptions.RequireHttpsMetadata = false;
                bearerOptions.SaveToken = true;
                bearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(settings!.Secret))
                };
            });

        builder.Services.AddAuthorizationBuilder()
            .AddPolicy("IsAdmin", p =>
                p.RequireClaim("isAdmin", "True"))
            .AddPolicy("IsActive", p =>
                p.RequireClaim("isActive", "True"));
    }
}