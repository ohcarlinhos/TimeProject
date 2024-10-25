using API.Core.Auth.UseCases;
using API.Core.Codes.UseCases;
using API.Core.User.UseCases;
using Shared.General;

namespace API.Modules.Auth.UseCases;

public class VerifyUserUseCase(
    ISetIsUsedConfirmCodeUseCase setIsUsedConfirmCodeUseCase,
    ISetIsVerifiedUserUseCase setIsVerifiedUserUseCase,
    IValidateConfirmCodeUseCase validateConfirmCodeUseCase
) : IVerifyUserUseCase
{
    public async Task<Result<bool>> Handle(int id, string email, string code)
    {
        var result = new Result<bool>();

        var validateResult = await validateConfirmCodeUseCase.Handle(code, email);
        if (validateResult.HasError) return result.SetError(validateResult.Message);

        await setIsVerifiedUserUseCase.Handle(id, true);
        await setIsUsedConfirmCodeUseCase.Handle(code);

        return result.SetData(true);
    }
}