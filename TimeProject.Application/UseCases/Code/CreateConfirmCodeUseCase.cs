using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Code;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Code;

public class CreateConfirmCodeUseCase(IConfirmCodeRepository repo) : ICreateConfirmCodeUseCase
{
    public async Task<ICustomResult<ConfirmCode>> Handle(int userId, ConfirmCodeType type)
    {
        var result = new CustomResult<ConfirmCode>();
        var codes = await repo.FindByUserIdThatIsNotExpiredOrUsed(userId, type);

        return codes.Count > 0
            ? result.SetData(codes.First())
            : result.SetData(await repo.Create(new ConfirmCode
            {
                UserId = userId,
                ExpireDate = DateTime.Now.AddMinutes(15).ToUniversalTime(),
                Type = type
            }));
    }
}