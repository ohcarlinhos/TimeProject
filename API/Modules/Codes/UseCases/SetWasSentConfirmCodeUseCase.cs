using Core.Codes;
using Core.Codes.UseCases;
using API.Infra.Errors;
using Shared.General;

namespace API.Modules.Codes.UseCases;

public class SetWasSentConfirmCodeUseCase(IConfirmCodeRepository repo) : ISetWasSentConfirmCodeUseCase
{
    public async Task<Result<bool>> Handle(string id, bool wasSent = true)
    {
        var result = new Result<bool>();
        var recoveryCode = await repo.FindById(id);

        if (recoveryCode == null)
            return result.SetError(ConfirmCodeMessageErrors.NotFound);

        recoveryCode.WasSent = wasSent;
        await repo.Update(recoveryCode);

        return result.SetData(true);
    }
}