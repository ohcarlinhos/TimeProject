using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Code;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Code;

public class ValidateConfirmCodeUseCase(IConfirmCodeRepository repo) : IValidateConfirmCodeUseCase
{
    public ICustomResult<bool> Handle(string id, string email)
    {
        var result = new CustomResult<bool>();

        var code = repo.FindByIdAndEmail(id, email);

        if (code == null) return result.SetError(ConfirmCodeMessageErrors.NotFound);

        if (code is { IsUsed: true } || DateTime.Now.ToUniversalTime() > code.ExpireDate)
            return result.SetError(ConfirmCodeMessageErrors.IsUsedOrExpired);

        return result.SetData(true);
    }
}