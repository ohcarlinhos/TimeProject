using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Code;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Application.UseCases.Code;

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