using Core.Codes;
using Core.Codes.UseCases;
using App.Modules.Codes;
using App.Modules.Codes.UseCases;

namespace App.Infrastructure.Modules;

public static class CodeBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IConfirmCodeRepository, ConfirmCodeRepository>();

        builder.Services.AddScoped<ICreateConfirmCodeUseCase, CreateConfirmCodeUseCase>();
        builder.Services.AddScoped<IValidateConfirmCodeUseCase, ValidateConfirmCodeUseCase>();
        builder.Services.AddScoped<ISetIsUsedConfirmCodeUseCase, SetIsUsedConfirmCodeUseCase>();
        builder.Services.AddScoped<ISetWasSentConfirmCodeUseCase, SetWasSentConfirmCodeUseCase>();
        builder.Services.AddScoped<IGetRegisterCodeInfoUseCase, GetRegisterCodeInfoUseCase>();
    }
}