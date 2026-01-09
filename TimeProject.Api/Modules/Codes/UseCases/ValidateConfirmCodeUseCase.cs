using Core.Codes;
using Core.Codes.UseCases;
using Shared.General;
using TimeProject.Api.Infrastructure.Errors;

namespace TimeProject.Api.Modules.Codes.UseCases;

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