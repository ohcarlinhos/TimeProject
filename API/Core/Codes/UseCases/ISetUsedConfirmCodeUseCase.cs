using Shared.General;

namespace API.Core.Codes.UseCases;

public interface ISetUsedConfirmCodeUseCase
{
    Task<Result<bool>> Handle(string id);
}