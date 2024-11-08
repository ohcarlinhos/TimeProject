using App.Modules.Auth.UseCases;
using Core.Auth.UseCases;

namespace App.Infra.Modules;

public static class AuthBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ILoginUseCase, LoginUseCase>();
        builder.Services.AddScoped<ISendRecoveryEmailUseCase, SendRecoveryEmailUseCase>();
        builder.Services.AddScoped<IRecoveryPasswordUseCase, RecoveryPasswordUseCase>();
        builder.Services.AddScoped<ISendRegisterEmailUseCase, SendRegisterEmailUseCase>();
        builder.Services.AddScoped<IVerifyUserUseCase, VerifyUserUseCase>();
    }
}