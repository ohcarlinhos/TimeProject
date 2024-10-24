using Shared.General;

namespace API.Core.Codes.UseCases;

public interface ISetIsUsedConfirmCodeUseCase
{
    Task<Result<bool>> Handle(string id);
}