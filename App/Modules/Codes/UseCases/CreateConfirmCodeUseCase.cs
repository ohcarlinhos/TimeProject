using Core.Codes;
using Core.Codes.UseCases;
using Entities;
using Shared.General;

namespace App.Modules.Codes.UseCases;

public class CreateConfirmCodeUseCase(IConfirmCodeRepository repo) : ICreateConfirmCodeUseCase
{
    public async Task<Result<ConfirmCodeEntity>> Handle(int userId, ConfirmCodeType type)
    {
        var result = new Result<ConfirmCodeEntity>();
        var codes = await repo.FindByUserIdThatIsNotExpiredOrUsed(userId, type);

        return codes.Count > 0
            ? result.SetData(codes.First())
            : result.SetData(await repo.Create(new ConfirmCodeEntity
            {
                UserId = userId,
                ExpireDate = DateTime.Now.AddMinutes(15).ToUniversalTime(),
                Type = type
            }));
    }
}
