using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Core.Application.General;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.Code;

namespace TimeProject.Application.UseCases.Code;

public class ValidateConfirmCodeUseCase(IConfirmCodeRepository repo) : IValidateConfirmCodeUseCase
{
    public async Task<Result<bool>> Handle(string id, string email)
    {
        var result = new Result<bool>();

        var code = await repo.FindByIdAndEmail(id, email);

        if (code == null) return result.SetError(ConfirmCodeMessageErrors.NotFound);

        if (code is { IsUsed: true } || DateTime.Now.ToUniversalTime() > code.ExpireDate)
            return result.SetError(ConfirmCodeMessageErrors.IsUsedOrExpired);

        return result.SetData(true);
    }
}