using App.Infra.Errors;
using App.Infra.Interfaces;
using App.Modules.Auth.Utils;
using Core.Codes.UseCases;
using Core.User.UseCases;
using Entities;
using Shared.General;

namespace App.Modules.User.UseCases;

public class SendRecoveryEmailUseCase(
    IGetUserByEmailUseCase getUserByEmailUseCase,
    ICreateConfirmCodeUseCase createConfirmCodeUseCase,
    ISetWasSentConfirmCodeUseCase setWasSentConfirmCodeUseCase,
    IEmailHandler emailHandler,
    IConfiguration configuration
) : ISendRecoveryEmailUseCase
{
    public async Task<Result<bool>> Handle(string email)
    {
        var result = new Result<bool>();

        var findUserResult = await getUserByEmailUseCase.Handle(email);
        if (findUserResult.HasError) return result.SetError(findUserResult.Message);

        var user = findUserResult.Data!;

        var createRecoveryCodeResult = await createConfirmCodeUseCase.Handle(user.Id, ConfirmCodeType.Recovery);

        var recoveryCode = createRecoveryCodeResult.Data!;
        if (recoveryCode.WasSent) return result.SetError(ConfirmCodeMessageErrors.CheckYourEmailInbox);

        try
        {
            emailHandler.Send(RecoveryEmailFactory.Create(
                email,
                configuration["RecoveryUrl"] + recoveryCode.Id,
                recoveryCode.ExpireDate.ToString("dd/MM/yyyy HH:mm:ss")
            ));

            await setWasSentConfirmCodeUseCase.Handle(recoveryCode.Id);
        }
        catch
        {
            return result.SetError(AuthMessageErrors.SendEmailError);
        }

        return result.SetData(true);
    }
}