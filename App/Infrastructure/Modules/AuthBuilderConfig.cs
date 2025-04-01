using App.Modules.Auth.UseCases;
using App.Modules.User.UseCases;
using Core.Auth.UseCases;
using Core.User.UseCases;

namespace App.Infrastructure.Modules;

public static class AuthBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ILoginUseCase, LoginUseCase>();
        builder.Services.AddScoped<ISendRecoveryEmailUseCase, SendRecoveryEmailUseCase>();
        builder.Services.AddScoped<IRecoveryPasswordUseCase, RecoveryPasswordUseCase>();
        builder.Services.AddScoped<ISendRegisterEmailUseCase, SendRegisterEmailUseCase>();
        // builder.Services.AddScoped<IVerifyUserUseCase, VerifyUserUseCase>();
    }
}