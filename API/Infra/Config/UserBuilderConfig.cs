using API.Core.User;
using API.Core.User.UseCases;
using API.Core.User.Utils;
using API.Modules.User;
using API.Modules.User.UseCases;
using API.Modules.User.Utils;

namespace API.Infra.Config;

public static class UserBuilderConfig
{
    public static void Apply(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        
        builder.Services.AddScoped<IUserMapDataUtil, UserMapDataUtil>();
        builder.Services.AddScoped<IUpdateUserOptions, UpdateUserOptions>();
        
        builder.Services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
        builder.Services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
        builder.Services.AddScoped<IUpdateUserRoleUseCase, UpdateUserRoleUseCase>();
        builder.Services.AddScoped<IUpdateUserPasswordByEmailUseCase, UpdateUserPasswordByEmailUseCase>();
        builder.Services.AddScoped<IDisableUserUseCase, DisableUserUseCase>();
        builder.Services.AddScoped<IGetUserUseCase, GetUserUseCase>();
        builder.Services.AddScoped<IGetUserByEmailUseCase, GetUserByEmailUseCase>();
        builder.Services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
        builder.Services.AddScoped<IGetAllUserUseCase, GetAllUserUseCase>();
    }
}