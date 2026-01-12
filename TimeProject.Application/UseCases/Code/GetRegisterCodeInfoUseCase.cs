using AutoMapper;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities.Enums;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Codes;
using TimeProject.Domain.RemoveDependencies.Dtos.Codes;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Code;

public class GetRegisterCodeInfoUseCase(IConfirmCodeRepository repo, IMapper mapper) : IGetRegisterCodeInfoUseCase
{
    public ICustomResult<IConfirmCodeOutDto> Handle(int userId)
    {
        var result = new CustomResult<IConfirmCodeOutDto>();
        var codes = repo.FindByUserIdThatIsNotExpiredOrUsed(userId, ConfirmCodeType.Register);

        return codes.Count != 0
            ? result.SetData(mapper.Map<IConfirmCode, IConfirmCodeOutDto>(codes.First()))
            : result.SetError("not_found:code_not_found");
    }
}