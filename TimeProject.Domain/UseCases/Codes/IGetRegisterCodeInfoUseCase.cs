using TimeProject.Domain.Dtos.Codes;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Codes;

public interface IGetRegisterCodeInfoUseCase
{
    ICustomResult<IConfirmCodeOutDto> Handle(int userId);
}