using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Codes;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Codes;

public class SetIsUsedConfirmCodeUseCase(IConfirmCodeRepository repository) : ISetIsUsedConfirmCodeUseCase
{
    public ICustomResult<bool> Handle(string id)
    {
        var result = new CustomResult<bool>();
        var recoveryCode = repository.FindById(id);

        if (recoveryCode == null)
            return result.SetError(ConfirmCodeMessageErrors.NotFound);

        recoveryCode.IsUsed = true;
        repository.Update(recoveryCode);

        return result.SetData(true);
    }
}