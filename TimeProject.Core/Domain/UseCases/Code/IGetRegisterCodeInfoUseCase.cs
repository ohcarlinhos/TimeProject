using TimeProject.Core.Application.Dtos.Codes;
using TimeProject.Core.Application.General;

namespace TimeProject.Core.Domain.UseCases.Code;

public interface IGetRegisterCodeInfoUseCase
{
    Task<Result<ConfirmCodeOutDto>> Handle(int userId);
}