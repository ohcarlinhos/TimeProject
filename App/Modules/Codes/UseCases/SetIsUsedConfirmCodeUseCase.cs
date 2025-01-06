using Core.Codes;
using Core.Codes.UseCases;
using App.Infrastructure.Errors;
using Shared.General;

namespace App.Modules.Codes.UseCases;

public class SetIsUsedConfirmCodeUseCase(IConfirmCodeRepository repo) : ISetIsUsedConfirmCodeUseCase
{
    public async Task<Result<bool>> Handle(string id)
    {
        var result = new Result<bool>();
        var recoveryCode = await repo.FindById(id);

        if (recoveryCode == null)
            return result.SetError(ConfirmCodeMessageErrors.NotFound);

        recoveryCode.IsUsed = true;
        await repo.Update(recoveryCode);

        return result.SetData(true);
    }
}