using API.Core.Auth.UseCases;
using API.Core.Codes.UseCases;
using API.Core.User.UseCases;
using API.Infra.Errors;
using API.Infra.Interfaces;
using API.Modules.Auth.Utils;
using Entities;
using Shared.General;

namespace API.Modules.Auth.UseCases;

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
                recoveryCode.ExpireDate.AddHours(-3).ToLocalTime()
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