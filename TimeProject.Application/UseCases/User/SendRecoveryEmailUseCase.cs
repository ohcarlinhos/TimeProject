using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Application.UseCases.User.Factories;
using TimeProject.Infrastructure.Entities;
using TimeProject.Infrastructure.Entities.Enums;
using TimeProject.Domain.UseCases.Codes;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Factories;
using TimeProject.Infrastructure.Interfaces;

namespace TimeProject.Application.UseCases.User;

public class SendRecoveryEmailUseCase(
    IGetUserByEmailUseCase getUserByEmailUseCase,
    ICreateConfirmCodeUseCase createConfirmCodeUseCase,
    ISetWasSentConfirmCodeUseCase setWasSentConfirmCodeUseCase,
    IEmailHandler emailHandler,
    IHookHandler hookHandler
) : ISendRecoveryEmailUseCase
{
    public ICustomResult<bool> Handle(string email, string recoveryUrl)
    {
        var result = new CustomResult<bool>();

        var findUserResult = getUserByEmailUseCase.Handle(email);
        if (findUserResult.HasError) return result.SetError(findUserResult.Message);

        var user = findUserResult.Data!;

        var createRecoveryCodeResult = createConfirmCodeUseCase.Handle(user.Id, ConfirmCodeType.Recovery);

        var recoveryCode = createRecoveryCodeResult.Data!;
        if (recoveryCode.WasSent) return result.SetError(ConfirmCodeMessageErrors.CheckYourEmailInbox);

        try
        {
            emailHandler.Send(RecoveryEmailFactory.Create(
                email,
                recoveryUrl + recoveryCode.Id,
                recoveryCode.ExpireDate
            ));

            setWasSentConfirmCodeUseCase.Handle(recoveryCode.Id);
        }
        catch
        {
            hookHandler.SendError($"Não foi possível enviar o e-mail de recuperação para:\n<b>{user.Email}</b>");
            return result.SetError(AuthMessageErrors.SendEmailError);
        }

        return result.SetData(true);
    }
}