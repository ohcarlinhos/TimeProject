using TimeProject.Core.RemoveDependencies.Dtos.Codes;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.Code;

public interface IGetRegisterCodeInfoUseCase
{
    Task<Result<ConfirmCodeOutDto>> Handle(int userId);
}