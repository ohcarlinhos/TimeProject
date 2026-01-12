using TimeProject.Application.ObjectValues;
using TimeProject.Domain.UseCases.Code;
using TimeProject.Domain.UseCases.User;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.ObjectValues.Users;

namespace TimeProject.Application.UseCases.User;

public class RecoveryPasswordUseCase(
    ICreateOrUpdateUserPasswordByEmailUseCase createOrUpdateUserPasswordByEmailUseCase,
    ISetIsUsedConfirmCodeUseCase setIsUsedConfirmCodeUseCase,
    IValidateConfirmCodeUseCase validateConfirmCodeUseCase
) : IRecoveryPasswordUseCase
{
    public ICustomResult<bool> Handle(IRecoveryPasswordDto dto)
    {
        var result = new CustomResult<bool>();

        var validateConfirmCodeResult = validateConfirmCodeUseCase.Handle(dto.Code, dto.Email);
        if (validateConfirmCodeResult.HasError) return result.SetError(validateConfirmCodeResult.Message);

        var updatePasswordResult = createOrUpdateUserPasswordByEmailUseCase.Handle(dto.Email, dto.Password);
        if (updatePasswordResult.HasError) return result.SetError(updatePasswordResult.Message);

        setIsUsedConfirmCodeUseCase.Handle(dto.Code);

        return result.SetData(true);
    }
}