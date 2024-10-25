using API.Core.Auth.UseCases;
using API.Core.Codes.UseCases;
using API.Core.User.UseCases;
using API.Infra.Errors;
using API.Infra.Interfaces;
using API.Modules.Auth.Utils;
using Entities;
using Shared.General;

namespace API.Modules.Auth.UseCases;

public class SendVerifyEmailUseCase(
    ICreateConfirmCodeUseCase createConfirmCodeUseCase,
    IGetUserByEmailUseCase getUserByEmailUseCase,
    ISetWasSentConfirmCodeUseCase setWasSentConfirmCodeUseCase,
    IEmailHandler emailHandler,
    IConfiguration configuration) : ISendVerifyEmailUseCase
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
            emailHandler.Send(VerifyEmailFactory.Create(
                email,
                configuration["VerifyUrl"] + registerCode.Id,
                registerCode.ExpireDate.AddHours(-3).ToLocalTime()
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