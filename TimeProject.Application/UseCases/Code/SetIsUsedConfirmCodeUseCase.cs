using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Code;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Code;

public class SetIsUsedConfirmCodeUseCase(IConfirmCodeRepository repo) : ISetIsUsedConfirmCodeUseCase
{
    public async Task<ICustomResult<bool>> Handle(string id)
    {
        var result = new CustomResult<bool>();
        var recoveryCode = await repo.FindById(id);

        if (recoveryCode == null)
            return result.SetError(ConfirmCodeMessageErrors.NotFound);

        recoveryCode.IsUsed = true;
        await repo.Update(recoveryCode);

        return result.SetData(true);
    }
}