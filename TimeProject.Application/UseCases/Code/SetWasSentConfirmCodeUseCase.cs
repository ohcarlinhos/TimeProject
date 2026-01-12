using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Code;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Code;

public class SetWasSentConfirmCodeUseCase(IConfirmCodeRepository repo) : ISetWasSentConfirmCodeUseCase
{
    public ICustomResult<bool> Handle(string id, bool wasSent = true)
    {
        var result = new CustomResult<bool>();
        var recoveryCode = repo.FindById(id);

        if (recoveryCode == null)
            return result.SetError(ConfirmCodeMessageErrors.NotFound);

        recoveryCode.WasSent = wasSent;
        repo.Update(recoveryCode);

        return result.SetData(true);
    }
}