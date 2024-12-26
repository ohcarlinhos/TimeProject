using App.Infra.Errors;
using App.Infra.Interfaces;
using App.Modules.Auth.Utils;
using Core.Codes.UseCases;
using Core.User.UseCases;
using Entities;
using Shared.General;

namespace App.Modules.User.UseCases;

public class SendRegisterEmailUseCase(
    ICreateConfirmCodeUseCase createConfirmCodeUseCase,
    IGetUserByEmailUseCase getUserByEmailUseCase,
    ISetWasSentConfirmCodeUseCase setWasSentConfirmCodeUseCase,
    IEmailHandler emailHandler,
    IConfiguration configuration) : ISendRegisterEmailUseCase
{
    public async Task<Result<bool>> Handle(string email)
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
                configuration["VerifyUrl"] +  registerCode.Id,
                registerCode.ExpireDate.ToString("dd/MM/yyyy HH:mm:ss")
            ));

            await setWasSentConfirmCodeUseCase.Handle(registerCode.Id);
        }
        catch
        {
            return result.SetError(AuthMessageErrors.SendEmailError);
        }

        return result.SetData(true);
    }
}