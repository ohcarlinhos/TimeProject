using TimeProject.Infrastructure.ObjectValues.Pagination;
using TimeProject.Domain.UseCases.Codes;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Domain.Dtos.Users;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.ObjectValues.Pagination.Users;

namespace TimeProject.Application.UseCases.Users;

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