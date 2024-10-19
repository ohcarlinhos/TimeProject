using API.Core.Codes;
using API.Core.Codes.UseCases;
using API.Infra.Errors;
using Shared.General;

namespace API.Modules.Codes.UseCases;

public class ValidateConfirmCodeUseCase(IConfirmCodeRepository repo) : IValidateConfirmCodeUseCase
{
    public async Task<Result<bool>> Handle(string id, string email)
    {
        var result = new Result<bool>();
        var recoveryCode = await repo.FindByIdAndEmail(id, email);

        if (recoveryCode == null) return result.SetError(ConfirmCodeMessageErrors.NotFound);

        if (recoveryCode is { IsUsed: true } || DateTime.Now > recoveryCode.ExpireDate)
            return result.SetError(ConfirmCodeMessageErrors.IsUsedOrExpired);

        return result.SetData(true);
    }
}