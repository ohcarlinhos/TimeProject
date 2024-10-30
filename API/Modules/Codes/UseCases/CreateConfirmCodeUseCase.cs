using Core.Codes;
using Core.Codes.UseCases;
using Entities;
using Shared.General;

namespace API.Modules.Codes.UseCases;

public class CreateConfirmCodeUseCase(IConfirmCodeRepository repo) : ICreateConfirmCodeUseCase
{
    public async Task<Result<ConfirmCodeEntity>> Handle(int userId, ConfirmCodeType type)
    {
        var result = new Result<ConfirmCodeEntity>();
        var codes = (await repo.FindByUserId(userId, type))
            .Where(rc => DateTime.Now < rc.ExpireDate && rc is { IsUsed: false })
            .ToList();

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
