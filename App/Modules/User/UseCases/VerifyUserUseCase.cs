using App.Infra.Interfaces;
using Core.Codes.UseCases;
using Core.User.UseCases;
using Shared.General;

namespace App.Modules.User.UseCases;

public class VerifyUserUseCase(
    ISetIsUsedConfirmCodeUseCase setIsUsedConfirmCodeUseCase,
    ISetIsVerifiedUserUseCase setIsVerifiedUserUseCase,
    IValidateConfirmCodeUseCase validateConfirmCodeUseCase,
    IHookHandler hook
) : IVerifyUserUseCase
{
    public async Task<Result<bool>> Handle(int id, string email, string code)
    {
        var result = new Result<bool>();

        var validateResult = await validateConfirmCodeUseCase.Handle(code, email);
        if (validateResult.HasError) return result.SetError(validateResult.Message);

        await setIsVerifiedUserUseCase.Handle(id, true);
        await setIsUsedConfirmCodeUseCase.Handle(code);

        await hook.Send(HookTo.Users, $"O usuário com o e-mail {email} foi verifiado com sucesso.");

        return result.SetData(true);
    }
}