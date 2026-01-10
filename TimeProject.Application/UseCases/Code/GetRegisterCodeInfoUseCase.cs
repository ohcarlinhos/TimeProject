using AutoMapper;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Code;
using TimeProject.Domain.RemoveDependencies.Dtos.Codes;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Code;

public class GetRegisterCodeInfoUseCase(IConfirmCodeRepository repo, IMapper mapper) : IGetRegisterCodeInfoUseCase
{
    public async Task<ICustomResult<ConfirmCodeOutDto>> Handle(int userId)
    {
        var result = new CustomResult<ConfirmCodeOutDto>();
        var codes = await repo.FindByUserIdThatIsNotExpiredOrUsed(userId, ConfirmCodeType.Register);

        return codes.Count != 0
            ? result.SetData(mapper.Map<ConfirmCode, ConfirmCodeOutDto>(codes.First()))
            : result.SetError("not_found:code_not_found");
    }
}