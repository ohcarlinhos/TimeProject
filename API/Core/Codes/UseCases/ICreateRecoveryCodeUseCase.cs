using Entities;
using Shared.General;

namespace API.Core.Codes.UseCases;

public interface ICreateRecoveryCodeUseCase
{
    Task<Result<ConfirmCodeEntity>> Handle(int userId);
}