using App.Modules.Feedback.UseCases;
using Core.Feedback.UseCases;

namespace App.Infrastructure.Modules;

public static class FeedbackBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ISendFeedbackUseCase, SendFeedbackUseCase>();
        builder.Services.AddScoped<ISendPublicFeedbackUseCase, SendPublicFeedbackUseCase>();
     }
}