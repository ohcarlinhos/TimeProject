using Core.Codes.UseCases;
using Core.User.UseCases;
using Shared.General;
using Shared.User;

namespace App.Modules.User.UseCases;

public class RecoveryPasswordUseCase(
    ICreateOrUpdateUserPasswordByEmailUseCase createOrUpdateUserPasswordByEmailUseCase,
    ISetIsUsedConfirmCodeUseCase setIsUsedConfirmCodeUseCase,
    IValidateConfirmCodeUseCase validateConfirmCodeUseCase
) : IRecoveryPasswordUseCase
{
    public async Task<Result<bool>> Handle(RecoveryPasswordDto dto)
    {
        var result = new Result<bool>();

        var validateConfirmCodeResult = await validateConfirmCodeUseCase.Handle(dto.Code, dto.Email);
        if (validateConfirmCodeResult.HasError)
        {
            return result.SetError(validateConfirmCodeResult.Message);
        }

        var updatePasswordResult = await createOrUpdateUserPasswordByEmailUseCase.Handle(dto.Email, dto.Password);
        if (updatePasswordResult.HasError)
        {
            return result.SetError(updatePasswordResult.Message);
        }

        await setIsUsedConfirmCodeUseCase.Handle(dto.Code);

        return result.SetData(true);
    }
}