using API.Core.Codes;
using API.Core.Codes.UseCases;
using API.Infra.Errors;
using Entities;
using Shared.General;

namespace API.Modules.Codes.UseCases;

public class CreateRecoveryCodeUseCase(IConfirmCodeRepository repo) : ICreateRecoveryCodeUseCase
{
    public async Task<Result<ConfirmCodeEntity>> Handle(int userId)
    {
        var result = new Result<ConfirmCodeEntity>();
        var codes = (await repo
                .FindByUserId(userId, ConfirmCodeType.Recovery))
            .Where(rc => DateTime.Now < rc.ExpireDate && rc is { IsUsed: false })
            .ToList();

        return codes.Count > 0
            ? result.SetError(ConfirmCodeMessageErrors.CheckYourEmailInbox)
            : result.SetData(await repo.Create(new ConfirmCodeEntity
            {
                UserId = userId,
                ExpireDate = DateTime.Now.AddMinutes(15).ToUniversalTime(),
                Type = ConfirmCodeType.Recovery
            }));
    }
}