using AutoMapper;
using TimeProject.Core.RemoveDependencies.Dtos.Codes;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.Domain.UseCases.Code;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Repositories;

namespace TimeProject.Application.UseCases.Code;

public class GetRegisterCodeInfoUseCase(IConfirmCodeRepository repo, IMapper mapper) : IGetRegisterCodeInfoUseCase
{
    public async Task<Result<ConfirmCodeOutDto>> Handle(int userId)
    {
        var result = new Result<ConfirmCodeOutDto>();
        var codes = await repo.FindByUserIdThatIsNotExpiredOrUsed(userId, ConfirmCodeType.Register);

        return codes.Count != 0
            ? result.SetData(mapper.Map<ConfirmCodeEntity, ConfirmCodeOutDto>(codes.First()))
            : result.SetError("not_found:code_not_found");
    }
}