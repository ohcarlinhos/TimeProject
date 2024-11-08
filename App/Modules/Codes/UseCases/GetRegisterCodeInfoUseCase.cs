using AutoMapper;
using Core.Codes;
using Core.Codes.UseCases;
using Entities;
using Shared.Codes;
using Shared.General;

namespace App.Modules.Codes.UseCases;

public class GetRegisterCodeInfoUseCase(IConfirmCodeRepository repo, IMapper mapper) : IGetRegisterCodeInfoUseCase
{
    public async Task<Result<ConfirmCodeMap>> Handle(int userId)
    {
        var result = new Result<ConfirmCodeMap>();
        var codes = await repo.FindByUserIdThatIsNotExpiredOrUsed(userId, ConfirmCodeType.Register);

        return codes.Count != 0
            ? result.SetData(mapper.Map<ConfirmCodeEntity, ConfirmCodeMap>(codes.First()))
            : result.SetError("not_found:code_not_found");
    }
}