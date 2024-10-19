using API.Core.Codes;
using API.Core.Codes.UseCases;
using API.Infra.Errors;
using Shared.General;

namespace API.Modules.Codes.UseCases;

public class SetUsedConfirmCodeUseCase(IConfirmCodeRepository repo) : ISetUsedConfirmCodeUseCase
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