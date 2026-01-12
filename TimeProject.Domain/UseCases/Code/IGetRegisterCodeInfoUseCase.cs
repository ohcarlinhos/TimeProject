using TimeProject.Domain.RemoveDependencies.Dtos.Codes;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Code;

public interface IGetRegisterCodeInfoUseCase
{
    ICustomResult<IConfirmCodeOutDto> Handle(int userId);
}