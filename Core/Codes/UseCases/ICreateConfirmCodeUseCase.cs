using Entities;
using Shared.General;

namespace Core.Codes.UseCases;

public interface ICreateConfirmCodeUseCase
{
    Task<Result<ConfirmCodeEntity>> Handle(int userId, ConfirmCodeType type);
}