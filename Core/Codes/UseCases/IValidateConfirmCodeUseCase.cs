using Shared.General;

namespace Core.Codes.UseCases;

public interface IValidateConfirmCodeUseCase
{
    Task<Result<bool>> Handle(string id, string email);
}