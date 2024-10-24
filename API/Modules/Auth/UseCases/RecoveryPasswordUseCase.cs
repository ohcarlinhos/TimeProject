using API.Core.Auth.UseCases;
using API.Core.Codes.UseCases;
using API.Core.User.UseCases;
using Shared.Auth;
using Shared.General;

namespace API.Modules.Auth.UseCases;

public class RecoveryPasswordUseCase(
    IUpdateUserPasswordByEmailUseCase updateUserPasswordByEmailUseCase,
    ISetIsUsedConfirmCodeUseCase setIsUsedConfirmCodeUseCase,
    IValidateConfirmCodeUseCase validateConfirmCodeUseCase
) : IRecoveryPasswordUseCase
{
    public async Task<Result<bool>> Handle(RecoveryPasswordDto dto)
    {
        var result = new Result<bool>();

        var validateConfirmCodeResult = await validateConfirmCodeUseCase.Handle(dto.Code, dto.Email);

        if (validateConfirmCodeResult.HasError)
            return result.SetError(validateConfirmCodeResult.Message);

        var updatePasswordResult = await updateUserPasswordByEmailUseCase.Handle(dto.Email, dto.Password);

        if (updatePasswordResult.HasError)
            return result.SetError(updatePasswordResult.Message);

        await setIsUsedConfirmCodeUseCase.Handle(dto.Code);

        return result.SetData(true);
    }
}