using API.Core.Codes;
using API.Infra.Errors;
using Entities;
using Shared.General;

namespace API.Modules.Codes;

public class ConfirmCodeServices(IConfirmCodeRepository repository) : IConfirmCodeServices
{
    public async Task<Result<ConfirmCodeEntity>> CreateRecovery(int userId)
    {
        var result = new Result<ConfirmCodeEntity>();
        var codes = (await repository
                .FindByUserId(userId, ConfirmCodeType.Recovery))
            .Where(rc => DateTime.Now < rc.ExpireDate && rc is { IsUsed: false })
            .ToList();
        
        return codes.Count > 0
            ? result.SetError(ConfirmCodeMessageErrors.CheckYourEmailInbox)
            : result.SetData(await repository.Create(new ConfirmCodeEntity
            {
                UserId = userId,
                ExpireDate = DateTime.Now.AddMinutes(15).ToUniversalTime(),
                Type = ConfirmCodeType.Recovery
            }));
    }

    public async Task<Result<bool>> Validate(string id, string email)
    {
        var result = new Result<bool>();
        var recoveryCode = await repository.FindByIdAndEmail(id, email);

        if (recoveryCode == null) return result.SetError(ConfirmCodeMessageErrors.NotFound);

        if (recoveryCode is { IsUsed: true } || DateTime.Now > recoveryCode.ExpireDate)
            return result.SetError(ConfirmCodeMessageErrors.IsUsedOrExpired);

        return result.SetData(true);
    }

    public async Task<Result<bool>> SetUsed(string id)
    {
        var result = new Result<bool>();
        var recoveryCode = await repository.FindById(id);

        if (recoveryCode == null)
            return result.SetError(ConfirmCodeMessageErrors.NotFound);

        recoveryCode.IsUsed = true;
        await repository.Update(recoveryCode);

        return result.SetData(true);
    }
}