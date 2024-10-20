using API.Core.Auth.UseCases;
using API.Core.Codes.UseCases;
using API.Core.User.UseCases;
using API.Infra.Errors;
using API.Infra.Interfaces;
using Shared.Auth;
using Shared.General;
using Shared.Handlers.Email;

namespace API.Modules.Auth.UseCases;

public class SendRecoveryEmailUseCase(
    IGetUserByEmailUseCase getUserByEmailUseCase,
    ICreateRecoveryCodeUseCase createRecoveryCodeUseCase,
    IEmailHandler emailHandler,
    IConfiguration configuration
) : ISendRecoveryEmailUseCase
{
    public async Task<Result<bool>> Handle(RecoveryDto dto)
    {
        var result = new Result<bool>();

        var findUserResult = await getUserByEmailUseCase.Handle(dto.Email);
        if (findUserResult.HasError) return result.SetError(findUserResult.Message);

        var user = findUserResult.Data!;

        try
        {
            var createRecoveryCodeResult = await createRecoveryCodeUseCase.Handle(user.Id);
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
                            Expiração do código: {recoveryCode.ExpireDate.AddHours(-3).ToLocalTime()}
                        </p>
                            ",
                IsHtml = true
            });
        }
        catch
        {
            return result.SetError(AuthMessageErrors.SendEmailError);
        }

        return result.SetData(true);
    }
}