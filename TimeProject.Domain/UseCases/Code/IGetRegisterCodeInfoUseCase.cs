using TimeProject.Domain.RemoveDependencies.Dtos.Codes;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.Code;

public interface IGetRegisterCodeInfoUseCase
{
    Task<Result<ConfirmCodeOutDto>> Handle(int userId);
}