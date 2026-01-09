using TimeProject.Core.Application.General;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.Code;

namespace TimeProject.Api.Modules.Codes.UseCases;

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