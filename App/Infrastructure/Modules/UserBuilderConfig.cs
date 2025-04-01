using Core.User;
using Core.User.UseCases;
using Core.User.Utils;
using App.Modules.User.Repositories;
using App.Modules.User.UseCases;
using App.Modules.User.Utils;
using Core.User.Repositories;

namespace App.Infrastructure.Modules;

public static class UserBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped <IUserPasswordRepository, UserPasswordRepository>();
        
        builder.Services.AddScoped<IUserMapDataUtil, UserMapDataUtil>();
        builder.Services.AddScoped<IUpdateUserOptions, UpdateUserOptions>();
        
        builder.Services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
        builder.Services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
        builder.Services.AddScoped<IUpdateUserRoleUseCase, UpdateUserRoleUseCase>();
        builder.Services.AddScoped<ICreateOrUpdateUserPasswordByEmailUseCase, CreateOrUpdateUserPasswordByEmailUseCase>();
        builder.Services.AddScoped<IDisableUserUseCase, DisableUserUseCase>();
        builder.Services.AddScoped<IGetUserUseCase, GetUserUseCase>();
        builder.Services.AddScoped<IGetUserByEmailUseCase, GetUserByEmailUseCase>();
        builder.Services.AddScoped<IGetUserPasswordByEmailUseCase, GetUserPasswordByEmailUseCase>();
        builder.Services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
        builder.Services.AddScoped<IGetPaginatedUserUseCase, GetPaginatedUserUseCase>();
        // builder.Services.AddScoped<ISetIsVerifiedUserUseCase, SetIsVerifiedUserUseCase>();

        builder.Services.AddScoped<ICreateOrUpdateUserPasswordUseCase, CreateOrUpdateUserPasswordUseCase>();
    }
}