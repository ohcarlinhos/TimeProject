using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Api.Infrastructure.Interfaces;
using TimeProject.Application.UseCases.User.Factories;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.UseCases.Code;
using TimeProject.Core.Domain.UseCases.User;

namespace TimeProject.Application.UseCases.User;

public class SendRecoveryEmailUseCase(
    IGetUserByEmailUseCase getUserByEmailUseCase,
    ICreateConfirmCodeUseCase createConfirmCodeUseCase,
    ISetWasSentConfirmCodeUseCase setWasSentConfirmCodeUseCase,
    IEmailHandler emailHandler,
    IHookHandler hookHandler
) : ISendRecoveryEmailUseCase
{
    public async Task<Result<bool>> Handle(string email, string recoveryUrl)
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
                recoveryUrl + recoveryCode.Id,
                recoveryCode.ExpireDate
            ));

            await setWasSentConfirmCodeUseCase.Handle(recoveryCode.Id);
        }
        catch
        {
            await hookHandler.SendError($"Não foi possível enviar o e-mail de recuperação para:\n<b>{user.Email}</b>");
            return result.SetError(AuthMessageErrors.SendEmailError);
        }

        return result.SetData(true);
    }
}