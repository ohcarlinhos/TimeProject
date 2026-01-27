using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TimeProject.Infrastructure.Settings;

namespace TimeProject.APIs.Configurations;

public static class CustomAuthorizationConfiguration
{
    public static IServiceCollection AddCustomAuthorizationConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetRequiredSection("JwtSettings").Get<JwtSettings>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(bearerOptions =>
        {
            bearerOptions.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings!.Secret))
            };
        });
        
        services.AddAuthorizationBuilder()
            .AddPolicy("IsAdmin", cp =>
                cp.RequireClaim("IsAdmin", "True"))
            .AddPolicy("IsActive", cp =>
                cp.RequireClaim("IsActive", "True"));

        return services;
    }
}