using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.Code;

namespace TimeProject.Application.UseCases.Code;

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