using AutoMapper;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities.Enums;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Codes;
using TimeProject.Domain.Dtos.Codes;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Codes;

public class GetRegisterCodeInfoUseCase(IConfirmCodeRepository repository, IMapper mapper) : IGetRegisterCodeInfoUseCase
{
    public ICustomResult<IConfirmCodeOutDto> Handle(int userId)
    {
        var result = new CustomResult<IConfirmCodeOutDto>();
        var codes = repository.FindByUserIdThatIsNotExpiredOrUsed(userId, ConfirmCodeType.Register);

        return codes.Count != 0
            ? result.SetData(mapper.Map<IConfirmCode, IConfirmCodeOutDto>(codes.First()))
            : result.SetError("not_found:code_not_found");
    }
}