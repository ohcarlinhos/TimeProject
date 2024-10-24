using API.Core.Codes;
using API.Core.Codes.UseCases;
using API.Modules.Codes;
using API.Modules.Codes.UseCases;

namespace API.Infra.Modules;

public static class CodeBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IConfirmCodeRepository, ConfirmCodeRepository>();

        builder.Services.AddScoped<ICreateRecoveryCodeUseCase, CreateRecoveryCodeUseCase>();
        builder.Services.AddScoped<IValidateConfirmCodeUseCase, ValidateConfirmCodeUseCase>();
        builder.Services.AddScoped<ISetIsUsedConfirmCodeUseCase, SetIsUsedConfirmCodeUseCase>();
        builder.Services.AddScoped<ISetWasSentConfirmCodeUseCase, SetWasSentConfirmCodeUseCase>();
    }
}