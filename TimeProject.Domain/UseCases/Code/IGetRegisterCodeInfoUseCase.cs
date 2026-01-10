using TimeProject.Domain.RemoveDependencies.Dtos.Codes;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Code;

public interface IGetRegisterCodeInfoUseCase
{
    Task<ICustomResult<ConfirmCodeOutDto>> Handle(int userId);
}