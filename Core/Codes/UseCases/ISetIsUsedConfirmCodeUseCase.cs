using Shared.General;

namespace Core.Codes.UseCases;

public interface ISetIsUsedConfirmCodeUseCase
{
    Task<Result<bool>> Handle(string id);
}