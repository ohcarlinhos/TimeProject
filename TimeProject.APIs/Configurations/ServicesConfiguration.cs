using Microsoft.Extensions.Options;
using TimeProject.APIs.Controllers.Middlewares;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Application.UseCases.Auths;
using TimeProject.Application.UseCases.Categories;
using TimeProject.Application.UseCases.Codes;
using TimeProject.Application.UseCases.CustomLogs;
using TimeProject.Application.UseCases.Feedbacks;
using TimeProject.Application.UseCases.Statistics;
using TimeProject.Application.UseCases.Minutes;
using TimeProject.Application.UseCases.Periods;
using TimeProject.Application.UseCases.Records;
using TimeProject.Application.UseCases.Sessions;
using TimeProject.Application.UseCases.Users;
using TimeProject.Domain.Dtos.Categories;
using TimeProject.Domain.Dtos.Records;
using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Categories;
using TimeProject.Domain.UseCases.Codes;
using TimeProject.Domain.UseCases.CustomLogs;
using TimeProject.Domain.UseCases.Feedbacks;
using TimeProject.Domain.UseCases.Logins;
using TimeProject.Domain.UseCases.Statistics;
using TimeProject.Domain.UseCases.Minutes;
using TimeProject.Domain.UseCases.Periods;
using TimeProject.Domain.UseCases.Records;
using TimeProject.Domain.UseCases.Sessions;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Infrastructure.Handlers;
using TimeProject.Infrastructure.Integrations;
using TimeProject.Infrastructure.Interfaces;
using TimeProject.Infrastructure.Mapping;
using TimeProject.Infrastructure.ObjectValues.Categories;
using TimeProject.Infrastructure.ObjectValues.Records;
using TimeProject.Infrastructure.ObjectValues.Users;
using TimeProject.Infrastructure.Repositories;
using TimeProject.Infrastructure.Settings;
using TimeProject.Infrastructure.Utils;
using TimeProject.Infrastructure.Utils.Interfaces;

namespace TimeProject.APIs.Configurations;

public static class ServicesConfiguration
{
    public static void AddServicesConfig(this WebApplicationBuilder builder)
    {
        #region Settings

        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
        builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("Smtp"));

        builder.Services.Configure<TelegramSettings>(builder.Configuration.GetSection("Telegram"));
        builder.Services.Configure<TurnstileSettings>(builder.Configuration.GetSection("Turnstile"));

        builder.Services.AddSingleton(provider => provider.GetRequiredService<IOptions<JwtSettings>>().Value);
        builder.Services.AddSingleton(provider => provider.GetRequiredService<IOptions<SmtpSettings>>().Value);

        builder.Services.AddSingleton(provider => provider.GetRequiredService<IOptions<TelegramSettings>>().Value);
        builder.Services.AddSingleton(provider => provider.GetRequiredService<IOptions<TurnstileSettings>>().Value);

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        
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

        builder.Services.AddSingleton<IJwtHandler, JwtHandler>();

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

        builder.Services.AddScoped<IUserProviderRepository, UserProviderRepository>();
        builder.Services.AddScoped<ILoginGithubUseCase, LoginGithubUseCase>();
        builder.Services.AddScoped<ILoginGoogleUseCase, LoginGoogleUseCase>();

        #endregion

        #region Records

        builder.Services.AddScoped<IRecordRepository, RecordRepository>();
        builder.Services.AddScoped<IRecordResumeRepository, RecordResumeRepository>();
        builder.Services.AddScoped<IRecordHistoryRepository, RecordHistoryRepository>();

        builder.Services.AddScoped<IRecordMapDataUtil, RecordMapDataUtil>();

        builder.Services.AddScoped<IGetRecordHistoryUseCase, GetRecordHistoryUseCase>();

        builder.Services.AddScoped<IGetPaginatedRecordUseCase, GetPaginatedRecordUseCase>();
        builder.Services.AddScoped<IGetRecordByCodeUseCase, GetRecordByCodeUseCase>();
        builder.Services.AddScoped<IGetRecordByIdUseCase, GetRecordByIdUseCase>();
        builder.Services.AddScoped<ICreateRecordUseCase, CreateRecordUseCase>();
        builder.Services.AddScoped<IUpdateRecordUseCase, UpdateRecordUseCase>();
        builder.Services.AddScoped<IDeleteRecordUseCase, DeleteRecordUseCase>();
        builder.Services.AddScoped<ISearchRecordUseCase, SearchRecordUseCase>();

        builder.Services.AddScoped<ISyncRecordResumeUseCase, SyncRecordResumeUseCase>();
        builder.Services.AddScoped<ISyncAllRecordResumeUseCase, SyncAllRecordResumeUseCase>();

        #endregion

        #region TimerSession

        builder.Services.AddScoped<ISessionRepository, SessionRepository>();
        builder.Services.AddScoped<IDeleteSessionUseCase, DeleteSessionUseCase>();

        #endregion

        #region Period

        builder.Services.AddScoped<IPeriodRepository, PeriodRepository>();

        builder.Services.AddScoped<IPeriodMapDataUtil, PeriodMapDataUtil>();
        builder.Services.AddScoped<IPeriodCutUtil, PeriodCutUtil>();
        builder.Services.AddScoped<IPeriodValidateUtil, PeriodValidateUtil>();

        builder.Services.AddScoped<IGetPaginatedPeriodUseCase, GetPaginatedPeriodUseCase>();
        builder.Services.AddScoped<ICreatePeriodByListUseCase, CreatePeriodByListUseCase>();
        builder.Services.AddScoped<ICreatePeriodUseCase, CreatePeriodUseCase>();
        builder.Services.AddScoped<IUpdatePeriodUseCase, UpdatePeriodUseCase>();
        builder.Services.AddScoped<IDeletePeriodUseCase, DeletePeriodUseCase>();

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
        builder.Services.AddScoped<IGetRangeDaysStatisticUseCase, GetRangeDaysStatisticUseCase>();

        #endregion

        #region Feedback

        builder.Services.AddScoped<ISendFeedbackUseCase, SendFeedbackUseCase>();
        builder.Services.AddScoped<ISendPublicFeedbackUseCase, SendPublicFeedbackUseCase>();

        #endregion

        #region TimeMinute

        builder.Services.AddScoped<IMinuteRepository, MinuteRepository>();
        builder.Services.AddScoped<ICreateMinuteByListUseCase, CreateMinuteByListUseCase>();
        builder.Services.AddScoped<IDeleteMinuteUseCase, DeleteMinuteUseCase>();

        #endregion

        #region Logs

        builder.Services.AddScoped<IUserAccessLogRepository, UserAccessLogRepository>();
        builder.Services.AddScoped<ICreateUserAccessLogUseCase, CreateUserAccessLogUseCase>();

        #endregion

        #region Middlewares

        builder.Services.AddSingleton<UserChallengeMiddleware>();

        #endregion
    }
}