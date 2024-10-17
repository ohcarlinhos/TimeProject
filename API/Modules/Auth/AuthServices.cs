using API.Core.Auth;
using API.Core.User.UseCases;
using API.Infra.Errors;
using API.Infra.Handlers.Email;
using API.Infra.Interfaces;
using API.Infra.Services;
using API.Modules.Codes.Services;
using Entities;
using Shared.Auth;
using Shared.General;
using Shared.Handlers.Email;

namespace API.Modules.Auth;

public class AuthServices(
    IConfirmCodeServices confirmCodeServices,
    ITokenService tokenService,
    IEmailHandler emailHandler,
    IConfiguration configuration,
    IUpdateUserPasswordByEmailUseCase updateUserPasswordByEmailUseCase,
    IGetUserByEmailUseCase getUserByEmailUseCase)
    : IAuthService
{
    public async Task<Result<JwtData>> Login(LoginDto dto)
    {
        return await Login(dto, false);
    }

    public async Task<Result<JwtData>> Login(LoginDto dto, bool onlyAdmin)
    {
        return await _login(dto, onlyAdmin);
    }

    private async Task<Result<JwtData>> _login(LoginDto dto, bool onlyAdmin = false)
    {
        var result = new Result<JwtData>();

        var findUserResult = await getUserByEmailUseCase.Handle(dto.Email);
        if (findUserResult.HasError) return result.SetError(AuthErrors.WrongEmailOrPassword);

        var user = findUserResult.Data!;

        if (BCrypt.Net.BCrypt.Verify(dto.Password, user.Password) == false)
        {
            return result.SetError(AuthErrors.WrongEmailOrPassword);
        }

        if (onlyAdmin && user.UserRole != UserRole.Admin)
        {
            return result.SetError("forbid");
        }

        return result.SetData(tokenService.GenerateBearerJwt(user));
    }

    public async Task<Result<bool>> Recovery(RecoveryDto dto)
    {
        var result = new Result<bool>();

        var findUserResult = await getUserByEmailUseCase.Handle(dto.Email);
        if (findUserResult.HasError) return result.SetError(findUserResult.Message);

        var user = findUserResult.Data!;

        try
        {
            var createRecoveryCodeResult = await confirmCodeServices.CreateRecovery(user.Id);
            if (createRecoveryCodeResult.HasError) return result.SetError(createRecoveryCodeResult.Message);

            var recoveryCode = createRecoveryCodeResult.Data!;

            var emailUrl = configuration["RecoveryUrl"] + recoveryCode.Id;

            emailHandler.Send(new EmailPayload
            {
                To = dto.Email,
                Subject = "Recuperação de senha - Registra meu tempo aí!",
                Body =
                    $@"
                        <p>
                            Você acaba de requisitar a recuperação da sua senha, para prosseguir <a href='{emailUrl}' target='_blank'>clique aqui</a> para recria-la. <br/>
                            Ou copie a URL e cole no seu navegador: {emailUrl} <br/><br/>
                            Expiração do código: {recoveryCode.ExpireDate.ToLocalTime()}
                        </p>
                            ",
                IsHtml = true
            });
        }
        catch
        {
            return result.SetError("send_recovery_email_error");
        }

        return result.SetData(true);
    }

    public async Task<Result<bool>> RecoveryPassword(RecoveryPasswordDto dto)
    {
        var result = new Result<bool>();

        var validateConfirmCodeResult = await confirmCodeServices.Validate(dto.Code, dto.Email);

        if (validateConfirmCodeResult.HasError)
            return result.SetError(validateConfirmCodeResult.Message);

        var updatePasswordResult = await updateUserPasswordByEmailUseCase.Handle(dto.Email, dto.Password);

        if (updatePasswordResult.HasError)
            return result.SetError(updatePasswordResult.Message);

        await confirmCodeServices.SetUsed(dto.Code);

        return result.SetData(true);
    }
}