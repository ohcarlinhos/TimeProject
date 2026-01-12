using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities.Enums;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Code;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Entities;

namespace TimeProject.Application.UseCases.Code;

public class CreateConfirmCodeUseCase(IConfirmCodeRepository repo) : ICreateConfirmCodeUseCase
{
    public ICustomResult<IConfirmCode> Handle(int userId, ConfirmCodeType type)
    {
        var result = new CustomResult<IConfirmCode>();
        var codes = repo.FindByUserIdThatIsNotExpiredOrUsed(userId, type);

        return codes.Count > 0
            ? result.SetData(codes.First())
            : result.SetData(repo.Create(new ConfirmCode
            {
                UserId = userId,
                ExpireDate = DateTime.Now.AddMinutes(15).ToUniversalTime(),
                Type = type
            }));
    }
}