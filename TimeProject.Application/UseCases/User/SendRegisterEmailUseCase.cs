using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Api.Infrastructure.Interfaces;
using TimeProject.Application.UseCases.User.Factories;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.UseCases.Code;
using TimeProject.Core.Domain.UseCases.User;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Application.UseCases.User;

public class SendRegisterEmailUseCase(
    ICreateConfirmCodeUseCase createConfirmCodeUseCase,
    IGetUserByEmailUseCase getUserByEmailUseCase,
    ISetWasSentConfirmCodeUseCase setWasSentConfirmCodeUseCase,
    IEmailHandler emailHandler,
    IHookHandler hookHandler
) : ISendRegisterEmailUseCase
{
    public async Task<Result<bool>> Handle(string email, string verifyUrl)
    {
        var result = new Result<bool>();

        var findUserResult = await getUserByEmailUseCase.Handle(email);
        if (findUserResult.HasError) return result.SetError(findUserResult.Message);

        var user = findUserResult.Data!;

        var registerCodeResult = await createConfirmCodeUseCase.Handle(user.Id, ConfirmCodeType.Register);
        if (registerCodeResult.HasError) return result.SetError(registerCodeResult.Message);

        var registerCode = registerCodeResult.Data!;
        if (registerCode.WasSent) return result.SetError(ConfirmCodeMessageErrors.CheckYourEmailInbox);

        try
        {
            emailHandler.Send(RegisterEmailFactory.Create(
                email,
                verifyUrl + registerCode.Id,
                registerCode.ExpireDate
            ));

            await setWasSentConfirmCodeUseCase.Handle(registerCode.Id);
        }
        catch
        {
            await hookHandler.SendError($"Não foi possível enviar o e-mail de verificação para:\n<b>{user.Email}</b>");
            return result.SetError(AuthMessageErrors.SendEmailError);
        }

        return result.SetData(true);
    }
}