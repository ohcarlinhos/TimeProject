using App.Infrastructure.Handlers;
using App.Infrastructure.Integrations;
using App.Infrastructure.Interfaces;
using App.Infrastructure.Mapping;
using App.Infrastructure.Middlewares;
using App.Infrastructure.Services;
using App.Infrastructure.Settings;
using App.Modules.Auth.Repositories;
using App.Modules.Auth.UseCases;
using App.Modules.Category;
using App.Modules.Category.UseCases;
using App.Modules.Category.Utils;
using App.Modules.Codes;
using App.Modules.Codes.UseCases;
using App.Modules.Feedback.UseCases;
using App.Modules.Loogs;
using App.Modules.Loogs.Repositories;
using App.Modules.Loogs.UseCases;
using App.Modules.Statistic;
using App.Modules.Statistic.UseCases;
using App.Modules.TimeMinute;
using App.Modules.TimeMinute.UseCases;
using App.Modules.TimePeriod;
using App.Modules.TimePeriod.UseCases;
using App.Modules.TimePeriod.Utils;
using App.Modules.TimeRecord.Repositories;
using App.Modules.TimeRecord.UseCases;
using App.Modules.TimeRecord.Utils;
using App.Modules.TimerSession;
using App.Modules.TimerSession.UseCases;
using App.Modules.User.Repositories;
using App.Modules.User.UseCases;
using App.Modules.User.Utils;
using Core.Auth.Repositories;
using Core.Auth.UseCases;
using Core.Category;
using Core.Category.UseCases;
using Core.Category.Utils;
using Core.Codes;
using Core.Codes.UseCases;
using Core.Feedback.UseCases;
using Core.Loogs.Repositories;
using Core.Loogs.UserCases;
using Core.Statistic;
using Core.Statistic.UseCases;
using Core.TimeMinute;
using Core.TimeMinute.UseCases;
using Core.TimePeriod;
using Core.TimePeriod.UseCases;
using Core.TimePeriod.Utils;
using Core.TimeRecord.Repositories;
using Core.TimeRecord.UseCases;
using Core.TimeRecord.Utils;
using Core.TimerSession;
using Core.TimerSession.UseCases;
using Core.User.Repositories;
using Core.User.UseCases;
using Core.User.Utils;
using Microsoft.Extensions.Options;

namespace App.Infrastructure.Config;

public static class ServicesConfig
{
    public static void AddServicesConfig(this WebApplicationBuilder builder)
    {
        #region Settings

        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
        builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("Smtp"));

        builder.Services.Configure<TelegramSettings>(builder.Configuration.GetSection("Telegram"));
        builder.Services.Configure<TurnstileSettings>(builder.Configuration.GetSection("Turnstile"));

        builder.Services.AddSingleton(provider => provider.GetRequiredService<IOptions<JwtSettings>>().Value);
        builder.Services.AddSingleton(provider => provider.GetRequiredService<IOptions<SmtpSettings>>().Value);

        builder.Services.AddSingleton(provider => provider.GetRequiredService<IOptions<TelegramSettings>>().Value);
        builder.Services.AddSingleton(provider => provider.GetRequiredService<IOptions<TurnstileSettings>>().Value);

        #endregion

        #region Maps

        builder.Services.AddAutoMapper(typeof(MappingProfile));

        #endregion

        #region Integrations

        builder.Services.AddScoped<ICustomSmtp, CustomSmtp>();
        builder.Services.AddSingleton<ICustomBot, CustomBot>();
        builder.Services.AddSingleton<IUserChallenge, UserChallenge>();

        #endregion

        #region Handlers

        builder.Services.AddScoped<IEmailHandler, EmailHandler>();
        builder.Services.AddScoped<IHookHandler, HookHandler>();

        #endregion

        #region Jwt

        builder.Services.AddSingleton<IJwtService, JwtService>();

        #endregion

        #region User

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserPasswordRepository, UserPasswordRepository>();

        builder.Services.AddScoped<IUserMapDataUtil, UserMapDataUtil>();
        builder.Services.AddScoped<IUpdateUserOptions, UpdateUserOptions>();

        builder.Services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
        builder.Services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
        builder.Services.AddScoped<ICreateUserByGhUserUseCase, CreateUserByGhUserUseCase>();
        builder.Services.AddScoped<ICreateUserByGoogleUserUseCase, CreateUserByGoogleUserUseCase>();
        builder.Services.AddScoped<IUpdateUserRoleUseCase, UpdateUserRoleUseCase>();
        builder.Services
            .AddScoped<ICreateOrUpdateUserPasswordByEmailUseCase, CreateOrUpdateUserPasswordByEmailUseCase>();
        builder.Services.AddScoped<IDisableUserUseCase, DisableUserUseCase>();
        builder.Services.AddScoped<IGetUserUseCase, GetUserUseCase>();
        builder.Services.AddScoped<IGetUserByEmailUseCase, GetUserByEmailUseCase>();
        builder.Services.AddScoped<IGetUserPasswordByEmailUseCase, GetUserPasswordByEmailUseCase>();
        builder.Services.AddScoped<IGetUserByOAtuhProviderIdUseCase, GetUserByOAtuhProviderIdUseCase>();
        builder.Services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
        builder.Services.AddScoped<IGetPaginatedUserUseCase, GetPaginatedUserUseCase>();
        // builder.Services.AddScoped<ISetIsVerifiedUserUseCase, SetIsVerifiedUserUseCase>();

        builder.Services.AddScoped<ICreateOrUpdateUserPasswordUseCase, CreateOrUpdateUserPasswordUseCase>();

        #endregion

        #region Auth

        builder.Services.AddScoped<ILoginUseCase, LoginUseCase>();
        builder.Services.AddScoped<ISendRecoveryEmailUseCase, SendRecoveryEmailUseCase>();
        builder.Services.AddScoped<IRecoveryPasswordUseCase, RecoveryPasswordUseCase>();
        builder.Services.AddScoped<ISendRegisterEmailUseCase, SendRegisterEmailUseCase>();
        // builder.Services.AddScoped<IVerifyUserUseCase, VerifyUserUseCase>();

        #endregion

        #region OAuth

        builder.Services.AddScoped<IOAuthRepository, OAuthRepository>();
        builder.Services.AddScoped<ILoginGithubUseCase, LoginGithubUseCase>();
        builder.Services.AddScoped<ILoginGoogleUseCase, LoginGoogleUseCase>();

        #endregion

        #region TimeRecord

        builder.Services.AddScoped<ITimeRecordRepository, TimeRecordRepository>();
        builder.Services.AddScoped<ITimeRecordMetaRepository, TimeRecordMetaRepository>();
        builder.Services.AddScoped<ITimeRecordHistoryRepository, TimeRecordHistoryRepository>();

        builder.Services.AddScoped<ITimeRecordMapDataUtil, TimeRecordMapDataUtil>();

        builder.Services.AddScoped<IGetTimeRecordHistoryUseCase, GetTimeRecordHistoryUseCase>();

        builder.Services.AddScoped<IGetPaginatedTimeRecordUseCase, GetPaginatedTimeRecordUseCase>();
        builder.Services.AddScoped<IGetTimeRecordByCodeUseCase, GetTimeRecordByCodeUseCase>();
        builder.Services.AddScoped<IGetTimeRecordByIdUseCase, GetTimeRecordByIdUseCase>();
        builder.Services.AddScoped<ICreateTimeRecordUseCase, CreateTimeRecordUseCase>();
        builder.Services.AddScoped<IUpdateTimeRecordUseCase, UpdateTimeRecordUseCase>();
        builder.Services.AddScoped<IDeleteTimeRecordUseCase, DeleteTimeRecordUseCase>();
        builder.Services.AddScoped<ISearchTimeRecordUseCase, SearchTimeRecordUseCase>();

        builder.Services.AddScoped<ISyncTrMetaUseCase, SyncTrMetaUseCase>();
        builder.Services.AddScoped<ISyncAllTrMetaUseCase, SyncAllTrMetaUseCase>();

        #endregion

        #region TimerSession

        builder.Services.AddScoped<ITimerSessionRepository, TimerSessionRepository>();
        builder.Services.AddScoped<IDeleteTimerSessionUseCase, DeleteTimerSessionUseCase>();

        #endregion

        #region TimePeriod

        builder.Services.AddScoped<ITimePeriodRepository, TimePeriodRepository>();

        builder.Services.AddScoped<ITimePeriodMapDataUtil, TimePeriodMapDataUtil>();
        builder.Services.AddScoped<ITimePeriodCutUtil, TimePeriodCutUtil>();
        builder.Services.AddScoped<ITimePeriodValidateUtil, TimePeriodValidateUtil>();

        builder.Services.AddScoped<IGetPaginatedTimePeriodUseCase, GetPaginatedTimePeriodUseCase>();
        builder.Services.AddScoped<ICreateTimePeriodByListUseCase, CreateTimePeriodByListUseCase>();
        builder.Services.AddScoped<ICreateTimePeriodUseCase, CreateTimePeriodUseCase>();
        builder.Services.AddScoped<IUpdateTimePeriodUseCase, UpdateTimePeriodUseCase>();
        builder.Services.AddScoped<IDeleteTimePeriodUseCase, DeleteTimePeriodUseCase>();

        #endregion

        #region Category

        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ICategoryMapDataUtil, CategoryMapDataUtil>();

        builder.Services.AddScoped<ICreateCategoryUseCase, CreateCategoryUseCase>();
        builder.Services.AddScoped<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
        builder.Services.AddScoped<IGetAllCategoryUseCase, GetAllCategoryUseCase>();
        builder.Services.AddScoped<IGetPaginatedCategoryUseCase, GetPaginatedCategoryUseCase>();
        builder.Services.AddScoped<IUpdateCategoryUseCase, UpdateCategoryUseCase>();

        #endregion

        #region Code

        builder.Services.AddScoped<IConfirmCodeRepository, ConfirmCodeRepository>();

        builder.Services.AddScoped<ICreateConfirmCodeUseCase, CreateConfirmCodeUseCase>();
        builder.Services.AddScoped<IValidateConfirmCodeUseCase, ValidateConfirmCodeUseCase>();
        builder.Services.AddScoped<ISetIsUsedConfirmCodeUseCase, SetIsUsedConfirmCodeUseCase>();
        builder.Services.AddScoped<ISetWasSentConfirmCodeUseCase, SetWasSentConfirmCodeUseCase>();
        builder.Services.AddScoped<IGetRegisterCodeInfoUseCase, GetRegisterCodeInfoUseCase>();

        #endregion

        #region Statistics

        builder.Services.AddScoped<IStatisticRepository, StatisticRepository>();
        builder.Services.AddScoped<IGetDayStatisticUseCase, GetDayStatisticUseCase>();

        #endregion

        #region Feedback

        builder.Services.AddScoped<ISendFeedbackUseCase, SendFeedbackUseCase>();
        builder.Services.AddScoped<ISendPublicFeedbackUseCase, SendPublicFeedbackUseCase>();

        #endregion

        #region TimeMinute

        builder.Services.AddScoped<ITimeMinuteRepository, TimeMinuteRepository>();
        builder.Services.AddScoped<ICreateTimeMinuteByListUseCase, CreateTimeMinuteByListUseCase>();
        builder.Services.AddScoped<IDeleteTimeMinuteUseCase, DeleteTimeMinuteUseCase>();

        #endregion

        #region Logs

        builder.Services.AddScoped<IUserAccessLogRepository, UserAccessLogRepository>();
        builder.Services.AddScoped<ICreateUserAccessLog, CreateUserAccessLog>();

        #endregion
        
        #region Middlewares

        builder.Services.AddSingleton<UserChallengeMiddleware>();

        #endregion
    }
}