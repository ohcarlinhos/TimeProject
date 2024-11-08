using Shared.Codes;
using Shared.General;

namespace Core.Codes.UseCases;

public interface IGetRegisterCodeInfoUseCase
{
    Task<Result<ConfirmCodeMap>> Handle(int userId);
}