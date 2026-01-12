using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Codes;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Code;

public class SetIsUsedConfirmCodeUseCase(IConfirmCodeRepository repo) : ISetIsUsedConfirmCodeUseCase
{
    public ICustomResult<bool> Handle(string id)
    {
        var result = new CustomResult<bool>();
        var recoveryCode = repo.FindById(id);

        if (recoveryCode == null)
            return result.SetError(ConfirmCodeMessageErrors.NotFound);

        recoveryCode.IsUsed = true;
        repo.Update(recoveryCode);

        return result.SetData(true);
    }
}